using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.IO;
using ExcelDataReader;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VolkansUtility
{
    public static class ExcelRW
    {
        public static void WriteDataTableContentToActiveWBWithInterop(DataTable dt, TargetLocation whereTo, bool printTitle = true, bool formatting=true)
            //used if the workbook is open
        {
            try
            {
                object[,] retList = null;
                int width = dt.Columns.Count;
                int height = dt.Rows.Count;
                retList = new object[height, width];
                for (int i = 0; i < height; i++)
                {
                    DataRow r = dt.Rows[i];
                    for (int j = 0; j < width; j++)
                    {
                        retList[i, j] = r.ItemArray[j];
                    }
                }

                Excel.Workbook wb = GetActiveWorkbook();

                if (whereTo ==TargetLocation.NewSheet)
                {
                    Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.Add();
                    ws.Activate();
                }

                //headers
                if (printTitle)
                {
                    int k = 1;
                    foreach (DataColumn col in dt.Columns)
                    {
                        wb.Application.Cells[1, k].Value = col.ColumnName;
                        k = k + 1;
                    }
                }

                //data
                Excel.Range start = wb.Application.ActiveCell;
                Excel.Range rng = ((Excel.Worksheet)wb.ActiveSheet).Range[start, wb.Application.Cells[height + start.Row - 1, start.Column + width - 1]];
                rng.Value = retList;

                //formatting
                if (formatting)
                {
                    Random rd = new Random();
                    string s = rd.Next(10000).ToString();//to give a random table name
                    ((Excel.Worksheet)wb.ActiveSheet).ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, wb.Application.ActiveCell.CurrentRegion, Excel.XlYesNoGuess.xlYes).Name = "VSTO_Table" + s;  
                    ((Excel.Worksheet)wb.ActiveSheet).ListObjects["VSTO_Table" + s].TableStyle = "TableStyleMedium2";
                }

                wb.Activate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public static void WriteDataTableContentToActiveWBWithClosedXML(DataTable dt,string sheetname= "New Sheet For Pasting DT")
        {
            Excel.Workbook wb = GetActiveWorkbook();
            string ext = "";
            if (!wb.FullName.Contains(".xlsx"))
                ext = ".xlsx";
            string filepath = wb.FullName+ext;            
            wb.Save();wb.Close();

            var cxwb = new XLWorkbook(filepath);
            var ws = cxwb.Worksheets.Add(sheetname);            
            ws.Cell(1,1).InsertTable(dt); 
            cxwb.Save();
            Excel.Application app = (Excel.Application)Marshal.GetActiveObject("Excel.Application");
            app.Workbooks.Open(filepath);//reopening
            //MessageBox.Show("Done");
        }

        public static void WriteDataTableContentWithClosedXML(DataTable dt, string filenamepath = "", bool openAfter = false)
        {
            if (string.IsNullOrEmpty(filenamepath))
            {
                var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("New Sheet For Pasting DT");
                ws.Cell(1, 1).InsertTable(dt);
                wb.SaveAs("Tempfile.xlsx");
            }
            else
            {
                var wb = new XLWorkbook(filenamepath);
                wb.Save();
            }

            MessageBox.Show("Done");
            if (openAfter)
            {
                Excel.Application app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                app.Workbooks.Open(string.IsNullOrEmpty(filenamepath) ? "Tempfile.xlsx" : filenamepath);
            }
        }

        public static DataTable ReadFromExcelIntoDTWithOledDB(string filename,string sheet,string crt="",string sql="Select * From ")
        {
            var constr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;IMEX=1; HDR = YES'", filename); //carefull with the single quotes for Extended Properties
            var criteria = (crt.Length == 0) ? "" : " where " + crt;
            var adapter = new OleDbDataAdapter(sql + "[" + sheet + "$]" + criteria, constr);
            var ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public static DataTable ReadFromExcelIntoDTWithExcelReader(string filename, int sheetno,string criteria,string[] cols=null)
        {
            using (var stream = File.Open(filename, FileMode.Open, FileAccess.Read))            
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true //if not always the case, use this as a parameter 
                    }
                });
                DataTable dt = result.Tables[sheetno - 1];
                DataView dv = new DataView(dt);
                dv.RowFilter = criteria;
                if (cols != null)
                    return dv.ToTable(false, cols);
                else
                    return dv.ToTable();
            }
            
        }
        public static DataTable ReadFromCSVtoDataTable(string filepath, char sep=',')
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(filepath))
            {
                string[] headers = sr.ReadLine().Split(sep);
                foreach (string header in headers)
                    dt.Columns.Add(header);
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(sep);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                        dr[i] = rows[i];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public static void relasecom(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public static Excel.Workbook GetActiveWorkbook()
        {
            Excel.Application app = (Excel.Application)Marshal.GetActiveObject("Excel.Application");            
            app.Visible = true;
            return app.ActiveWorkbook;
        }
        public enum ExcelTarget
        {
            DataTable,
            List
        }

        public enum TargetLocation
        {
            NewSheet,
            ActiveCell
        }
    }
}

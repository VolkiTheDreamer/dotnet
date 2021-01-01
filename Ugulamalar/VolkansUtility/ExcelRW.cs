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
        /// <summary>
        /// Used when the workbook is already open.
        /// </summary>
        /// <param name="dt">Datatable</param>
        /// <param name="whereTo">wheteher you want to insert the data into activecell or a new sheet</param>
        /// <param name="printTitle">..</param>
        /// <param name="formatting">..</param>
        public static void WriteDataTableContentToActiveWBWithInterop(DataTable dt, TargetLocation whereTo, bool printTitle = true, bool formatting=true)            
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

                Excel.Workbook wb = Statics.GetActiveWorkbook();

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
                        k++;
                    }
                }

                //data
                Excel.Range start = wb.Application.Cells[2,1];
                Excel.Range rng =wb.ActiveSheet.Range[start, wb.Application.Cells[height + 1, width]];
                rng.Value = retList;

                //formatting
                if (formatting)
                {
                    Random rd = new Random();
                    string s = rd.Next(10000).ToString();//to give a random table name
                    ((Excel.Worksheet)wb.ActiveSheet).ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, wb.Application.ActiveCell.CurrentRegion, Excel.XlYesNoGuess.xlYes).Name = "Static_Table" + s;  
                    ((Excel.Worksheet)wb.ActiveSheet).ListObjects["Static_Table" + s].TableStyle = "TableStyleMedium2";
                }

                wb.Activate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Used when the workbook is closed.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filenamepath">Full pathname. If you want a nerw file to be created, skip this</param>
        /// <param name="openAfter">Whether you want to open the file after the write operation</param>  
        public static void WriteDataTableContentWithClosedXML(DataTable dt, string filenamepath = "", string sheet = "Sheet1", bool openAfter = false)
        {            
            XLWorkbook wb;
            IXLWorksheet ws;            

            if (string.IsNullOrEmpty(filenamepath))
            {
                wb = new XLWorkbook();
                ws = wb.Worksheets.Add("New Sheet For Pasting DT");
                ws.Cell(1, 1).InsertTable(dt);
                wb.SaveAs("Tempfile.xlsx");
            }
            else
            {
                wb = new XLWorkbook(filenamepath);
                ws = wb.Worksheet(sheet);
                ws.Cell(1, 1).InsertTable(dt);
                wb.Save();
            }

            MessageBox.Show("Done");
            if (openAfter)
            {
                Excel.Application app = Statics.GetExcel();
                app.Workbooks.Open(string.IsNullOrEmpty(filenamepath) ? "Tempfile.xlsx" : filenamepath);
            }
        }

        /// <summary>
        /// Reads the data from Excel workbook while it is closed. There is 255-character-limit problem with this. Try ExcelReader in that case
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sheet"></param>
        /// <param name="crt"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable ReadFromExcelIntoDTWithOledDB(string filename,string sql)
        {            
            var constr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;IMEX=1; HDR = YES'", filename); //carefull with the single quotes for Extended Properties            
            var adapter = new OleDbDataAdapter(sql, constr);
            var ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        
        /// <summary>
        /// Makes use of ExcelDataReader package
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sheet">You can provide this either 1-based index or sheet name</param>
        /// <param name="criteria"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static DataTable ReadFromExcelIntoDTWithExcelReader(string filename, dynamic sheet, string criteria=null, string[] cols = null)
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
                dynamic sh;
                if (sheet.GetType() == typeof(string))
                    sh = sheet;
                else
                    sh = sheet - 1;
                DataTable dt = result.Tables[sh];

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

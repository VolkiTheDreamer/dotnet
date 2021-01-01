using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace VolkansUtility
{
    public static class SQLRW
    {
        
        public static DataTable ReadFromOleDB(string cs,string sql)
        {
            OleDbConnection conn = new OleDbConnection(cs);            
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);            
            return dt;
        }

        public static void WriteToOleDB(DataTable dt, string db, string tablename, bool EmptyFirst, DBType dbtype, string[] args = null)
        {
            string cs= string.Empty;
            string delsql=string.Empty;
            OleDbConnection conn=null;
            switch (dbtype)
            {
                case DBType.Oracle:
                    cs = "Provider=OraOLEDB.Oracle;Data Source=" + db + ";User Id="+ args[0] + "; Password=" + args[1] +";";
                    delsql = "Delete * from ";
                    break;
                case DBType.SQLServer:
                    cs = "Provider=MSOLEDBSQL;Server=" + args[0] +";Database=" + db + ";UID=" + args[1] + "; PWD=" + args[2] + "; ";
                    delsql = "Delete from ";
                    break;
                case DBType.Access:
                    cs = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + db + ";Persist Security Info=False";
                    delsql = "Delete from ";
                    break;                
            }

            try
            {
                conn = new OleDbConnection(cs);
                conn.OpenWithControl();//extension method
                if (EmptyFirst)
                {
                    OleDbCommand cmdel = new OleDbCommand(delsql + tablename, conn);
                    cmdel.ExecuteNonQuery();
                }

                OleDbCommand cmd = conn.CreateCommand();
                string cols = string.Join(",", GetColumnNamesFromOleDB(cs, tablename, dbtype));
                List<string> values = new List<string>();
                string target = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        values.Add(dr[dc.ColumnName].ToString());
                    }

                    target = string.Join("','", values);
                    cmd.CommandText = "INSERT INTO " + tablename + " (" + cols + ") VALUES ('" + target + "')";
                    cmd.ExecuteNonQuery();
                    values.Clear();
                }
            }
            catch (Exception ex)
            {
                ex.Message.DumpToOutput();
            }
            finally
            {
                conn.Close();
            }
        }

        public static List<string> GetColumnNamesFromOleDB(string cs, string table, DBType dbtype)
        {
            OleDbConnection conn = new OleDbConnection(cs);
            conn.OpenWithControl();
            List<string> cols = new List<string>();
            string sql = "";
            if (dbtype == DBType.Oracle)
                sql = "Select * from " + table + " where rownum=1";
            else
                sql = "Select Top 1 * from " + table;

            using (var cmd = new OleDbCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                var tbl = reader.GetSchemaTable();
                var nameCol = tbl.Columns["ColumnName"];
                foreach (DataRow row in tbl.Rows)
                {
                    cols.Add(row[nameCol].ToString());
                }
            }
            conn.Close();
            return cols;
        }

        public enum DBType
        {
            Oracle,
            SQLServer,
            Access
        }
    }
}

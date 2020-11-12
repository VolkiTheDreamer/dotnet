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
        public static DataTable ReadFromOleDB(string cs,string sql)//conn açmaya gerek varmı?
        {
            OleDbConnection conn = new OleDbConnection(cs);
            //conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //conn.Close();
            return dt;
        }

        public static List<string> GetColumnNamesFromOleDB(string cs, string table, DBType dbtype)
        {
            OleDbConnection conn = new OleDbConnection(cs);
            conn.Open();
            List<string> cols = new List<string>();
            string sql = "";
            if (dbtype == DBType.Oracle)
                sql = "Select * from " + table + " where rownum=1";
            else
                sql = "Select Top 1 * from " + table;

            using (var cmd = new OleDbCommand(sql,conn))
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

        public static void WriteToOleDB(DataTable dt, string cs, string sql, bool EmptyFirst)
        {
            //
        }
    }
}

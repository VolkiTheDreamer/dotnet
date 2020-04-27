using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLSapmple
{
    class Program
    {
        static void Main(string[] args)
        {
            //try cathc yap
            SqlConnection cnn = new SqlConnection();
            string constr = "Server=localhost\\SQLExpress; database=Excelinefendisi; Integrated Security=SSPI; MultipleActiveResultSets=true";
            string sorgu = "Select konular.[KonuID] from konular where konular.Konu=@kn";
            cnn.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand(sorgu, cnn);
            cnn.Open();

            //cmd.Parameters.AddWithValue("@an", 1);
            //cmd.Parameters.AddWithValue("@al", 2);
            cmd.Parameters.AddWithValue("@kn", 2);

            SqlDataReader dr = cmd.ExecuteReader();//burda patlıyor

            cmd.ExecuteNonQuery();

            dr.Read();
            int x=dr.GetInt16(0);
            dr.Close();
            cnn.Close();

            Console.WriteLine(x);
            Console.ReadLine();

            /*
             * bu sefe ryeni srogu yaalım, çoklu okusun, sqldatereader kayıtları tek tek okur
             * bu sefer using içinde yap
            while (dr.Read())
            {

            }*/
        }
    }
}

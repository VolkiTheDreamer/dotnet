using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataBaseİşlemleri
{
    public partial class Form2 : Form
    {
     

        public Form2()
        {
            InitializeComponent();
        }
#region updateler
        private void button1_Click(object sender, EventArgs e)
        {
            
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");
            conn.Open();
            string input = Microsoft.VisualBasic.Interaction.InputBox("1.id ne olsun", "Title", "Default", -1, -1);
            var mysql = "Update Kalemler Set KALEMADI='" + input + "' where [KALEM NO]=1";
            OleDbCommand cmd= new OleDbCommand(mysql, conn);
            
            int a = cmd.ExecuteNonQuery();
            MessageBox.Show(a + " kayıt güncellendi");
            conn.Close();
            cmd.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");
            conn.Open();
            string input = Microsoft.VisualBasic.Interaction.InputBox("1.id ne olsun", "Title", "Default", -1, -1);
            var mysql = "Update Kalemler Set KALEMADI='" + input + "' where [KALEM NO]=2";
            OleDbDataAdapter da = new OleDbDataAdapter();
            
            da.UpdateCommand = new OleDbCommand(mysql, conn);
            int a = da.UpdateCommand.ExecuteNonQuery();
            
            MessageBox.Show(a + " kayıt güncellendi");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");
            
            OleDbDataAdapter da = new OleDbDataAdapter("select * from KALEMLER",conn);       
            DataSet ds= new DataSet();

            string input = Microsoft.VisualBasic.Interaction.InputBox("3.id ne olsun", "Title", "Default", -1, -1);
            da.Fill(ds); //taboda primary key olmalı
            ds.Tables[0].Rows[3]["KALEMADI"] = input;
            OleDbCommandBuilder adıneolursaolsun = new OleDbCommandBuilder(da);
            da.Update(ds.Tables[0]); //hata alıyorum
            MessageBox.Show("kayıt güncellendi");
        }

        private void button7_Click(object sender, EventArgs e)
        {
       
            MessageBox.Show("datarow vers,ynu yok");
        }


        #endregion

        #region insertler
        private void button6_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into KALEMLER ([KALEM NO],KALEMADI) Values (@id, @ad)";
            cmd.Connection = conn;
            conn.Open();
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("işlem tamam");
            conn.Close();
            cmd.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");

            OleDbDataAdapter da = new OleDbDataAdapter("select * from KALEMLER", conn);
            
            DataSet ds = new DataSet();

            da.Fill(ds, "KALEMLER");

            DataRow dr = ds.Tables[0].NewRow();
                dr["KALEM NO"] = Convert.ToInt32(textBox1.Text);
                dr["KALEMADI"] = textBox2.Text;

            ds.Tables[0].Rows.Add(dr);

            OleDbCommandBuilder scbStoreItem = new OleDbCommandBuilder(da);
            da.Update(ds.Tables[0]); //insert into statement hatası
            MessageBox.Show("kayıt eklendi");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");
            conn.Open();
            
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.InsertCommand = new OleDbCommand("insert into KALEMLER ([KALEM NO],KALEMADI) Values (@id,@ad)", conn);
            da.InsertCommand.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text)); //Nesne başvurusu bir nesnenin örneğine ayarlanmadı.'
            da.InsertCommand.Parameters.AddWithValue("@ad", textBox2.Text);
            int a =da.InsertCommand.ExecuteNonQuery();

            MessageBox.Show(a + " kayıt eklendi");
            conn.Close();
        }

        #endregion

       

        
    }
}

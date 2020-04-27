using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Diagnostics;

namespace DataBaseİşlemleri
{
    //using kullan
    //exectureadera int ata, update yapınca
    //importlanmış DB de kullanalım
    //databbindn de kullanalım
    //büyük DB importlı dene, databalela dene, databalelı ama no con.openla dene, hepsini süresini ölç
    //listview da yap
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection globalCon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veri_tabanıDataSet.ozlu' table. You can move, or remove it, as needed.
            this.ozluTableAdapter.Fill(this.veri_tabanıDataSet.ozlu);

            SütunGenişlikAyarla();
            //globalCon.Open();
        }

        private void SütunGenişlikAyarla()
        {
            ozluDataGridView.Columns[0].Width = 40;
            ozluDataGridView.Columns[1].Width = 200;
            ozluDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ozluDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ozluDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ozluDataGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView11.Columns[0].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView11.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView11.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            // dataGridView11.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView11.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGridView11.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //dataGridView11.AutoResizeColumns();
            //dataGridView11.AllowUserToResizeColumns = true;
            //dataGridView11.AllowUserToOrderColumns = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb"))
            {
                label1.Text = conn.State.ToString()+"-";
                conn.Open();
                label1.Text = conn.State.ToString() + "-";
                OleDbCommand cmd = new OleDbCommand("Select * from  KALEMLER", conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dataGridView1.DataSource = dt;               
            }
            
            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label1.Text += elapsed_time.ToString(); //burası hata verir çünkü artık conn öldü: +"-"+ conn.State.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Volkan\OneDrive\Uygulama Geliştirme\Visual Studio\Örnekler\Ornek.accdb"))
            {
                label2.Text = conn.State.ToString() + "-";
                conn.Open();
                label2.Text = conn.State.ToString() + "-";
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("Select * from  KALEMLER", conn);//burda oledbcommand da yaratabilrdik ama string yeterli
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                
            }
            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label2.Text += elapsed_time.ToString(); //burası hata verir çünkü artık conn öldü: +"-"+ conn.State.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //usingsiz örnek: global connection tanımı yapıldıysa anlamlıdır, zira wrap edemezsin artık. bunda manuel
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            label3.Text = globalCon.State.ToString() + "-";
            if (globalCon.State != ConnectionState.Open)
            {
                globalCon.Open();
            }
            label3.Text += globalCon.State.ToString() + "-";
            OleDbCommand cmd = new OleDbCommand("Select * from  [Nakdi YTL+YP]", globalCon);
            OleDbDataReader rd = cmd.ExecuteReader(CommandBehavior.CloseConnection); //bunu demezsem manuel kapatmam lazım
            DataTable dt = new DataTable();
            dt.Load(rd);
            dataGridView3.DataSource = dt;

            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label3.Text += elapsed_time.ToString() +"-"+ globalCon.State.ToString();
            MessageBox.Show("bikez daha tıklayınca benzer süre ssürüyor");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
         
            label4.Text = globalCon.State.ToString() + "-";
            if (globalCon.State != ConnectionState.Open)
            {
                globalCon.Open();
            }
            label4.Text = globalCon.State.ToString() + "-";
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from  [Nakdi YTL+YP]", globalCon);//burda oledbcommand da yaratabilrdik ama string yeterli
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            
            
            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label4.Text += elapsed_time.ToString()+"-"+ globalCon.State.ToString();
            MessageBox.Show("bikez daha tıklayınca benzer süre ssürüyor");
        }



        private void button5_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            label5.Text = globalCon.State.ToString() + "-";
            //if (globalCon.State != ConnectionState.Open)
            //{
            //    globalCon.Open();
            //}
            label5.Text = globalCon.State.ToString() + "-";
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from  [Nakdi YTL+YP]", globalCon);//burda oledbcommand da yaratabilrdik ama string yeterli
            da.Fill(dt);
            dataGridView5.DataSource = dt;


            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label5.Text += elapsed_time.ToString() + "-" + globalCon.State.ToString();
            MessageBox.Show("bikez daha tıklayınca benzer süre ssürüyor. Bu arada con.Open yapmamş olmanın hiçbir etkisi olmadı");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            label6.Text = globalCon.State.ToString() + "-";
            if (globalCon.State != ConnectionState.Open)
            {
                globalCon.Open();
            }
            label6.Text = globalCon.State.ToString() + "-";
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from  ANADATA", globalCon);//burda oledbcommand da yaratabilrdik ama string yeterli
            da.Fill(dt);
            dataGridView6.DataSource = dt;


            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label6.Text += elapsed_time.ToString() + "-" + globalCon.State.ToString();
            MessageBox.Show("Uzun sürdü, bikez daha tıklayınca yine uzun sürdü");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            label7.Text = globalCon.State.ToString() + "-";
            //if (globalCon.State != ConnectionState.Open)
            //{
            //    globalCon.Open();
            //}
            label7.Text = globalCon.State.ToString() + "-";
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from  ANADATA", globalCon);//burda oledbcommand da yaratabilrdik ama string yeterli
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            


            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;
            label7.Text += elapsed_time.ToString() + "-" + globalCon.State.ToString();
            MessageBox.Show("uzun. open 'ın etkisi yok. ikinci kez");
        }



        private void button8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        

        private void ozluBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ozluBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.veri_tabanıDataSet);

        }
    }
}

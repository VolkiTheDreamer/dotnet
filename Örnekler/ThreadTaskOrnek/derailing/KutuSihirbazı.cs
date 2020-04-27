using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace ThreadOrnek
{
    public partial class KutuSihirbazı : Form
    {
        public KutuSihirbazı()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {            
            await Yarat();
           this.Text = DateTime.Now.Second.ToString();//Yarat bitmeden buna gelmez. Bunun olduğu version için parelel düğmesie bak
        }

  
        private Task Yarat()
        {
            Task ts = Task.Run(() =>
            {
                PictureBox pic = new PictureBox();
                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.Controls.Add(pic);
                    });
                }
                

                Random rand = new Random(DateTime.Now.Millisecond);
                int x = 0; // rand.Next(45, this.Width / 2);
                int y = rand.Next(45, this.Height / 2);
                pic.Location = new Point(x, y);
                pic.Height = 60;
                pic.Width = 85;

            
                var files = Directory.GetFiles(@"C:\Users\volka\Desktop\New folder");
                pic.ImageLocation = files[rand.Next(files.Length)];
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                int randomno = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (!checkBox1.Checked)
                    {
                        randomno = rand.Next(-5, 5);
                    }
                    else
                    {
                        randomno = 0;
                    }
                    pic.Location = new Point(pic.Location.X + rand.Next(1,10), pic.Location.Y+randomno);
                    Thread.Sleep(20);
                }
            });
            return ts;
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                PictureBox pic = new PictureBox();
                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this.Controls.Add(pic);
                    });
                }

                                
                pic.Location = new Point(250, 800);
                pic.ImageLocation = @"C:\Users\volka\Desktop\New folder\lazer\lazer.png";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Width = 2;
                //Random rand = new Random(DateTime.Now.Millisecond);
                int j = 0;
                j = string.IsNullOrEmpty(this.textBox1.Text) ? 0 : int.Parse(this.textBox1.Text);
                for (int i = 0; i < 1000; i++)
                {                   
                    pic.Location = new Point(pic.Location.X+j, pic.Location.Y - 5);
                    Thread.Sleep(20);
                    j = 0;
                }
            });
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Button2_Click(null, null);
            }
        }
    }
}

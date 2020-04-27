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
                int x = rand.Next(45, this.Width / 2);
                int y = rand.Next(45, this.Height / 2);
                pic.Location = new Point(x, y);
                pic.Height = 20;
                pic.Width = 20;

                pic.ImageLocation = @"E:\OneDrive\Uygulama Geliştirme\Visual Studio\Gerçek Projeler\SelfMemory\SelfMemory\Resources\ÇizgiFilm Kahramanı_hulk.jpg";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                for (int i = 0; i < 150; i++)
                {
                    pic.Location = new Point(pic.Location.X + 1, pic.Location.Y);
                    Thread.Sleep(50);
                }
            });
            return ts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PictureBox pic = new PictureBox();
            this.Controls.Add(pic);
            Task t1 = Task.Factory.StartNew(() =>
            {
                Random rand = new Random(DateTime.Now.Millisecond);
                int x = rand.Next(45, this.Width / 2);
                int y = rand.Next(45, this.Height / 2);
                pic.Location = new Point(x, y);
                pic.Height = 20;
                pic.Width = 20;

                pic.ImageLocation = @"E:\OneDrive\Uygulama Geliştirme\Visual Studio\Gerçek Projeler\SelfMemory\SelfMemory\Resources\ÇizgiFilm Kahramanı_hulk.jpg";
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                for (int i = 0; i < 150; i++)
                {
                    pic.Location = new Point(pic.Location.X + 1, pic.Location.Y);
                    Thread.Sleep(50);
                }
            });
            
            Task t2 = Task.Factory.StartNew(()=> { this.Text = DateTime.Now.Second.ToString(); });
            
        }
    }
}

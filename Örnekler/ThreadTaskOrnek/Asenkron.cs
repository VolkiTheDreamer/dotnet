using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadOrnek
{
    public partial class Asenkron : Form
    {
        string logo = "http://www.excelinefendisi.com/images/Untitled.jpg";
        //string logo = "https://1drv.ms/i/s!AsG4Q_Hh_6jbhpYkMvoOMPBEJa7TAg";
        public Asenkron()
        {
            CheckForIllegalCrossThreadCalls = false;//resim yarışıda gerekti,soldakilr için
            InitializeComponent();
        }


        #region stringal

        private void btnNormalString_Click(object sender, EventArgs e)
        {
            DownloadData(); //DownloadData metodunu çağırıyoruz…
            label1.Text = "indirildi";
        }

                private void DownloadData()
                {
                    WebClient wc = new WebClient(); //WebClient Sınıfından yeni bir WebClient nesnesi türetiliyor…
                    string data = wc.DownloadString("http://www.excelinefendisi.com/Default.aspx");
                    //Ürettiğimiz wc isimli nesnenin DownloadString metoduyla w3schools kaynağındaki html kodlarını çekip değişkene aktarıyoruz
                    MessageBox.Show(data);
                }

        private void btnAsyncString_Click(object sender, EventArgs e)
        {
            DownloadDataAsync(); //await keyword’üne dikkat!
            label1.Text = "indiriliyor";

        }

                private async void DownloadDataAsync() //DownloadDataAsync Task’inin asenkron olduğunu async keyword’ü ile belirtiyoruz. Asenkron kullanmak istediğimiz için Task oluşturduk.
                {
                    WebClient wc = new WebClient(); //WebClient Sınıfından yeni bir WebClient nesnesi türetiliyor…
                    string data = await wc.DownloadStringTaskAsync("http://www.excelinefendisi.com/Default.aspx");
                    //Ürettiğimiz wc isimli nesnenin DownloadString metoduyla w3schools kaynağındaki html kodlarını çekip değişkene aktarıyoruz
                    label1.Text = "async indirildi";
                    MessageBox.Show(data);
                }

        private async void btnAsyncString2_Click(object sender, EventArgs e)
        {
            //await DownloadDataAsynctask();
            label1.Text = "indiriliyor";
        }

                //private Task<string> DownloadDataAsynctask() //DownloadDataAsync Task’inin asenkron olduğunu async keyword’ü ile belirtiyoruz. Asenkron kullanmak istediğimiz için Task oluşturduk.
                //{
                //    //Task<string> ts= Task.Run<string>(() =>
                //    //{
                //    //    WebClient wc = new WebClient(); //WebClient Sınıfından yeni bir WebClient nesnesi türetiliyor…
                //    //    string data = wc.DownloadStringTaskAsync("http://www.excelinefendisi.com/Default.aspx");
                //    //            //Ürettiğimiz wc isimli nesnenin DownloadString metoduyla w3schools kaynağındaki html kodlarını çekip değişkene aktarıyoruz
                //    //    label1.Text = "async indirildi";
                //    //    //MessageBox.Show(data);                        
                //    //});
                //    //return ts;
                //}

        #endregion
        #region resim
        private void btnNormalResim_Click(object sender, EventArgs e)
        {
            label2.Text = "iniyor";
  
            for (int i = 0; i < 30; i++)
            {
                pictureBox1.Load(logo);
            }
            label2.Text = "indi";
        }

        private void btnAyncResim_Click(object sender, EventArgs e)
        {
            label2.Text = "iniyor";

            for (int i = 0; i < 30; i++)
            {
                pictureBox1.LoadAsync(logo);
            }

            label2.Text = "indi(erkenden yazar)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label2.Text = "";
        }
        #endregion

        #region sleepm
        private void btnNormalSleep_Click(object sender, EventArgs e)
        {
            NormalMessage(); //NormalMessage metodunu çağırıyoruz…
        }

        private void NormalMessage() //Normal mesaj gösteren metod
        {
            Thread.Sleep(5000);
            MessageBox.Show("İşlem Tamamlandı");
        }

        private async void btnAsyncSleep_Click(object sender, EventArgs e)
        {
            await ShowAsyncMessage(); //ShowAsyncMessage metodunu asenkron olarak çağırıyoruz…
        }

        async Task ShowAsyncMessage() //async keyword’ü ile yeni bir Task türetiyoruz…
        {
            await Task.Run(() => Thread.Sleep(5000)); //5000 milisaniye işlemi durduruyoruz…
            MessageBox.Show("İşlem Tamamlandı");
        }


        #endregion



        #region yarışatı
        private void btnBasla_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            Task t1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    pic1.Location = new Point(pic1.Location.X + r.Next(1, 5), pic1.Location.Y);
                    Thread.Sleep(50);
                }
            }
            );
            Task t2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    pic2.Location = new Point(pic2.Location.X + r.Next(1, 5), pic2.Location.Y);
                    Thread.Sleep(50);
                }
            }
            );
        }
        


        private async void btnBaslaAsync_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(Kutu1Oynat);
            await Kutu2Oynat();
        }
        private async Task Kutu1Oynat()
        {
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {
                pic1.Location = new Point(pic1.Location.X + r.Next(1, 5), pic1.Location.Y);
                Thread.Sleep(50);
            }

        }
        private async Task Kutu2Oynat()
        {
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {
                pic2.Location = new Point(pic2.Location.X + r.Next(1, 5), pic2.Location.Y);
                Thread.Sleep(50);
            }

        }

        #endregion



        private void button7_Click(object sender, EventArgs e)
        {
            AsyncAwait.AnaAsync();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label2.Text="şimdi gerçekten bitti,event ile";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            async3 as3 = new async3();
            as3.Show();
        }
        /*
           yöntemler
           1-Taska isim vererek
           Task ts=Task.Run(()=>{...
           });
           return ts;

           2-.taska isim vermeden,anonim*
           return Task.Run()

           3-veya bu ikisinin Task.Factory.StartNew versiyonu

           4
           */

        private async void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show((await Don(1000, 10000)).ToString());
        }

                Task<double> Don(double BaslangicDegeri, double BitisDegeri)
                {
                    Task<double> islem = Task.Run<double>(() =>
                    {
                        while (true)
                        {
                            if (BaslangicDegeri == BitisDegeri)
                                break;
                            label1.Text = BaslangicDegeri.ToString();
                            BaslangicDegeri++;
                        }
                        return BaslangicDegeri;
                    });

                    return islem;
                }

        private async void button4_Click(object sender, EventArgs e)
        {
            await X();
        }
                Task X()
                {
                    return Task.Run(() =>
                    {
                        int Sayac = 1;
                        while (Sayac<1000)
                        {
                            label1.Text = Sayac.ToString();
                            Sayac++;
                        }
                    });
                }
    }
}

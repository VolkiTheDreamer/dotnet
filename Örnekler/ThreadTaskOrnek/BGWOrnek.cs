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
    public partial class BGWOrnek : Form
    {
        public BGWOrnek()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.WorkerReportsProgress = true;// "true" yapılırsa, BackgroundWorker çalışırken yapılan işlemlerle ilgili, dışarıya anlık, güncel bilgi gönderir. 

            backgroundWorker1.WorkerSupportsCancellation = true;// true ise kullanıcı, BackgroundWorker kontrolünün arka planda yaptığı işi sonladırabilir. Default değeri "false" 'tur. Örneğin programcı olarak ben, arka planda yapılan iş bitmeden, işlemin sonlandırılmasını istemeyebilirim. Bu özelliğin bu opsiyonu sunmasının nedeni de budur. bence saçma: iptal butonu koymam zaten.
        }

        #region BGWile
        private async void btnStart_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            lblSonuc.Text = "5 sn bekleyecek";
            await IndeterministicMetodAsync();
            lblSonuc.Text = "şimdi deterministic başlayacak";
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();//bu metod çağılrınca DoWork eventi trigger olur, yoksa böyle bir metodumuz yok kod içinde. DOWork tetiklnenice de backgroundWorker1_DoWork metodu çağrılır                                
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            for (int i = 1; i <= 10; i++)
            {
                if (backgroundWorker1.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    Thread.Sleep(500);
                    backgroundWorker1.ReportProgress(i * 10);
                }
            }
        }
        private void IndeterministicMetod()
        {
            //bunun yerine async regionı içideki kullanılcak
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }
        //UI'ya  ara ara guncelleme
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label1.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label1.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label1.Text = "Done!";
            }
        }

        #endregion

        #region asyncile
        private async void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            lblSonuc.Text = "5 sn bekleyecek";
            await IndeterministicMetodAsync();
            lblSonuc.Text = "şimdi deterministic başlayacak";

            //şimdi deterministic
            await Task.Run(() =>
            {

                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    label1.Text = (i * 10).ToString() + "%";
                    progressBar1.Value = i * 10;
                }
            });
        }

        private Task IndeterministicMetodAsync()
        {
            return Task.Run(() =>
            {
                //progressBar1.Visible = true;
                Thread.Sleep(5000);
                lblSonuc.Text = "şimdi de 1500e kadar sayacak";
                Thread.Sleep(1000);
                for (int i = 0; i < 1500; i++)
                {
                    lblSonuc.Text = i.ToString();
                }

                //when finished, turn the progresbar into deterministic style
                if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
                {
                    //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        progressBar1.Style = ProgressBarStyle.Continuous;
                    });

                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region TPLile

        private void btnStartTaskile_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            Task taskA = Task.Run(() => IndeterministicMetodTPL());
            Task continuation = taskA.ContinueWith(antecedent =>
            {
                lblSonuc.Text = "şimdi deterministic başlayacak";
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    label1.Text = (i * 10).ToString() + "%";
                    progressBar1.Value = i * 10;
                }
            });
        }

        private void IndeterministicMetodTPL()
        {
            lblSonuc.Text = "5 sn bekleyecek";
            Thread.Sleep(5000);
            lblSonuc.Text = "şimdi de 1500e kadar sayacak";
            Thread.Sleep(1000);
            for (int i = 0; i < 1500; i++)
            {
                lblSonuc.Text = i.ToString();
            }

            //when finished, turn the progresbar into deterministic style
            if (this.InvokeRequired) //Forma gelen talebin farklı bir iş parçacığından gelip gelmediği kontrol ediliyor.
            {
                //Eğer farklı bir iş parçacığından talep gelmişse aşağıdaki Invoke metoduyla işlem gerçekleştiriliyor.
                this.Invoke((MethodInvoker)delegate ()
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                });

            }
        }
        #endregion


    }
}

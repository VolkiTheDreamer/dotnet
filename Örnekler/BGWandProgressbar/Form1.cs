using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace BGWandProgressbar
{
    public partial class Form1 : Form
    {
        public Form1()
        {            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            backgroundWorker1.WorkerReportsProgress = true;
            //progressBar1.Visible = false;//this part must be uncommented 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///*****i first want to call IndeterministicMetod without freezeing UI************
            //IndeterministicMetod();//UI freezes
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();     
            }
        }

        private void IndeterministicMetod()
        {
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 500;

            //just imitating. real one would be something like searching whole folders
            System.Threading.Thread.Sleep(5000);
            
            //when finished, turn the progresbar into deterministic style
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.MarqueeAnimationSpeed = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {            
            DeterministicMetod(e);
        }
        private void DeterministicMetod(DoWorkEventArgs e)
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
                    System.Threading.Thread.Sleep(500);
                    backgroundWorker1.ReportProgress(i * 10);
                    
                }
            }

        }       
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = (e.ProgressPercentage.ToString() + "%");
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                label3.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                label3.Text = "Error: " + e.Error.Message;
            }
            else
            {
                label3.Text = "Done!";
            }
        }



        #region ornke2
        private async void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            label3.Text = "5 sn bekleyecek";
            await IndeterministicMetodAsync();
            label3.Text = "şimdi deterministic başlayacak";
            
            //şimdi deterministic
            await Task.Run(() => {
                
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    label1.Text = (i*10).ToString() + "%";
                    progressBar1.Value= i*10;                    
                }
            } );
        }

        private Task IndeterministicMetodAsync()
        {
            return Task.Run(() =>
            {
                //progressBar1.Visible = true;
                System.Threading.Thread.Sleep(5000);
                label3.Text = "şimdi de 1500e kadar sayacak";
                System.Threading.Thread.Sleep(1000);
                for (int i = 0; i < 1500; i++)
                {
                    label3.Text = i.ToString();
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

       

        #endregion

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thread2_backgroundworker
{
    public partial class Form1 : Form
    {
        private double sayi = 0;
        
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            BW_Baslat();
            progressBar1.Maximum = 100;

            // Tell backgroundWorker to support cancellations
            this.backgroundWorker1.WorkerSupportsCancellation = true;

            // Tell backgroundWorker to report progress
            this.backgroundWorker1.WorkerReportsProgress = true;
        }

        private void BW_Baslat()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }
                
        private void btnStart_Click(object sender, EventArgs e)
        {            
            label1.Text = String.Empty;            
            btnStart.Enabled = false;
            textBox1.Enabled = false;
            btnStop.Enabled = true;
            sayi = double.Parse(textBox1.Text);
            backgroundWorker1.RunWorkerAsync(sayi);
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double sonuc = 0;
            lblSayi.Text = "";
            double s = (double)e.Argument;
            for (int i = 0; i < s; i++)
            {
                sonuc += i;
                lblSayi.Text = i.ToString();//labelda i
                this.Text = sonuc.ToString();//form başlığında sonuç

                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                System.Threading.Thread.Sleep(1000);
                if (i % (s / 100) == 0)
                {
                    backgroundWorker1.ReportProgress(i * 100 / (int)s);
                }
            }


        }

      
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
                label1.Text = "Canceled";
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                //    label1.Text = e.Result.ToString();//hata olursa "iş btti"
                label1.Text = "bitti";
            }

            // Enable the UpDown control.
            this.textBox1.Enabled = true;

            // Enable the Start button.
            btnStart.Enabled = true;

            // Disable the Cancel button.
            btnStop.Enabled = false;
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.
            this.backgroundWorker1.CancelAsync();
           

            // Disable the Cancel button.
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            label1.Text = "İptal";
            this.progressBar1.Value = 0;            
            lblSayi.Text = "";
            this.Text = "";
        }

       

      
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox1.Clear();
        }
    }
}

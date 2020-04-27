using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VolkansBatchRenamer
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// küçük büüyk harf?
        /// </summary>
        private static string adres;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKlasor_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowDialog();
            adres = fb.SelectedPath;
            lblKlasor.Text = fb.SelectedPath;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(adres);
            FileInfo[] finfos = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo f in finfos)
            {
                File.Move(f.FullName, f.DirectoryName + "\\"+ txtSuffixorPrefix.Text + f.Name);
            }
            //işlem yapılan dosya adedini yazmak lazım
            //MessageBox.Show(finfos.Length + " dosyanın başına "+ txtSuffixorPrefix.Text + " eklendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(adres);
            FileInfo[] finfos = di.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo f in finfos)
            {
                File.Move(f.FullName, f.FullName.Replace(txtOld.Text, txtNew.Text)); 
            }
            //işlem yapılan dosya adedini yazmak lazım
            //MessageBox.Show(finfos.Length + " dosyanın başına " + txtSuffixorPrefix.Text + " eklendi");

        }
    }
}

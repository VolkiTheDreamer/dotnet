using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotDefteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool Degisim;

        private void Form1_Load(object sender, EventArgs e)
        {
            objOpen.Filter = "Text Dosyaları(*.txt)|*.txt|Tüm Dosylar(*.*)|*.*";
            objOpen.FilterIndex = 1;
            objSave.Filter = "Text Dosyaları(*.txt)|*.txt|Tüm Dosyalar(*.*)|*.*";
            objSave.FilterIndex = 1;
        }

        public void KayitMekanizmasi(string strVeri)
        {
            if (objSave.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayitci = new StreamWriter(Environment.GetEnvironmentVariable("mydocuments") + objSave.FileName.ToString(), false, System.Text.Encoding.Unicode);
                Kayitci.Write(strVeri);
                Kayitci.Close();
                Degisim = false;
            }
        }

        public bool DegisimUyari()
        {
            if (MessageBox.Show("Dosyanızda bir değişiklik oldu kaydetmek ister misiniz?", "Değişiklik Var", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                Degisim = false;
                return false;
            }

        }


        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                if (Degisim == false)
                {
                    objText.Clear();

                }
                else
                {
                    if (DegisimUyari())
                    {
                        KayitMekanizmasi(objText.Text);
                        objText.Clear();
                        Degisim = false;
                    }
                    else
                    {
                        objText.Clear();
                        Degisim = false;
                    }
                }
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Degisim == true)
            {
                if (DegisimUyari())
                {
                    KayitMekanizmasi(objText.Text);
                }
            }
            if (objOpen.ShowDialog() == DialogResult.OK)
            {

                FileInfo strKaynak = new FileInfo(Environment.GetEnvironmentVariable("mydocuments") + objOpen.FileName.ToString());
                StreamReader Okuyucu = strKaynak.OpenText();

                objText.Text = Okuyucu.ReadToEnd();
                Degisim = false;
                Okuyucu.Close();
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KayitMekanizmasi(objText.Text);
            Degisim = false;
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void objText_TextChanged(object sender, EventArgs e)
        {
            Degisim = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Degisim == true)
            {
                if (DegisimUyari())
                {
                    KayitMekanizmasi(objText.Text);
                    Close();

                }
            }
            else
            {
                Close();
            }
        }
    }
}

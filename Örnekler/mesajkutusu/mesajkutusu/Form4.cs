using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mesajkutusu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Sonuc;
            Sonuc=MessageBox.Show("Pencere kapatılsın mı?",
            "Kapatma", MessageBoxButtons.AbortRetryIgnore);
            //if (Sonuc == DialogResult.Abort || Sonuc == DialogResult.Ignore)
            if (Convert.ToString(Sonuc) == "Durdur" || Convert.ToString(Sonuc) == "Yoksay")
            {
            e.Cancel = true;
            }
        }


    }
}

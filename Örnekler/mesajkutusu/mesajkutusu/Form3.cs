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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Sonuc;
            Sonuc = MessageBox.Show("Pencere kapatılsın mı?",
            "Kapatma", MessageBoxButtons.YesNoCancel);
            if (Sonuc == DialogResult.No || Sonuc == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}

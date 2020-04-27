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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Sonuc;
            Sonuc = MessageBox.Show("Pencere kapatılsın mı?",
            "Kapatma", MessageBoxButtons.YesNo);
            if (Sonuc == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        
    }
}

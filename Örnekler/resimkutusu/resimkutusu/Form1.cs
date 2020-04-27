using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resimkutus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = System.Drawing.Bitmap.FromFile("C:\\Users\\Volkan\\Dropbox\\Photos\\0_Volkan\\volki1.jpg");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult Sonuc;
            openFileDialog1.Filter = "Resim Dosyaları |*.JPG;*.BMP;*.GIF";
            Sonuc = openFileDialog1.ShowDialog();
            if (Convert.ToString(Sonuc) == "OK")
            {
                string Dosya = openFileDialog1.FileName;
                pictureBox2.Image = System.Drawing.Bitmap.FromFile(Dosya);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Image resim;//Bitmap ile dğeil Image ile çünkü aşağıdaki Bıtmap.FromFile metodu Image tipinde nesne döndürür
            resim = System.Drawing.Bitmap.FromFile("C:\\Users\\Volkan\\Dropbox\\Photos\\0_Volkan\\volki1.jpg");
            pictureBox3.Image = resim;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Bitmap resim;//bir üsttekinin tip dğeişmli versiyonu. bu sefer biptmapla tanımladık ama aşağıda formfiledan dönen imajı bitmapa çevirdik
            resim = (Bitmap)System.Drawing.Bitmap.FromFile("C:\\Users\\Volkan\\Dropbox\\Photos\\0_Volkan\\volki1.jpg");
            pictureBox4.Image = resim;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Icon ikon = new Icon("C:\\Users\\Volkan\\Desktop\\Visual Studio\\warn.ico");
            pictureBox5.Image = ikon.ToBitmap();
        }

  
    }
}

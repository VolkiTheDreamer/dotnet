using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HafızaOyunu
///GENEL BİLGİLER
///statiklerle ilgili 2 tür yaklaşım uygulamdım. aslında ilk yötnemi kullanma sebebim ikncisinin sonrdan aklıma gelmesi. Şöyleki, ana girişte belirlediğin bir seçneğin form classında da geçerli olmsnı istiyordum. bununu için anagirişteki bir değeri önce form classının statik veya instance variablesına atıyordum. 2.yöntemde ise direk statik bir sınf tanımladım, onun üzerinden yönettim.
/// 2.FAZ
///from pc ikiye ayrılsın. klasör or manuel sçeim. from resx de combo yerine resim, okuma yazma bilmeyenler için
///tuple, multimap,lookup veya struct gibi yöntemlerle dil sçeneği ekle
/// delegate ile buton clikc yapmaay çalış. https://stackoverflow.com/questions/6187944/how-can-i-create-dynamic-button-click-event-on-dynamic-button
///kolay orta zor butonlarına görsel de çiz ki okuma yazma iblmeyenler anlasın
///ResimSoldur
{
    public partial class FormAnaGiris : Form
    {
        static string klasorYolu;
        static int gerekliResimAdedi;
        static List<String> lstResimFromResx = new List<string>();
        
        public FormAnaGiris()
        {
            Mystatikclass.sound_durum = true;
            InitializeComponent();
        }
        

        private void btnEasy_Click(object sender, EventArgs e)
        {
            try
            {                
                if (ResimAdetYeterlimi(sender) == false)
                {
                    MessageBox.Show("Bu klasörde yeterli miktarda resim yok. En az " + gerekliResimAdedi.ToString() + " resim olduğunudan emin olup tekrar çalıştırın");
                    return;
                }
                PrepareForm(4, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n"+ex.Message);
            }
        }              

        private void btnMedium_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResimAdetYeterlimi(sender) == false)
                {
                    MessageBox.Show("Bu klasörde yeterli miktarda resim yok. En az " + gerekliResimAdedi.ToString() + " resim olduğunudan emin olup tekrar çallışıtırın");
                    return;
                }
                PrepareForm(5, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        private void btnDifficult_Click(object sender, EventArgs e)
        {
            try
            {
                if (ResimAdetYeterlimi(sender) == false)
                {
                    MessageBox.Show("Bu klasörde yeterli miktarda resim yok. En az " + gerekliResimAdedi.ToString() + " resim olduğunudan emin olup tekrar çallışıtırın");
                    return;
                }
                PrepareForm(6, 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }

        }

        private void PrepareForm(int x,int y)
        {
            try
            {
                FormOyun fo = new FormOyun();
                fo.NumberOfBoxX = x;
                fo.NumberOfBoxY = y;
                if (rbPicFromPC.Checked==true)
                {
                    fo.PicPath = klasorYolu;//rbPicFromPC_CheckedChanged'den gelecek
                }
                else
                {
                    fo.ResimKategori = cbKategoriler.Text;
                }
                this.Hide();
                fo.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Lütfen geçerli bir klasör seçin");                                
                Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbPicFromPC_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbPicFromPC.Checked == true)
                {
                    FolderBrowserDialog Klasor = new FolderBrowserDialog();
                    Klasor.ShowDialog();
                    klasorYolu = Klasor.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        private bool ResimAdetYeterlimi(object sender)
        {
            try
            {
                if (rbPicFromPC.Checked == true)
                {
                    DirectoryInfo di = new DirectoryInfo(klasorYolu);
                    FileInfo[] finfos = di.GetFiles("*.jpg", SearchOption.AllDirectories).Union(di.GetFiles("*.png", SearchOption.AllDirectories)).Union(di.GetFiles("*.bmp", SearchOption.AllDirectories)).Union(di.GetFiles("*.gif", SearchOption.AllDirectories)).ToArray();
                    /*var finfos = Directory.GetFiles(klasorYolu, "*.*", SearchOption.AllDirectories)
                                .Where(s => s.EndsWith(".mp3") || s.EndsWith(".jpg"));*/

                    switch (((Button)sender).Name)
                    {
                        case "btnEasy":
                            gerekliResimAdedi = 6;
                            break;
                        case "btnMedium":
                            gerekliResimAdedi = 10;
                            break;
                        case "btnDifficult":
                            gerekliResimAdedi = 15;
                            break;
                    }

                    if (finfos.Length < gerekliResimAdedi)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else //program resorucetan seçilecekse zaten yeterlidir
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
                return false;
            }
        }

        private void picBoxSound_Click(object sender, EventArgs e)
        {
            if (Mystatikclass.sound_durum == true)
            {
                Mystatikclass.sound_durum = false;
                picBoxSound.Image = (Image)Properties.Resources.soundoff;
            }
            else
            {
                Mystatikclass.sound_durum = true;
                picBoxSound.Image = (Image)Properties.Resources.sound;
            }
        }
    }
}

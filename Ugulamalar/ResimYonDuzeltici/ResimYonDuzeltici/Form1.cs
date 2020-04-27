using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// düzeltmeyi yapmıyr
        /// silme işlemini yapmıyor
        /// cheklistboxta tıklandıgında ters göstemriyor düz gösteiyor enden
        /// </summary>
        //not koyalım:sadece EXIF verisi olanlar için işlem yapar, detay bilgi koy şuaradan:http://www.ryadel.com/en/change-image-orientation-iphone-andor-android-phone-pics-net-c/
        List<String> extensions = new List<String>();

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;//bw için lazım
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            extensions.Add("*.jpg");
            extensions.Add("*.png");
            extensions.Add("*.gif");
            extensions.Add("*.bmp");
            extensions.Add("*.tif");
        }

        private void btnKlasor_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lstKlasorler.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            btnDur.Visible = true;            
            btnDuzelt.Visible = false;            

            if (!backgroundWorker1.IsBusy) //meşgulse ikinci kez başaltmasın
            {
                this.backgroundWorker1.RunWorkerAsync();
            }                
        }
        private void btnDur_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) //cancel edilecek bir durum varsa çalışssın
            {
                lblSonuc.Text = "Tarama iptal ediliyor, bekleyiniz...";//bunu buraya yazmak lazım çünkü hemen iptal etmiyor, edene kadar bu çıksın
                this.backgroundWorker1.CancelAsync();
            }
        }
        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult a = MessageBox.Show("Emin misiniz?", "Dikkat...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (a == DialogResult.No)
                {
                    return;
                }

                if (chklstSonuc.CheckedItems.Count > 0)//silinecek dosya varsa çalışır. items demedim, checkeditems dedim, çünkü belki bişeyler olcak ama işaretlenmediyse çalışmasın
                {
                    pictureBox2.Image = null;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    foreach (var item in chklstSonuc.CheckedItems)
                    {
                        string dsy = item.ToString();
                        //var img = Image.FromFile(dsy); //bu kısımla olamdı çünkü dosyyaı sildirmedi, fs yöntemi ile ilerleyince oldu. Detay:http://stackoverflow.com/questions/1036115/c-sharp-gdi-overwriting-an-image-using-save-method-of-bitmap
                                                
                        FileStream fs = new FileStream(dsy, FileMode.Open);
                        var img = Image.FromStream(fs);

                        //aynı resimle ikinci kez işlem yaptığnda hata vermemsi için, "özellik varsa" kontrolü koy
                        switch ((int)img.GetPropertyItem(274).Value[0])
                        {
                            //case 1i almaya gerek yok zira sadece 1den farklı olanlar geliyor
                            case 2:
                                img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                                break;
                            case 3:
                                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                                break;
                            case 4:
                                img.RotateFlip(RotateFlipType.Rotate180FlipX);
                                break;
                            case 5:
                                img.RotateFlip(RotateFlipType.Rotate90FlipX);
                                break;
                            case 6:
                                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                break;
                            case 7:
                                img.RotateFlip(RotateFlipType.Rotate270FlipX);
                                break;
                            case 8:
                                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                                break;
                        }
                        img.RemovePropertyItem(274);//artık bu özelliği kullanmaya gerek yok, o yüzden uçuruyoruz
                        //foreach (var prop in img.PropertyItems)
                        //{
                        //    if (prop.Id == 274) //value of EXIF
                        //    {
                        //        prop.Value[0] = 1;
                        //        img.SetPropertyItem(prop);
                        //    }
                        //}
                        ImageFormat frmt = img.RawFormat;
                        fs.Close();
                        File.Delete(dsy);
                        img.Save(dsy, ImageFormat.Jpeg);
                        //img.Save(Path.GetDirectoryName(dsy)+"\\"+Path.GetFileNameWithoutExtension(dsy)+1+Path.GetExtension(dsy), frmt);                       
                        img.Dispose();
                    }
                    lblSonuc.Text = "Dosyalar başarıyla düzeltildi...";
                }
                else
                {
                    MessageBox.Show("En az 1 dosya seçmelisiniz.");
                }

            }
            catch (Exception ex)
            {
                lblSonuc.Text = ex.Message;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //aktifpasif(false);
                chklstSonuc.Items.Clear();//yine aynı şekilde olası önceki taramadan önce cheklisti bi boşaltalım
                int taranan = 0;
                int no_duz = 0;

                //Belirtilen klasörlerdeki tüm dosyaları listeye ekleyelim
                List<string> tumDosyaList = new List<string>();//bunun için bir list tanımlıyorum
                for (int i = 0; i < lstKlasorler.Items.Count; i++)//listedeik tüm klasölrer için şunları yap
                {
                    //her uzantı türü için ayrı ayrı arıyoruz
                    foreach (string x in extensions)
                    {

                        IEnumerable<string> files = klasor_tara((string)lstKlasorler.Items[i], backgroundWorker1, e);
                        
                            foreach (string file in files)
                            {
                                if (Path.GetExtension(file).ToLower() == x.Substring(1))
                                {
                                    tumDosyaList.Add(file);
                                }
                            }                        
                    }

                }
                taranan = tumDosyaList.Count;

                //şimdi de esas bulma işlemini yapalım
                foreach (string file in tumDosyaList)
                {
                    Bitmap bmp = new Bitmap(file);
                    if (yonu_yamukmu(bmp)) chklstSonuc.Items.Add(file);
                    bmp.Dispose();//bellek yetersiz dediği için
                }

                no_duz = chklstSonuc.Items.Count;
                lblSonuc.Text= String.Format("{0} adet dosya tarandı, {1} adet düz olmayan dosya bulundu.", taranan, no_duz);
            }
            catch (Exception ex)
            {
                lblSonuc.Text = ex.Message;
            }


        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {            
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {                
                lblSonuc.Text = "Bir hata oldu: " + e.Error.Message;
            }
            else if (e.Cancelled)
            {
                //pnlProgress.Visible = false;
                lblSonuc.Text = "Tarama iptal edildi";
                //lblProgress.Text = string.Empty;
                //progressBar1.Value = 0;
            }
            else
            {
                if (chklstSonuc.Items.Count > 0)
                {
                    btnDuzelt.Visible = true;
                    btnDur.Visible = false;
                }

            }
            //aktifpasif(true);
        }
                
        #region "Fonksyionlar"

        private bool yonu_yamukmu(Bitmap img)
        {
            bool b = false;
            if (Array.IndexOf(img.PropertyIdList, 274) > -1) //EXIF özelliği varsa, 8 seçenekli bir dizi döndürür, -1 ise boştur yani özellik yoktur
            {
                switch ((int)img.GetPropertyItem(274).Value[0])
                {
                    case 1:
                        b= false;
                        break;
                    default:
                        b = true;
                        break;
                }
            }
            return b;
        }

        private void aktifpasif(bool b)
        {
            foreach (Control ctr in this.Controls)
            {
                if (!(ctr.Name == "lblSonuc") & !(ctr.Name == "pnlProgress"))
                {
                    ctr.Enabled = b;
                }
            }
            btnDur.Enabled = !b;
        }
        private static IEnumerable<string> klasor_tara(string root, BackgroundWorker b, DoWorkEventArgs e, string pattern = "*")
        {
            var todo = new Queue<string>();
            todo.Enqueue(root);
            while (todo.Count > 0)
            {
                string dir = todo.Dequeue();
                string[] subdirs = new string[0];
                string[] files = new string[0];
                try
                {
                    subdirs = Directory.GetDirectories(dir);
                    files = Directory.GetFiles(dir, pattern);
                }
                catch (IOException)
                {
                }
                catch (System.UnauthorizedAccessException)
                {
                }

                foreach (string subdir in subdirs)
                {
                    todo.Enqueue(subdir);
                }
                foreach (string filename in files)
                {
                    yield return filename;
                }

                if (b.CancellationPending)
                {
                    e.Cancel = true;
                    b.ReportProgress(0);
                    break;
                }
            }
        }

        #endregion

        private void chklstSonuc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            pictureBox2.Image = null;
            if (chkTumu.Checked == true)//tümünü seç tıklanarak buraya geldiyse, bişey yapmasın
            {
                return;
            }

            if (e.NewValue == CheckState.Checked) //sadece tick konuyorsa çalışsın, tick kalkıyorsa bişey yok
            {
                string dsy = chklstSonuc.SelectedItem.ToString();
                var img = Image.FromFile(dsy);
                pictureBox2.Image = img;
            }

        }

        private void chkTumu_CheckedChanged(object sender, EventArgs e)
        {
            bool b = chkTumu.Checked;
            for (int i = 0; i < chklstSonuc.Items.Count; i++)
            {
                chklstSonuc.SetItemChecked(i, b);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }
}

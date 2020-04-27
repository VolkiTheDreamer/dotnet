using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;

/// <summary>
/// design time sırasında kriter seçimlerini ben belirledim, şunlar seçili, bunlar enabled v.s olsun die
/// ancak uzantı listesini runtimeda dictioanry ile yaptırıyorum çünkü, bunun bir de lookup listesinin olması gerkeiyor, ki bu design time sırasında yapılamaz.
/// BURAYA DEVAM ETTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
/// </summary>
namespace DuplikeFinder2
{
    /*SON SAĞLAM YEDEK.
    --chklstsonucta itemcheck ve slectedchagne?
     --comment ve stringlerdeki tapajlar, try cathler, label ve msh-box 
     --enable,visible,labellardaki mesajların zamnalmaası, hatalarda uygun mesaj veya başa dönüş v.s         

   2.faz
   -klasör tarama sırasında marqeuu yapalım--thread, task, async....
   -tüm uznatıla seçiliyse diğerleri pasif olsun, if item1 .cheked, diğerlerine tıklandıgında mesaj çıakrsın, disabl etme diye bi seçenek yok
   - FİLE MENÜSÜ, YARDIM V.S--2.versiyonda neler olacak belirt
   - Her percentage oluşta disable oaln bazı controller opaqlık artsın    
   -timer ekle ama thread.timer
   -progress paneli kaybloacagına 0a dogru rollback yapsın, dögüye sok -1 -1 geri girsin
   //chkhas işareltedimiyi this, base v.s ile yaz--(CheckBox)sender
   //chkhas işareltenince yaılan tru ve falseları döngü ile yap, bi de toggle mantıgı olursa şık olur
   //kriter seçimi için dict kullnadık ya bunu Delegate ile yapılabilir mi incelenecek)

   3.faz
   -WPF'te yap, orjinali treeviw ile tepede ap, duplikeler bi alt kutuda identli gelsin
   -müzikse tıkladığında çalsın v.s  
   -bunu sınıf, struct, propert, interface, delgate v.s ile yapması daha kolay olur mu?
   -İngilizcev versiyon için, başta bi dictionary, sonra bi function yap, heryerde functionu çağır
   */


    public partial class Form1 : Form
    {
        //global fieldları tanımlayalım        
        Dictionary<CheckBox, object> dict_chb = new Dictionary<CheckBox, object>();//hangi kriterler seçilmiş, bunu birsürü if and/or ile yakalamak yerine dict yaptım. value parametresi objedir çünkü, içine string olan dosya adı da, long olan boyut da, date olan lastwritetiem da eklenebilecek.(Delegate ile yapılabilir mi incelenecek)
        Dictionary<string, string> dict_extension = new Dictionary<string, string>();//extensionların lookupı        
        Dictionary<string, string> dict_uniqeFiles = new Dictionary<string, string>();//orjinal dosya ve kriter ikilisini koydugum dict
        Dictionary<string, string> dict_mukerrer = new Dictionary<string, string>();//mukerrerlerin adını ve kriterini koydugu dict
        Dictionary<string, long> dict_boyutlmt = new Dictionary<string, long>();//numeric updowndan gelen veriyi almak için, Ör:KB-->1024le çarp

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;//bw için lazım
            InitializeComponent();
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
            lblProgress.BringToFront();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //öncelikle uzantı dict'ini dolduralım
            dict_extension.Add("Tüm Dosyalar", "*.*");
            dict_extension.Add("Resim Dosyaları(*.jpg, *.png, *.gif, *.bmp,*.tif)", "*.jpg,*.png,*.gif,*.bmp,*.tif");
            dict_extension.Add("Müzik Dosyaları(*.mp3, *.wma, *.wav)", "*.mp3,*.wma,*.wav");
            dict_extension.Add("Video Dosyaları(*.mp4, *.mpg, *.avi, *.vob, *.dat)", "*.mp4,*.mpg,*.avi,*.vob,*.dat");
            dict_extension.Add("Office Dosyaları(*.doc*, *.xls*, *.ppt*, *.mdb, *.accdb)", "*.doc*,*.docx,*.doct,*.xls,*.xlsx,*.xlsm,*.xlsb,*.ppt,*.pptx,*.mdb,*.accdb");
            dict_extension.Add("Metin dosyaları(*.txt, *.rtf*, *.csv)", "*.txt,*.rtf,*.csv");
            dict_extension.Add("Diğer(*.zip, *.rar, *.torrent, *.bak)", "*.zip,*.rar,*.torrent,*.bak");

            //şimdi uznatı chklistboxını bu dictionary ile dolduralım
            foreach (var item in dict_extension)
            {
                chklstUzanti.Items.Add(item.Key);
            }
            //ilk seçeneği seçtirelim
            chklstUzanti.SetItemChecked(0, true);//ilk item, yani tüm dosyalar demek

            //şimdi de dosya boyut dictini halledelim
            int lt = 0;
            foreach (var item in comboBox1.Items) //combo2 de olabilirdi, farketmez, ikisi de aynı
            {
                dict_boyutlmt.Add(item.ToString(), Convert.ToInt64(Math.Pow(1024, lt)));
                lt++;
            }
        }
        private void chkHash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHash.Checked == true)

            {
                chkAd.Checked = false;
                chkAd.Enabled = false;
                chkTarih.Checked = false;
                chkTarih.Enabled = false;
                chkBoyut.Checked = false;
                chkBoyut.Enabled = false;
                MessageBox.Show("Seçeneğin üzerinde bekleyin ve çıkan baloncuktaki mesajı dikkatle okuyun", "ÖNEMLİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                chkAd.Checked = true;
                chkAd.Enabled = true;
                chkTarih.Checked = true;
                chkTarih.Enabled = true;
                chkBoyut.Checked = true;
                chkBoyut.Enabled = true;
            }

        }

        private void btnTara_Click(object sender, EventArgs e)
        {
            pnlProgress.Visible = true;//bunları Dowork içinde C maddesinin altına koymustum ama orda işe yaramıyorlar, şimdilik burda kalsın, thread/task olayını yapınca oraya laırım. oraya lamam lazım çünkü bazen erken yere göükmüş oluyorlar
            progressBar1.Value = 0;
            btnDur.Visible = true;
            pnlResim.Visible = false;
            btnSil.Visible = false;
            pnlCheckSonuc.Visible = false;

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
        private void btnSil_Click(object sender, EventArgs e)
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
                    picSecilen.Image = null;
                    picOrjinal.Image = null;
                    GC.Collect();//pitureboxları null yapıp resimleri kullanımdan alsam bile hafzıdan tam silinmedikleri için hala kullanımdalar. o yüzden GC'ü çağırıyorum
                    GC.WaitForPendingFinalizers();

                    for (int s = 0; s < chklstSonuc.CheckedItems.Count; s++)
                    {
                        File.Delete(chklstSonuc.CheckedItems[s].ToString());
                        chklstSonuc.Items.Remove(chklstSonuc.CheckedItems[s]);
                        s--;
                    }
                    lblSonuc.Text = "Dosyalar başarıyla silindi...";
                    pnlResim.Visible = false;
                    lblOrjinalKonum.Text = "Not:Orjinalini görmek için yukardan bir dosyayı işaretleyiniz";
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

        private void btnKlasor_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lstKlasorler.Items.Add(folderBrowserDialog1.SelectedPath);
            }
        }
        private void btnKlsSecimClean_Click(object sender, EventArgs e)
        {
            lstKlasorler.Items.Clear();
        }
        private void btnKlasorSecilenClean_Click(object sender, EventArgs e)
        {
            if (lstKlasorler.Items.Count > 0) //klasör boşken yanlışlıkla bastığında çalışmasın diye
            {
                if (lstKlasorler.SelectedIndex != -1) //seçim yapılmadıysa çalışmasın
                {
                    lstKlasorler.Items.RemoveAt(lstKlasorler.SelectedIndex);
                }
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
        private void chkUzantiekle_CheckedChanged(object sender, EventArgs e)
        {
            bool chkUzDurum = chkUzantiekle.Checked;
            txtUzantekle.Visible = chkUzDurum;
        }
        private void txtUzantekle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chklstUzanti.Items.Add("(*." + txtUzantekle.Text + ")");
                dict_extension.Add("(*." + txtUzantekle.Text + ")", "*." + txtUzantekle.Text);
                chklstUzanti.Focus();
            }
        }
        private void chkMinSize_CheckedChanged(object sender, EventArgs e)
        {//aynı zamanda maxsize için de event handlerdır
            CheckBox c = (CheckBox)sender;//burada min mi max mı seçilmiş onu buluyoruz
            bool durum = c.Checked;
            if (c.Checked == durum)
            {
                pnlFileSize.Enabled = durum;//panelin içindeki tüm elemanlar aktif/pasif olur              
            }

        }
        private void chklstSonuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chklstSonuc.Items.Count != chklstSonuc.CheckedItems.Count) //seçimin sonucunda hepsi seçili değilse
            {
                chkTumu.CheckedChanged -= chkTumu_CheckedChanged;//event handlerı detach ediyoruz
                chkTumu.Checked = false;
                chkTumu.CheckedChanged += chkTumu_CheckedChanged;//event handlerı tekrar bağlıyoruz
                chkTumu.Text = "Tümünü seç";
            }
        }
        private void chklstSonuc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            picSecilen.Image = null;
            picOrjinal.Image = null;
            if (chkTumu.Checked == true)//tümünü seç tıklanarak buraya geldiyse, bişey yapmasın
            {
                return;
            }


            if (e.NewValue == CheckState.Checked) //sadece tick konuyorsa çalışsın, tick kalkıyorsa bişey yok
            {
                string dsy = chklstSonuc.SelectedItem.ToString();
                string krt = dict_mukerrer[dsy];


                lblOrjinalKonum.Text = "Orjinal dosya:" + dict_uniqeFiles[krt];
                try
                {
                    if (resimmi(dsy) == true)
                    {
                        pnlResim.Visible = true;
                        picSecilen.Image = System.Drawing.Image.FromFile(dsy);
                        picOrjinal.Image = System.Drawing.Image.FromFile(dict_uniqeFiles[krt]);
                    }
                    else
                    {
                        pnlResim.Visible = false;
                    }
                }
                catch (Exception)
                {
                    //resim değilse hata alır ya, bişey yapmasın. ilk başta yukarda imagelocationla yapmıstım ama bu exception fırlatmadıgı için imagefromfile yaptım
                }

            }
            else
            {
                pnlResim.Visible = false;
            }

        }

        #region "BW"
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //*****************************************A)KONTROLLER********************************

                //önce kriter chekcboxlardan en az biri seçili mi ona bi bakıyoruz
                int sayac = 0;
                CheckBox[] chkler = new CheckBox[3];//bunu List<> ile de yapıp en son toArray yaapbilrdik
                foreach (Control c in grpKriter.Controls)
                {
                    CheckBox cb = (CheckBox)c; //hepsinin chb oluğunu bildiğim için controlün ayrıca chb olup olmadıgını kontrole etmeye gerek yok, yoksa şöyle yapardım. if (cb is Chekcbox)                 
                    if (cb.Checked == true)
                    {
                        sayac++;
                        chkler[sayac - 1] = cb;
                    }
                }
                Array.Resize(ref chkler, sayac);
                if (sayac == 0)
                {
                    MessageBox.Show("En az 1 arama kriteri seçili olmalıdır");
                    return;//exit sub gibi
                }

                //şimdi bi de bi klasör seçilmiş mi ona bakalım
                if (lstKlasorler.Items.Count == 0)
                {
                    MessageBox.Show("En az 1 klasör seçmeniz gerekli");
                    return;
                }

                //şimdi de dosya türü seçilmiş mi onu alalım
                if (chklstUzanti.CheckedItems.Count == 0)
                {
                    MessageBox.Show("En az 1 dosya türü seçmeniz gerekli");
                    return;
                }

                //*****************************B)Kontroller bitti, şimdi uzantıları alalım******************                

                lblSonuc.Text = "Lütfen bekleyiniz, hedef dosyalar bulunuyor...";

                List<string> extd = new List<string>();
                for (int i = 0; i < chklstUzanti.Items.Count; i++)
                {
                    if (chklstUzanti.GetItemChecked(i))
                    {
                        string abc = dict_extension[chklstUzanti.Items[i].ToString()];
                        extd.AddRange(abc.Split(','));
                    }
                }

                //tüm tiplerle başka uznatılar birlikte seçildiyse uyarı çıksın
                if (chklstUzanti.GetItemCheckState(0) == CheckState.Checked & chklstUzanti.CheckedItems.Count > 1)
                {
                    MessageBox.Show("Tüm Dosya tipleri seçildiğinde başka seçim yapılamaz, lütfen seçiminizi düzletip tekrar deneyin");
                    return;
                }


                //***************************C)şimdi esas taramaya başlayalım**************************
                aktifpasif(false);
                lblProgress.Text = string.Empty;//mevut taramayı begenmeyip aynı ekran üzerinden ikinci bir tarama yapılırsa önce bi boşaltsın
                                                //progressBar1.Value = 0;

                chklstSonuc.Items.Clear();//yine aynı şekilde olası önceki taramadan önce cheklisti bi boşaltalım

                int taranan = 0;
                int mukerrer = 0;
                double tasarruf = 0;

                //Belirtilen klasörlerdeki tüm dosyaları listeye ekleyelim
                List<string> tumDosyaList = new List<string>();//bunun için bir list tanımlıyorum

                //string[] oneFolderFileArray = null;//recursive yerine builtin tüm folderları arma yöntemi seçilseydi bunu kullancaktım
                for (int i = 0; i < lstKlasorler.Items.Count; i++)//listedeik tüm klasölrer için şunları yap
                {
                    //her uzantı türü için ayrı ayrı arıyoruz
                    foreach (string x in extd)
                    {
                        //ilk olarak ilgili klasördeki tüm dosyaları bi diziye alıyoruz, çünkü gefiles dizi döndürür
                        //oneFolderFileArray = Directory.GetFiles((string)lstKlasorler.Items[i], x, SearchOption.AllDirectories);//alldirectories bakıyoruz ama restirected kaösere gelirse hata veriyor, ilerde bunu recursive şekilde yapalım. 
                        //sonra da bu diziyi listeye aktarıyoruz
                        //tumDosyaList.AddRange(oneFolderFileArray);

                        IEnumerable<string> files = klasor_tara((string)lstKlasorler.Items[i], backgroundWorker1, e);
                        if (chklstUzanti.GetItemCheckState(0) == CheckState.Checked)//uzantı listesinde ilk seçenek yani tüm dosya tipi seçildiyse
                        {
                            foreach (string file in files)
                            {
                                tumDosyaList.Add(file);
                            }
                        }
                        else//başka dosya tipleri seçildiyse
                        {
                            foreach (string file in files)
                            {
                                if (Path.GetExtension(file).ToLower() == x.Substring(1))
                                {
                                    tumDosyaList.Add(file);

                                }
                            }
                        }

                    }

                }
                taranan = tumDosyaList.Count;


                //**************************D)şimdi uniqleri bulma işlemine girişelim*************************
                lblSonuc.Text = "Mükerrer dosyalar bulunuyor...";
                long minv = minval();
                long maxv = maxval();

                dict_mukerrer.Clear();
                dict_uniqeFiles.Clear();

                if (chkHash.Checked == false)//klasik yöntemle mi(ad,tarih,boyut)
                {
                    foreach (string file in tumDosyaList)
                    {
                        FileInfo f = new FileInfo(file);
                        long fsize = f.Length;
                        if (fsize > minv && fsize < maxv)
                        {
                            DateTime ftarih = f.LastWriteTime;
                            string isim = Path.GetFileName(file);
                            string kriterli_isim = String.Empty;


                            dict_chb.Clear();//bir önceki döngüden gelenleri temizle
                            dict_chb.Add(chkAd, isim);
                            dict_chb.Add(chkBoyut, fsize);
                            dict_chb.Add(chkTarih, ftarih);

                            kriterli_isim = kriterDondur(isim, fsize, ftarih, chkler);

                            if (dict_uniqeFiles.ContainsKey(kriterli_isim))//uniqler içinde varsa chkliste mükerrerdir diye ekle, mukerrer_dicte de ekle
                            {
                                chklstSonuc.Items.Add(f.FullName);
                                tasarruf += f.Length;
                                dict_mukerrer.Add(f.FullName, kriterli_isim);
                            }
                            else//uniqeler içinde yoksa yani dosya ilkkez görülüyorsa orjinal olarak uniqlere ekle
                            {
                                dict_uniqeFiles.Add(kriterli_isim, f.FullName);
                            }

                            //backgroundworkere bilgi gönderelim, o da progressbarı update etsin
                            int perc = (tumDosyaList.IndexOf(file) + 1) * 100 / tumDosyaList.Count;
                            backgroundWorker1.ReportProgress(perc);
                            if (backgroundWorker1.CancellationPending)
                            {
                                e.Cancel = true;
                                backgroundWorker1.ReportProgress(0);
                                return;
                            }
                        }
                    }
                }
                else //hash algoritması seçidilyse
                {
                    foreach (string file in tumDosyaList)
                    {
                        FileStream fs = new FileStream(file, FileMode.Open);

                        long fsize = fs.Length;

                        if (fsize > minv && fsize < maxv)
                        {
                            HashAlgorithm ha = HashAlgorithm.Create();
                            string hashisim = string.Empty;
                            byte[] hash = ha.ComputeHash(fs);
                            hashisim = BitConverter.ToString(hash);

                            if (dict_uniqeFiles.ContainsKey(hashisim))
                            {
                                chklstSonuc.Items.Add(fs.Name);//path classı ile de erişişebilir(Path.GetFileName(file))
                                tasarruf += fs.Length;
                                dict_mukerrer.Add(fs.Name, hashisim);
                            }
                            else
                            {
                                dict_uniqeFiles.Add(hashisim, fs.Name);
                            }
                            fs.Flush();
                            fs.Close();

                            int perc = (tumDosyaList.IndexOf(file) + 1) * 100 / tumDosyaList.Count;
                            backgroundWorker1.ReportProgress(perc);
                            if (backgroundWorker1.CancellationPending)
                            {
                                e.Cancel = true;
                                backgroundWorker1.ReportProgress(0);
                                return;
                            }
                        }
                    }
                }


                mukerrer = chklstSonuc.Items.Count;
                lblSonuc.BackColor = System.Drawing.Color.PeachPuff;
                lblSonuc.Text = String.Format("{0} adet dosya tarandı, {1} adet mükerrer dosya bulundu. Bunların silinmesinden sağlanacak disk alanı:{2} MB olacakır.", taranan, mukerrer, String.Format("{0:n}", tasarruf / (1024 * 1024)));

            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024891)
                {
                    lblSonuc.Text = "Hata nedeniyle program durdu. Tekrar deneyiniz:" + ex.Message;
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            this.lblProgress.Text = "%" + e.ProgressPercentage;
            this.progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                pnlProgress.Visible = false;
                lblSonuc.Text = "Bir hata oldu: " + e.Error.Message;
            }
            else if (e.Cancelled)
            {
                pnlProgress.Visible = false;
                lblSonuc.Text = "Tarama iptal edildi";
                //lblProgress.Text = string.Empty;
                //progressBar1.Value = 0;
            }
            else
            {
                if (chklstSonuc.Items.Count > 0)
                {
                    btnSil.Visible = true;
                    lblOrjinalKonum.Visible = true;
                    pnlCheckSonuc.Visible = true;
                }

            }
            aktifpasif(true);
        }

        #endregion
        #region "Fonksiyonlar"
        private string kriterDondur(string isim, long fsize, DateTime ftarih, params CheckBox[] secimler)
        {
            string krt = String.Empty;
            foreach (CheckBox c in secimler)
            {
                krt += dict_chb[c].ToString();
            }
            return krt;
        }
        private string dosyaAdGetir(string fullisim)
        {
            string[] gecici = fullisim.Split('\\');
            return gecici[gecici.Length - 1];

        }
        private long minval()
        {
            if (chkMinSize.Checked)
            {
                long x = Convert.ToInt64(numericUpDown1.Value) * dict_boyutlmt[comboBox1.Text];
                return x;
            }
            else
            {
                return 0;
            }
        }
        private long maxval()
        {
            if (chkMaxSize.Checked)
            {
                long x = Convert.ToInt64(numericUpDown2.Value) * dict_boyutlmt[comboBox2.Text];
                return x;
            }
            else
            {
                return long.MaxValue;
            }
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
        private bool resimmi(string tamisim)
        {
            try
            {
                System.Drawing.Image.FromFile(tamisim);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region "menüstrip"
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.ShowDialog();
        }
        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yardım bölümü 2.versiyonda hazır olacak. Şuan için indirdiğim sayfada bulunan açıklamlardan faydalanabilirsiniz.", "Yardım");
        }

        #endregion

    }
}

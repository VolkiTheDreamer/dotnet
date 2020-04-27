using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Collections;


namespace HafızaOyunu
{
    public partial class FormOyun : Form
    {
        //propertyli instance variables      
        int numberOfBoxX;
        int numberOfBoxY;
        string picPath;
        string resimKategori;
        //propertysiz instance variables(bunlar aslında statik de olabilirdi ama Yeni Oyun açıldığında değerlerinin boşalması gerektiği için statik tanımlamadım. Statik tanımlasaydm bi de Yeni Oyun dendiğinde hesini resetlemem gerekirdi. Gerçi mix bir yol izledim, bazsını statik bırakıp başlangıç değerini 0 atadım
        List<string> lstResimDosya = new List<string>();
        Dictionary<string, string> dictKutuVeResim = new Dictionary<string, string>();
        List<int> lstRasgeleUretilenResimIndex = new List<int>();
        List<String> lstResimFromResx = new List<string>();
        int moveCounter;
        int kutuSayac;
        int ikiliSayac;
        int openedBox;

        //statikler(class variables)
        static Random random;
        static string ilkResimName;
        static int geciciRasgele;
        static Kutu ilkKutu;

        //Propertiler
        public int NumberOfBoxX { get; set; }
        public int NumberOfBoxY { get; set; }
        public string PicPath { get; set; }
        public string ResimKategori { get; set; }

        public FormOyun()
        {
            InitializeComponent();
        }

        private void FormOyun_Load(object sender, EventArgs e)
        {
            Kutu[,] pbResimler = new Kutu[NumberOfBoxX, NumberOfBoxY];
            ResimleriBelirle();
            random = new Random();
            int rassal=0;
            double menuBarHeight = this.Height / 36;
            double distForY = menuBarHeight * 1.4;

            try
            {
                for (int x = 0; x < NumberOfBoxX; x++)
                {
                    for (int y = 0; y < NumberOfBoxY; y++)
                    {
                        pbResimler[x, y] = new Kutu();
                        pbResimler[x, y].Name = "Resim" + kutuSayac;
                        kutuSayac++;                        
                        pbResimler[x, y].Click += new EventHandler(Resimler_ClickAsync);

                        this.Controls.Add(pbResimler[x, y]);
                        pbResimler[x, y].Location = new Point((int)(menuBarHeight + x * this.Width / NumberOfBoxX), (int)(((y == 0) ? this.Height * 0.05 / NumberOfBoxY + distForY : distForY - (y - 1) * this.Height * 0.05 / NumberOfBoxY) + y * this.Height / NumberOfBoxY));
                        pbResimler[x, y].Width = (int)(this.Width * 0.9 / NumberOfBoxX - menuBarHeight/2);
                        pbResimler[x, y].Height = (int)((this.Height) * 0.85 / NumberOfBoxY);

                        rassal = RasgeleUret();                        
                        dictKutuVeResim.Add(pbResimler[x, y].Name, lstResimDosya[rassal]);//pcdense full adres, resx ise resource adı
                    }
                }
            }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        
        private void ResimleriBelirle() //static olmaz, çünkü instance varible olan PicPath kullanıyorum
        {
            int adet = 0;
            Random rnd = new Random();
            string[] shuffledDizi = { };
            try
            {
                if (!string.IsNullOrEmpty(ResimKategori)) //resourcetan seçilecek
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string[] names = assembly.GetManifestResourceNames();
                    ResourceSet set = new ResourceSet(assembly.GetManifestResourceStream(names[2]));//0 ve 1 diğer iki from clasınını resourceları
                    foreach (DictionaryEntry rs in set)
                    {
                        if (rs.Key.ToString().StartsWith(ResimKategori.Replace(" ", "_")))
                        {
                            lstResimFromResx.Add(rs.Key.ToString());
                        }
                    }
                    shuffledDizi = lstResimFromResx.OrderBy(x => rnd.Next()).ToArray();//shuffle ediyorum ki hep ilk 12/30 dosyayı 
                    
                }
                else //kullanıcını cihazından seçilecek
                {
                    DirectoryInfo di = new DirectoryInfo(PicPath);                    
                    var finfos = Directory.GetFiles(di.ToString(), "*.*", SearchOption.AllDirectories)
                                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp") || s.EndsWith(".gif"));

                    shuffledDizi = finfos.OrderBy(x => rnd.Next()).ToArray();//shuffle ediyorum ki hep ilk 12/30 dosyayı geitrmesin
                }
                
                foreach (String s in shuffledDizi)
                {
                    lstResimDosya.Add(s);
                    adet++;
                    if (adet == NumberOfBoxX * NumberOfBoxY / 2)//tüm resimleri eklemekle vakit harcamısın diye ilgili adede gelince dursun
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        private int RasgeleUret() //static oldu çünkü ne instance variable var ne de this keyword--Sonradan statikliğini ptal ettim, çünkü bazı değişkenleri statikten instance variable çevirdim
        {
            try
            {
                geciciRasgele = random.Next(0, lstResimDosya.Count);
                if (lstRasgeleUretilenResimIndex.Where(x => x.Equals(geciciRasgele)).Count() <= 1)//LINQ ile en fazla 2 kez üretme kontrolü                          
                {
                    lstRasgeleUretilenResimIndex.Add(geciciRasgele);
                }
                else
                {
                    RasgeleUret();
                }
                return geciciRasgele;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
                return 0;
            }

        }
        private async void Resimler_ClickAsync(object sender, EventArgs e) //static olmaz, çünkü this.Refresh var
        {
            Kutu pic = (Kutu)sender;
            try
            {
                for (int i = 0; i < kutuSayac; i++)
                {

                    if (pic.Name == ("Resim" + i))
                    {
                        if (!string.IsNullOrEmpty(ResimKategori)) //resourcetan seçilecek                    
                            pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(dictKutuVeResim[pic.Name]);
                        else //pcden seçielcek                    
                            pic.Image = Image.FromFile(dictKutuVeResim[pic.Name]);

                        pic.Enabled = false;//geçici olarak disable yapalım ki aynı resme bi daha tıklamasın
                        ikiliSayac++;

                        if (ikiliSayac == 1)
                        //ilk tıklananları statik dğeşekenlere atıyoruz
                        {
                            ilkResimName = dictKutuVeResim[pic.Name];
                            ilkKutu = pic;
                        }
                        else //2.ye tıklandıysa kontrol yapıyoruz
                        {

                            this.Enabled = false;//önce geçici olarak tümünü false yapalım
                            moveCounter++;//sadee ikinci resimde hamleyi artırıyoruz
                            lblHamle.Text = "Hamle Sayısı:" + moveCounter;
                            this.Refresh();//ekran refresh yapıyoz ki, resim görünsün
                                           //System.Threading.Thread.Sleep(2500); //async olmadığı için işe yaramadı, bekliyor ama yine de tıklama yapmılmış sayıyor. o yüzden alttakini kullandım
                            await System.Threading.Tasks.Task.Delay(1000);
                            this.Enabled = true;//sonra geçici olarak tümünü true yapalım

                            if (ilkResimName == dictKutuVeResim[pic.Name])
                            {
                                if (Mystatikclass.sound_durum == true)
                                {
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.success);
                                    player.Play();
                                }
                                pic.Enabled = false;//artık tıklanamasın
                                ilkKutu.Enabled = false;
                                openedBox++;
                                if (openedBox == kutuSayac / 2)
                                {                                    
                                    MessageBox.Show("Tebrikler, oyunu " + moveCounter + " hamlede bitirdiniz");
                                    /*await System.Threading.Tasks.Task.Delay(1000);*/
                                    if (Mystatikclass.sound_durum == true)
                                    {
                                        System.Media.SoundPlayer playerfinito = new System.Media.SoundPlayer(Properties.Resources.iloveu);
                                        playerfinito.Play();
                                    }
                                }
                            }
                            else
                            {
                                if (Mystatikclass.sound_durum == true)
                                {
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.zort);
                                    player.Play();
                                }
                                // ResimSoldur(pic.Image);
                                pic.Image = (Image)Properties.Resources.arkaplan;
                                ilkKutu.Image = (Image)Properties.Resources.arkaplan;
                                ilkKutu.Enabled = true;//geçici olarak disable yaptığım ilk resmi tekrar enable yapıyorum
                                pic.Enabled = true;//bu da ikinci tıklamada disabel yaptıgımı enable yapıyorum
                            }
                            ikiliSayac = 0;//her halükarda sayacı resetliyoruz
                        }
                        break;//sonrakil kutulara bakmasn artık
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        /*public static void ResimSoldur(Image img)
        {
            for (int o = 0; o < 100; o++)
            {
                Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
                Graphics graphics = Graphics.FromImage(bmp);
                ColorMatrix colormatrix = new ColorMatrix();
                colormatrix.Matrix33 = o;
                ImageAttributes imgAttribute = new ImageAttributes();
                imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
                graphics.Dispose();   // Releasing all resource used by graphics 
                //return bmp;
            }
        }*/

               
        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                FormOyun fo2 = new FormOyun();
                fo2.NumberOfBoxX = NumberOfBoxX;
                fo2.NumberOfBoxY = NumberOfBoxY;
                if (!string.IsNullOrEmpty(ResimKategori)) //resourcetan seçilecek
                    fo2.ResimKategori = ResimKategori;
                else
                    fo2.PicPath = PicPath;
                fo2.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                FormAnaGiris fa = new FormAnaGiris();
                fa.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu:\n" + ex.Message);
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

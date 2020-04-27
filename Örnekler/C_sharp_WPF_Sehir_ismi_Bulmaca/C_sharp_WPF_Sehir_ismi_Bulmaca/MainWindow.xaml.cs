using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C_sharp_WPF_Sehir_ismi_Bulmaca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string[] sehirlerListesi = { "İstanbul", "Ankara", "İzmir", "Adana", "Adıyaman", 
                                       "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Antalya",
                                       "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman",
                                       "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", 
                                       "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", 
                                       "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", 
                                       "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", 
                                       "Hakkari", "Hatay", "Iğdır", "Isparta", "Kahramanmaraş", 
                                       "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri",
                                       "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli",
                                       "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin",
                                       "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize",
                                       "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şırnak",
                                       "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
                                       "Van", "Yalova", "Yozgat", "Zonguldak" };

        string bulunacakSehirIsmi = "";
        int bulunanHarfSayisi = 0;
        int kalanHak = 4;
        Random rastgele;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            btnHarfGir.IsEnabled = false;
            btnTahminEt.IsEnabled = false;
            rastgele = new Random();

            //this.AcceptButton = btnHarfGir;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bulunanHarfSayisi = 0;
            btnHarfGir.IsEnabled = true;
            btnTahminEt.IsEnabled = true;
            lblGirilenHarfler.Content = "";
            kalanHak = 4;
            lblKalanHak.Content = kalanHak.ToString();

            YeniSehirSec();

            gridOyunAlani.Children.Clear();
            int location = 0;
            for (int i = 0; i < bulunacakSehirIsmi.Length; i++)
            {
                Label label = new Label();
                label.Height = 25;
                label.Width = 25;
                label.HorizontalAlignment = HorizontalAlignment.Left;
                label.VerticalAlignment = VerticalAlignment.Top;
                label.Content = bulunacakSehirIsmi[i].ToString().ToUpper();
                label.Foreground = Brushes.Red;
                label.Background = Brushes.Red;
                location = 30 * i;
                label.Margin = new Thickness(location, 25 , 0, 0);

                gridOyunAlani.Children.Add(label);
              
            }
        }

        private void btnHarfGir_Click(object sender, RoutedEventArgs e)
        {
            bool harfVarMi = false;

            if (txtHarf.Text.Length != 1)
            {
                MessageBox.Show("Lütfen tek harf giriniz.", "Uyarı");
                txtHarf.Text = "";
                txtHarf.Focus();
                return;
            }
            else
            {
                if (lblGirilenHarfler.Content.ToString().Contains(txtHarf.Text))  //
                {
                    MessageBox.Show("Bu harfi daha önce girdiniz.", "Uyarı");

                    txtHarf.Text = "";
                    txtHarf.Focus();

                    return;
                }

                foreach (Control item in gridOyunAlani.Children)
                {
                    if (item is Label)
                    {
                        Label label = item as Label;
                        if (label.Content.ToString().ToUpper() == txtHarf.Text.ToUpper())
                        {
                            label.Foreground = Brushes.Black;
                            label.Background = Brushes.Lime;
                            harfVarMi = true;
                            bulunanHarfSayisi++;
                        }
                    }
                }
            }

            if (!harfVarMi)
            {
                kalanHak--;

                lblKalanHak.Content = kalanHak.ToString();

                if (kalanHak == 0)
                {
                    btnHarfGir.IsEnabled = false;
                    btnTahminEt.IsEnabled = false;

                    foreach (Control item in gridOyunAlani.Children)
                    {
                        if (item is Label)
                        {
                            Label label = item as Label;
                            label.Foreground = Brushes.Black;
                        }
                    }

                    MessageBox.Show("Oyun Bitti. Kaybettiniz. Yeni Oyun için yeni kelime giriniz. \n Cevap : " + bulunacakSehirIsmi, "Bilgi");
                }
            }

            lblGirilenHarfler.Content += txtHarf.Text + "  ";
          
            if (bulunanHarfSayisi == bulunacakSehirIsmi.Length)
            {
                btnHarfGir.IsEnabled = false;
                btnTahminEt.IsEnabled = false;
                MessageBox.Show("Oyun Bitti. Kazandınız. Yeni Oyun için yeni kelime giriniz.", "Bilgi"  );
            }

            txtHarf.Text = "";
            txtHarf.Focus();
        }

        private void YeniSehirSec()
        {
            int rastgeleSayi = rastgele.Next(0, sehirlerListesi.Length);

            bulunacakSehirIsmi = sehirlerListesi[rastgeleSayi];
        }

        private void btnTahminEt_Click(object sender, RoutedEventArgs e)
        {
            if (bulunacakSehirIsmi.ToUpper() == txtKelime.Text.ToUpper())
            {
                foreach (Control item in gridOyunAlani.Children)
                {
                    if (item is Label)
                    {
                        Label label = item as Label;
                        label.Foreground = Brushes.Black;
                        label.Background = Brushes.Lime;
                    }
                }
                MessageBox.Show("Oyun Bitti. Tebrikler Kazandınız. Yeni Oyun için yeni kelime giriniz.", "Bilgi");
            }
            else
            {
                foreach (Control item in gridOyunAlani.Children)
                {
                    if (item is Label)
                    {
                        Label label = item as Label;
                        label.Foreground = Brushes.Black; 
                    }
                }
                MessageBox.Show("Oyun Bitti. Kaybettiniz. Yeni Oyun için yeni kelime giriniz. \n Cevap : " + bulunacakSehirIsmi, "Bilgi");
            }

            btnHarfGir.IsEnabled = false;
            btnTahminEt.IsEnabled = false;
        }

 
 
    }
}

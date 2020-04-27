using System;
using System.IO;
using System.Windows.Forms;
/// <summary>
///Stream sınıfı abstracttır. Bundan FileStream ve StreamReader/StreamWriter türer
///SR/SW ayrıca TextReader/TW sınıfalrından da inerit eder, ki bu ikisi de abstarcttır.
///File:Copy, DElete gibi dosyaarı maniüpüle eden metodlar var
///FileInfo:FileSysteInfodan türer. Burda hem boyut, isim v.s gibi özellikler hem de eçeşitli metotlar var.
///path:
///SR/SW:karakterleri ele alır. genelde using blokcları arasında kullanırlı
///FileStream:byte2ları ele alır. byte[] dizisi. özellikle resim gibi binary data ile çalışıyorsan bunu kullan, SR/SW değil.
///Stream:Bir dosya read or write amaıyla açıdlığında  Stream olur.
//********************************
/// SR/SW'yi FS olmadan kullandıgında FS otomatik yaratılır.
///Birçok işlem fakrlı sınıfalra caılıpyla yapılabilir. Ör:bir txt dosya yaratmak içi File.CreateText metodu da kullanılabilir, File.Create de, FileInfo.CreateText de, FileInfo.Create de. tüm örnekler için şu linke bak: https://msdn.microsoft.com/en-us/library/ms404278(v=vs.110).aspx
///burda önemli olan dönüş tiplerdir, bi metodda SW dönerken, başkasında FS dönebilir.
///
/// </summary>
namespace FileDirectory_Ornekleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {                
                txtFile.Text = openFileDialog1.FileName;
            }
        }
    }
}

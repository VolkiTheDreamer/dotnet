<Query Kind="Expression">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web</Namespace>
  <Namespace>System.Web.UI</Namespace>
  <Namespace>System.Web.UI.WebControls</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

/*
Soyut sınfı Streamdean türemiştir.
FileStream:byte'ları ele alır. byte[] dizisi. özellikle resim gibi binary data ile çalışıyorsan bunu kullan, aam text dosaları da okuyabiliriz
Hem binary hem de metin dosyalarında işlem yapmamıza olanak sağlar. Ancak işlemleri Byte tabanlı yaptığı için metin dosyalarında pek tercih edilmez. 
Memorystreamden farkı işlemleri(okuma ve yazma) disk üzerinde yapması
Üzerinde işlem yapılan bir dosya ile ilgili işlemler bittikten sonra mutlaka FileStream nesnemi kapatmam gerekir. Close() metotu ile bu işlemi yapabiliriz. veya in using block.

FileStream nesnesi değişik şekillerde tanımlanabilir. En çok tanımlanma şekli;
FileStream fileStreamNesnem = new FileStream (string dosyaAdresim, FileMode DosyayıAçmaModum);
Other methods, like File.Open or File.OpenText can be used to get a FileStream.

FileStream ile normalde bir dosya hem yazma hem de okuma için açılır, istenirse bu durum sınırlanabilir. 
FileStream nesnemi tanımlarken üçüncü bir parametre daha girip burada erişim türü belirtebilirim. Örneğin, Read sadece okuma amacı ile erişim sağlar, Write sadece yazma amacı ile erişim sağlar.

FileStream fStream = File.OpenWrite("dosya.txt");, FileAccess.Write erişim yetkisi ile açılmış olur
FileStream fStream = File.OpenRead("dosya.txt");
FileStream sınıfı yükleyicisi (constructor)’nin farklı bir kullanımı :

FileStream fStream = new FileStream("dosya.txt",FileMode.OpenOrCreate,
                                                  FileAccess.Write,
                                                  FileShare.None);

For the FileStream, we often need to use another stream (like StreamWriter) on top of it. We can do many things with a file using a FileStream.
using (FileStream fileStream = File.Create(@"C:\programs\example1.txt"))
using (StreamWriter writer = new StreamWriter(fileStream))
{
    writer.WriteLine("Example 1 written");
}

FileMode – It specifies how to operation system should open the file. It has following members  
Append - Open the file if exist or create a new file. If file exists then place cursor at the end of the file.
Create - It specifies operating system to create a new file. If file already exists then previous file will be overwritten.
CreateNew - It create a new file and If file already exists then throw IOException.
Open – Open existing file.
Open or Create – Open existing file and if file not found then create new file.
Truncate – Open an existing file and cut all the stored data. So the file size becomes 0.

FileAccess – It gives permission to file whether it will open Read, ReadWrite or Write mode. 

FileShare – It opens file with following share permission.
Delete – Allows subsequent deleting of a file.
Inheritable – It passes inheritance to child process.
None – It declines sharing of the current files.
Read- It allows subsequent opening of the file for reading.
ReadWrite – It allows subsequent opening of the file for reading or writing.
Write – Allows subsequent opening of the file for writing.
*/



static string dosya=@"...xml";
static void Main()
{
       M1();
       M2();
       M3();
       //http://www.kazimcesur.com/filestream/ örnekleri. anlamazsan linke bak, detay açıklam var
       M4();//yazma
       M5();//okuma
       M6();//Seek ile konumlanma
}

static void M1() {
       using (var fs = new FileStream(dosya, FileMode.Open))
       {
           for (int i = 0; i < fs.Length; i++)
           {
               Console.WriteLine(fs.ReadByte());
           }
       }
}
//yerine
static void M2() {
       using (var fs = new FileStream(dosya, FileMode.Open))
       {
           for (int i = 0; i < fs.Length; i++)
           {
               Console.WriteLine((char)fs.ReadByte());
           }
       }
}

//Okuduğumuz küçük bir metin dosyası değil de büyük binary bir dosya olsaydı bu durumda bir byte bir byte okumaya çalışmak zaman kaybı oluştururdu. 
//Bunun yerine dosyayı parçalar haline okumak ve yazmak önemli olacaktır.Basit bir dosya kopyalayıcı yazalım :
static void M3() {
       //var kaynakDosya = @"C:\Users\N35516\Documents\LINQPad Queries\IO\buyuk.txt";
       //var hedefDosya = @"C:\Users\N35516\Documents\LINQPad Queries\IO\buyuk_copy.txt";
       var kaynakDosya = @"..\2.jpg";
       var hedefDosya = @"...2a.jpg";
       
       using (var fsOkuyucu = new FileStream(kaynakDosya, FileMode.Open))     
       using (var fsYazici = new FileStream(hedefDosya, FileMode.CreateNew))
       {
           fsYazici.SetLength(fsOkuyucu.Length);//Elimizdeki akışın boyutu bilindiği için hedef akışın boyutunu da belirttik. Bu satır işlemi yapabilmemiz için şart değil, fakat işletim sistemine dosya boyutunu söylediğimiz için bizim için bu alanı tutacaktır. Özellikle büyük boyutlu dosyalarda işe yaramaktadır.
           byte[] tampon = new byte[2048];//2048 bytelık bir tampon bölge oluşturuyoruz. Dosya isterse 1TB olsun bizim bellek kullanımımız 2048'i aşmayacak.
           int okunanByte = 0;
           while ((okunanByte = fsOkuyucu.Read(tampon, 0, tampon.Length)) > 0) //Read metodu geriye kaç byte okumuşsa onu döndürdüğünden bahsetmiştik. Eğer bu değer 0 gelirse dosyanın sonuna ulaşmış oluyoruz. Kaç byte okunduğunu not alıyoruz çünkü dosyanın boyutu 2048'in katı olmak zorunda değil. Son döngüde kaç byte okuyabilmişsek o kadar yazacağız.
           {
               fsYazici.Write(tampon, 0, okunanByte); //tampona koyduğumuz bytelardan okunanByte kadarını okuyuruz. 0 ne işe yarıyor diye sorarsanız, kaçıncı bytedan itibaren tampondan okunacağını belirtiyor.
           }
       }
}

static void M4()
    {
       //http://www.kazimcesur.com/filestream/
        try
        {
            FileStream fs = File.Open("dosya.txt", FileMode.OpenOrCreate); //şimdi yukarıdakilerden afha farklı bir şekilde açtık
            Console.WriteLine("dosya.txt yi kullanan FileStream oluşturuldu :");
            Console.WriteLine("Okuyabilir mi (CanRead)? {0}", fs.CanRead);
            Console.WriteLine("Yazabilir mi (CanWrite)? {0}", fs.CanWrite);
            Console.WriteLine("Atlayabilir mi (CanSeek)? {0}", fs.CanSeek);
            Console.WriteLine("Byte bilgiler yazılmadan önceki aktif pozisyon : {0}",
                                                                        fs.Position);
            if (fs.CanWrite)
            {
                fs.WriteByte(65);
                byte[] bytes = new byte[3] { 66, 67, 68 };
                fs.Write(bytes, 0, bytes.Length);
                Console.WriteLine("Byte bilgiler dosyaya yazıldı.");
            }
            Console.WriteLine("Byte bilgiler yazıldıktan sonraki aktif pozisyon: {0}",
                                                                         fs.Position);
            fs.Close();
            Console.ReadLine();
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
static void M5()
    {
      try
      {
        using(FileStream fs = File.OpenRead("dosya.txt"))
        {
          Console.WriteLine("Stream özellikleri kontrol ediliyor :");
          Console.WriteLine("Okuyabilir mi (CanRead)? {0}", fs.CanRead);
          Console.WriteLine("Yazabilir mi (CanWrite)? {0}", fs.CanWrite);
          Console.WriteLine("Atlayabilir mi (CanSeek)? {0}", fs.CanSeek);
          Console.WriteLine("Byte bilgiler okunmadan önceki aktif pozisyon : {0}",
                                                                     fs.Position);
          if(fs.CanRead)
          {
            // dosya boyutu kadar byte dizisi oluşturuyoruz
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            foreach(byte b in bytes)
            {
              Console.Write(" {0} ", b);
            }
            /* Okumak için kullanılabilecek diğer bir yöntem
            int temp = 0;
            while((temp = fs.ReadByte()) != -1)
            {
              Console.WriteLine(temp);
            }
            */

            /* Okumak için kullanılabilecek diğer bir başka yöntem
            * while(fs.Position < fs.Length)
              {
                Console.Write(" {0} ", fs.ReadByte());
              }
            * */
          }

          Console.WriteLine("\nByte bilgiler okunduktan sonraki aktif pozisyon : {0}",
                                                                        fs.Position);
          Console.ReadLine();
        }
      }
      catch(IOException ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
      }
    } 
static void M6()
    {
      try
      {
        using(FileStream fs = File.OpenRead("dosya.txt"))
        {
          // SeekOrigin.Begin kullanımı
          Console.WriteLine("Aktif Pozisyon: {0}", fs.Position);
          Console.WriteLine("Seek(1,SeekOrigin.Begin) atlama çalıştırılıyor");
          fs.Seek(1,SeekOrigin.Begin);
          Console.WriteLine("Aktif Pozisyon: {0}",fs.Position);
          Console.WriteLine("Byte verier okunuyor");
          while(fs.Position < fs.Length)
          {
            Console.Write(" {0} ", fs.ReadByte());
          }

          // SeekOrigin.Current kullanımı
          fs.Position = 0;
          Console.WriteLine("\n\nAktif Pozisyon: {0}",fs.Position);
          Console.WriteLine("Seek (2,SeekOrigin.Current) atlama çalıştırılıyor");
          fs.Seek(2,SeekOrigin.Current);
          Console.WriteLine("Aktif Pozisyon: {0}", fs.Position);
          Console.WriteLine("Byte verier okunuyor");
          while(fs.Position < fs.Length)
          {
            Console.Write(" {0} ", fs.ReadByte());
          }

          // SeekOrigin.End kullanımı
          fs.Position = 0;
          Console.WriteLine("\n\nAktif Pozisyon: {0}", fs.Position);
          Console.WriteLine("Seek(-1,SeekOrigin.End) atlama çalıştırılıyor");
          fs.Seek(-1,SeekOrigin.End);
          Console.WriteLine("Aktif Pozisyon: {0}",fs.Position);
          Console.WriteLine("Byte verier okunuyor");
          while(fs.Position < fs.Length)
          {
            Console.Write(" {0} ", fs.ReadByte());
          }
        }
        Console.ReadLine();
      }
      catch(IOException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

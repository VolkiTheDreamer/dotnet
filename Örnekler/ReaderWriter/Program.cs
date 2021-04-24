using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReaderWriter
{
    class Program    
    {
        //https://docs.microsoft.com/en-us/dotnet/standard/io/

        /*//Streamlerin türü var, memroystream, filestream, netwrokstream 
         ------
         * A StreamWriter : TextWriter, is a Stream-decorator.A TextWriter encodes Text data like string or char to byte[] and then writes it to the linked Stream.
         What context are you supposed to use it? What is their advantage and disadvantage?
         You use a bare FileStream when you have byte[] data.You add a StreamWriter when you want to write text.Use a Formatter or a Serializer to write more complex data.
         Is it possible to combine these two into one?
         Yes. You always need a Stream to create a StreamWriter.The helper method System.IO.File.CreateText("path") will create them in combination and then you only have to Dispose() the outer writer.
         ----
         FileStream writes bytes, StreamWriter writes text.
         StreamReader and StreamWriter work with text data, while FileStream works with bytes.
         For the FileStream, we often need to use another stream (like StreamWriter) on top of it. We can do many things with a file using a FileStream.

         HİYERARŞİ:
         Filestream from Stream(abstract)
         StreamReader from TextReader(abstract)(writerlar da aynı)
         StringReader from TextReader("" "")
         BinaryReader from Object
         TextReader(asbtract) from MarshallByRefObject
         xmtextreader from xmlreader

        ÖZET(text okumalar için)
        - Basit okuma from a "long string": StringReader. strinwrierın yazdığı metin de strinbuilder nesnesi içinde olur, string değil.
        - Basit/kısa okuma için: File.Read türevleri(readline,readalllines, readalltext)
        - async okuma için ya streamreader ya filestream
        - çok büyük dosyadan byte byte okumak için filestream. adı üzerinde bu bir stream, akış şeklinde okursun. insan gözü için gerkeliyse arada bir (char) type conv. yapmak lazım. bi yere yazcaksan direkt filestreamle yine yazarsın. streamreader de olur, readblock metodu ile.
        - okuma hızı önemliyse ve inasn gözü görmesi gerekmiyorsa filestream en iyisi.
        - + not: streamreader da filestream de tek başına kullanılaibliyor, ayrıca ikis birlikte de kullanılabliyor.  bi şekilde filestream dönen bişey varsa veya filestreamle başka şeylşer yapcaksan bu snearyo oluyor heralde.
        - binary: nasıl ki filestreamle streamreader birlikte kullanılıyorsa binaryreaderla da memorystream birlikte kullanılıyor

            https://stackoverflow.com/questions/17380506/filestream-vs-system-io-file-writealltext-when-writing-to-files : A common usecase to prefer FileStream over File.* is to control locking of a file. file.write... internally streamwriter kulalnıyor bu arada.
        */
        static string kucukTextDosya = @"E:\OneDrive\Dökümanlar\GitHub\dataset\json\indentli_bolgesatis.json";
        static string ortaTextDosya = @"E:\OneDrive\Dökümanlar\GitHub\dataset\Text\tmdb_5000_credits.csv";
        static string buyukTextDosya = @"E:\OneDrive\Dökümanlar\GitHub\dataset\Diğer\genome-scores.csv";
        static string resim = @"E:\OneDrive\resimler ve videolar\Resimler\2016\20160218_212719.jpg";
        static string targetfile = @"E:\OneDrive\Dökümanlar\GitHub\dotnet\Örnekler\target1.txt";
        static string targetfile2 = @"E:\OneDrive\Dökümanlar\GitHub\dotnet\Örnekler\target1.txt";
        static string targetresim = @"E:\OneDrive\Dökümanlar\GitHub\dotnet\Örnekler\targetresim.jpg";
        static string xmlpath = @"E:\OneDrive\Uygulama Geliştirme\web sitelerim\Yeni Efendi\sitemap.xml";

        static void Main(string[] args)
        {
            ///buraya bi time ölçüer
            MemoryStream();
        }

        static void MemoryStream()
        {
            //Genellikle iki farklı akış arasında köprü görevi kurmak için kullanılır.
            //BY:in-memory için bu
            //VY:list gibi geçici bi değişkene almak yerine memory kullanmak daha manıklı galiba. 
            var random = new Random(1300);
            using (var ms = new MemoryStream(10))
            {
                for (var i = 0; i < ms.Capacity; i++)
                {
                    ms.WriteByte((byte)random.Next(0, 255));
                }

                ms.Seek(0, SeekOrigin.Begin); //ms.Position = 0;

                for (var i = 0; i < ms.Capacity; i++)
                {
                    Console.WriteLine(ms.ReadByte());
                }
            }
            Console.ReadKey();
        }

        static void FileStream()
        {
            //A FileStream is a Stream. Like all Streams it only deals with byte[] data
            using (var fs = new FileStream(@"c:\cihan\test.txt", FileMode.Open))
            {
                for (int i = 0; i < fs.Length; i++)
                {                    
                    Console.Write((char)fs.ReadByte());//charsız dene bi de. char yapmak yerine streamreader de kulanılabilir 
                    //yani insan gözü görmesi için char'a çevir veya streamreaderla oku. ayrıca aşağıdaki giibi bellek sorunu varsa byte byte okumak için de bu iyi, zira streamreader tek seferde bulk(?) olkuyor
                }
            }
        }

        static void FileStreamDANABOYdosyadan()
        {
            using (var fsOkuyucu = new FileStream(buyukTextDosya, FileMode.Open))
            using (var fsYazici = new FileStream(targetfile, FileMode.CreateNew))
            {
                fsYazici.SetLength(fsOkuyucu.Length);
                byte[] tampon = new byte[2048];
                int okunanByte = 0;
                while ((okunanByte = fsOkuyucu.Read(tampon, 0, tampon.Length)) > 0) //async dene bi de
                {
                    fsYazici.Write(tampon, 0, okunanByte);
                }
            }
        }

        static void FileStreamBinary()
        {
            //imaj, pdf, excel v.s
            using (var fsOkuyucu = new FileStream(resim, FileMode.Open))
            using (var fsYazici = new FileStream(targetresim, FileMode.CreateNew))
            {
                fsYazici.SetLength(fsOkuyucu.Length);
                byte[] tampon = new byte[2048];
                int okunanByte = 0;
                while ((okunanByte = fsOkuyucu.Read(tampon, 0, tampon.Length)) > 0) //async dene bi de
                {
                    fsYazici.Write(tampon, 0, okunanByte);
                }
            }
        }


   
        static async  void FileStreamBinary_Async()
        {
            using (var httpClient = new HttpClient())
            {
                var url = @"http://www.excelinefendisi.com/anasayfa.jpg";
                byte[] imageBytes = await httpClient.GetByteArrayAsync(url);

                using (var fs = new FileStream(targetresim, FileMode.Create))                
                {
                    fs.Write(imageBytes, 0, imageBytes.Length);
                }
            }
        }

        static void StreamReader()
        {
            //StreamReader reads characters from a byte stream. It defaults to UTF-8 encoding.            
            using (var sr = new StreamReader(kucukTextDosya))
            {
                string content = sr.ReadToEnd();

                Console.WriteLine(content);
                                
                string line = String.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

            
            using (var sw = new StreamWriter(targetfile)) //encoding verilmez, encodinng verceksen filewtreamle kullanmak lazım, aşağıdaki gibi
            {
                sw.Write("türkçe karaekter tığ çiğ söğüş");
            }

            using (var fs = new FileStream(targetfile2, FileMode.CreateNew, FileAccess.Write))
            using (var sw = new StreamWriter(fs,Encoding.UTF8)) 
            {
                sw.Write("türkçe karaekter tığ çiğ söğüş");
            }

        }

        static async void StreamReader_Async()
        {
            using (var fs = new FileStream(ortaTextDosya, FileMode.Open, FileAccess.Read)) //bu seefer hali hazırdaki bir fs'den faydalanalım
            using (var sr = new StreamReader(fs, Encoding.UTF8)) //ilaveten encoding
            {
                string content = await sr.ReadToEndAsync();                
                Console.WriteLine(content);                
            }

            //bazen bi fileinfo ile de elde edilebilir
            //FileInfo fi = new FileInfo(fileName);
            //StreamReader sr = fi.OpenText();
        }

        static void FileRead()
        {
            var enumLines = File.ReadLines(kucukTextDosya, Encoding.UTF8);
            string[] lines = File.ReadAllLines(kucukTextDosya, Encoding.UTF8);            
            string content = File.ReadAllText(kucukTextDosya, Encoding.UTF8);
        }

        static void BinaryReader()
        {
            byte[] file = File.ReadAllBytes("C:\\ICON1.png");

            // Create a memory stream from those bytes.
            using (MemoryStream memory = new MemoryStream(file))
            {
                // Use the memory stream in a binary reader.
                using (BinaryReader reader = new BinaryReader(memory))
                {
                    // Read in each byte from memory.
                    for (int i = 0; i < file.Length; i++)
                    {
                        byte result = reader.ReadByte();
                        Console.WriteLine(result);
                    }
                }
            }

            using (BinaryReader b = new BinaryReader(
            File.Open("file.bin", FileMode.Open)))
            {
                // 2.
                // Position and length variables.
                int pos = 0;
                // 2A.
                // Use BaseStream.
                int length = (int)b.BaseStream.Length;
                while (pos < length)
                {
                    // 3.
                    // Read integer.
                    int v = b.ReadInt32();
                    Console.WriteLine(v);

                    // 4.
                    // Advance our position variable.
                    pos += sizeof(int);
                }
            }
        }

        static async void StringReader()
        {
            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("Characters in 1st line to read");
            stringToRead.AppendLine("and 2nd line");
            stringToRead.AppendLine("and the end");

            using (StringReader reader = new StringReader(stringToRead.ToString()))
            {
                string readText = await reader.ReadToEndAsync();
                Console.WriteLine(readText);
            }
        }

        static void XMLreader()
        {
            using (var xreader = new XmlTextReader(xmlpath))
            {
                xreader.MoveToContent();

                while (xreader.Read())
                {
                    var node = xreader.NodeType;
                    switch (node)
                    {
                        case XmlNodeType.Element:
                            Console.Write(xreader.Name);
                            break;
                        case XmlNodeType.Text:
                            Console.Write(xreader.Value);
                            break;                        
                        default:
                            break;
                    }
                }
            }
        }
    }
}

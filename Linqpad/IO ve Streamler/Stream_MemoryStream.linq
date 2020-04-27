<Query Kind="Program">
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

Memorystream

/*The program physically reads in the bytes of specified file into the computer's memory. No more disk accesses occur after this.
It sometimes helps to put data into memory and simply leave it there. Memory is much faster than disk or network accesses. With MemoryStream, 
we can act upon the byte array stored in memory rather than a file or other resource.

Uygulamanızın sık sık veriye ihtiyaç duyduğu durumlarda verileri dosya (file)’da tutmak uygulamanızın performansını düşürür ve arayüzün yanıt süresini geciktirir. 
Örneğin uygulamanız bir veri kümesinden sıklıkla bir referans veriye ihtiyaç duyduğu zaman bu veri kümesini dosyada tutmak doğru bir seçim olmaz. Bu gibi durumlarda veriyi dosya yerine
MemoryStream’de saklamak daha efektif bir çözüm olmaktadır. Çünkü MemoryStream geçici veri saklama işleminde veriyi bellekte sakladığından hızlı depolama imkanı sunmaktadır.

Uygulamanız içerisinde serileştirmiş olduğunuz nesneleri transfer ederken geçiçi olarak MemoryStream de saklamak bu duruma iyi bir örnek olarak gösterilebilir. 
Böyle bir durumda FileStream veya BufferedStream kullanmak yerine MemoryStream kullanmak daha iyi bir performans sağlayacaktır. 
*/
static void Main()
    {
        // Read all bytes in from a file on the disk.
        //byte[] file = File.ReadAllBytes(@"C:\Users\N35516\Pictures\2.jpg");
             byte[] file = File.ReadAllBytes(@"....xml"); //FS gibi, bu da sadece byte dosyaları değil normal dosyaları da okur. Bunun sonucunu mesela excele yapıştır ve CHAR fonk ile bak

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
             M2();
    }
       
       
static void M2()
{
    // Boş Memory stream oluşturuluyor.
    MemoryStream mS = new MemoryStream();
    byte[] memData = Encoding.UTF8.GetBytes("Belleğe (Memory) yazılacak veri.");
    // Veriler yazılıyor.
    mS.Write(memData, 0, memData.Length);
    // Pointer pozisyonu en başa alınıyor.
    mS.Position = 0;
    byte[] inData = new byte[100];
    // Bellekten okunuyor.
    mS.Read(inData, 0, 100);
    Console.WriteLine(Encoding.UTF8.GetString(inData));
    Stream strm = new FileStream(@"...txt", FileMode.OpenOrCreate, FileAccess.Write);
    mS.WriteTo(strm);    
}

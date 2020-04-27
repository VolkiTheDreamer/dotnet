<Query Kind="Expression">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
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

http://www.kazimcesur.com/c-streams/ sayfasında güzel anlatım var
Stream:Bir dosya read or write amaıyla açıdlığında Stream olur.
Let us assume you want to read binary data from the database, you would go in for a MemoryStream. However if you want to read a file on your system, you would go in for a FileStream.
filestream'in streamreader ve streamwriterdan farkı ise filestream stream şeklinde okuyup yazabilirken, diğerleri tek seferde(?), diğer fark ise dilestream bytelarla çalışırken SR/SW char'larla çalışır

Streamler-->Byte işlemi+okuma ve yazma için tek nesne
	FS-->Diskte
	MS-->Memoryde
	
TextR/W-->Char işlemi, okuma ve yazma için ayrı nesneler


Sınıf               Açıklama
Stream              Byte okuyup yazacak, Stream sınıflarının kullanacağı ana soyut sınıf (abstract base class).
FileStream          İşlemleri diskte yapar. Basit Stream sınıfının normal davranışlarına ek olarak Seek metodu ile dosyalara rasgele erişim (random access) sağlar. Yapacağı işlemleri senkron ve asenkron olarak gerçekleştirebilir. hem text hem binarylerde yapar, ama textlerde tercih edilmemeli.
MemoryStream 		İşlemleri bellekte yapar. Tamponu olmayan (nonbuffered) veriyi direk bellekte (memory) tutan Stream türüdür. Bu stream veriyi saklamak için ayrı bir kaynak kullanmamaktadır, bu yüzden geçici tampon (temporary buffer) olarak kullanılması duruma göre avantaj sağlayabilmektedir.
BufferedStream      Bir Stream'in tampon ihtiyacı olduğunda tampon olarak BufferedStream kullanmaktadır. NetworkStream gibi. (FileStream kendi içerisinde tampon yapısını halletmekte, Memory Stream ise tampona ihtiyaç duymamaktadır.) BufferedStream objesi duruma göre stream'lerin okuma ve yazma hızını arttıkmak için kullanılabilmektedir.
Başka Streamlaer de var

TextReader          StreamReader ve StringReader objeleri için soyut ana sınıftır (abstract base class). Bir başka Soyut ana sınıf olan Stream sınıfı byte tipinde girdi (input) ve çıktı (output) vermek için tasarlanmışken, TextReader sınıfı ise Unicode karakter çıktısı verecek şekilde tasarlanmış olup hazır metodları içermektedir.
StreamReader		Stream'den karakterleri okur, byte tipindeki verileri Encoding kullarak karaktere çevirir.
StringReader		String tipinden karakterleri okumak için kullanılır. StringReader sınıfı kendi içerisinde String sınıfı ile aynı API'yi kullanır buna bağlı olarak Stream nesnesinden okuduğu byte tipini herhangi bir encoding türünde yada String çıktı (output) olarak verebilir.

TextWriter          StreamWriter ve StringWriter objeleri (ve bikaç tane daha, bunların muadili reader oalrak yok) için soyut ana sınıftır. 
StreamWriter 		Karakterleri byte tipine çevitmek için Encoding kullanır ve Stream'e yazar.
StringWriter 		StringWriter sınıfı karakterleri String olarak yazar. Kendi içerisinde String sınıfı ile aynı API'yi kullanır buna bağlı olarak Stream nesnesinden okuduğu byte tipini herhangi bir encoding türünde yada String çıktı (output) olarak verebilir.
BinaryReader 		Stream'den binary veriyi okur.
BinaryWriter 		Binary veriyi Stream'e yazar.
HtmlTextWriter      html output üretir
XmlWriter           xml output üretir


WHY STREAMS?
For example, say we want to move a large file on a USB stick to a field in a database. We could use a 'System.IO.File' object to retrieve that whole file into the computer's memory and 
then use a database connection to pass that file onto the database.

But, that's potentially problematic, what if the file is larger than the computer's available RAM? Now the file will potentially be cached to the hard drive, which is slow, and it might even slow the computer down too.
It can be better to split the file and move it a piece at a time

So, rather than getting whole file at once, it would be better to retrieve the file a piece at a time and pass each piece on to the destination one at a time. This is what a Stream does and 
that's where the two different types of stream you mentioned come in:

We can use a FileStream to retrieve data from a file a piece at a time
and the database API may make available a MemoryStream endpoint we can write to a piece at a time.
We connect those two 'pipes' together to flow the file pieces from file to database.
Even if the file wasn't too big to be held in RAM, without streams we were still doing a number or read/write operations that we didn't need to. The stages we we're carrying out were:

Retrieving the data from the disk (slow)
Writing to a File object in the computer's memory (a bit faster)
Reading from that File object in the computer's memory (faster again)
Writing to the database (probably slow as there's probably a spinning disk hard-drive at the end of that pipe)

Streams allow us to conceptually do away with the middle two stages, instead of dragging the whole file into computer memory at once, we take the output of the operation to retrieve the data and 
pipe that straight to the operation to pass the data onto the database.
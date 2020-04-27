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
       Bunlar abtract class olan TextWriter ve TextReader'dan üremiştir. Diğer ...Writer ve ...Reader olanalr da bunlardan türüyor.
       başak bir abstract sınıf olan Stream sınıfıyla alakalırı yok.
       Örnek olarak, bilgisayar üzerindeki bir sürücüde bulunan bir .txt dosyasına program içinden erişip metinsel bir ifade eklemek için, StreamWriter sınıfı kullanılabilir.
       VBA'daki TextStreame benziyorlar. VBAdeki iki görevi de görüyordu
       
       Birçok işlem fakrlı sınıfalra caılıpyla yapılabilir. Ör:bir txt dosya yaratmak içi File.CreateText metodu da kullanılabilir, File.Create de, FileInfo.CreateText de, FileInfo.Create de. 
       tüm örnekler için şu linke bak: https://msdn.microsoft.com/en-us/library/ms404278(v=vs.110).aspx
       burda önemli olan dönüş tiplerdir, bi metodda SW dönerken, başkasında FS dönebilir.
*/
void Main()
{
       StreamWriter Yaz = new StreamWriter(@"....txt");    //8 overloadu var
       Yaz.Write("falanca filan.");
       Yaz.WriteLine("Aynı satıra devam");
       Yaz.WriteLine("satır 2");
       Yaz.WriteLine("satır 3");
       Yaz.Close();
       
       StreamReader sr =new StreamReader(@"C...txt"); //11 overload
       Console.WriteLine(sr.ReadToEnd()); //ümü
       
       while (!sr.EndOfStream)  //(s = sr.ReadLine()) != null da diyolar
       {  
             sr.ReadLine().Dump(); //satır satır. listboxa falan almak için iyi
       } 
       sr.Close();
       
       
}
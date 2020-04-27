<Query Kind="Program">
  <Reference Relative="..\..\..\web sitelerim\excelinefendisi\Bin\HtmlAgilityPack.dll">E:\OneDrive\Uygulama Geliştirme\web sitelerim\excelinefendisi\Bin\HtmlAgilityPack.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Globalization.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>HtmlAgilityPack</Namespace>
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
  <Namespace>System.Xml.Serialization</Namespace>
</Query>

void Main()
{
	IList<Student> studentList = new List<Student>() { 
    new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
    new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 } 
	};

	var r = from s in studentList
                where s.Age > 12 && s.Age < 20
				//where s.Age > 90 //bu case'de first ve max patlıyor.
                select new
				{
					s.StudentName,
					s.Age
				};
					
	r.GetType().Dump("iki değerli sorgu sonucu"); //IEnumerable
	r.Dump();
	
	var first=r.FirstOrDefault();
	first.GetType().Dump("r'nin firstdefaultu"); //artık anonimleşmiştir.
	first.Dump();
	
	var max=r.Max(x=>x.Age);
	max.GetType().Dump("r'nin yaşa göre maxı"); //int
	max.Dump();
}

public class Student{

	public int StudentID { get; set; }
	public string StudentName { get; set; }
	public int Age { get; set; }
	
}
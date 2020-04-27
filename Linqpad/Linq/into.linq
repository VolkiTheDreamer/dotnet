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
	//gruplamada veya slectten sornaki ardışık filtremede kullanılabilir
	IList<Student> studentList = new List<Student>() { 
    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
    new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
    new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
    new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 } 
	};

	var teenAgerStudents = from s in studentList
	    where s.Age > 12 && s.Age < 20
	    select s
	        into teenStudents
	        where teenStudents.StudentName.StartsWith("B")
	        select teenStudents;
	
	teenAgerStudents.Dump();
	//veya daha ksıaca. into'nun esprisi ne? heralde daha karmaşıklarda işe yarıyor. masterpagedeki linkprev içindekini böyle yapmaay çalışalım
	var teenAgerStudents2 = from s in studentList
	    where (s.Age > 12 && s.Age < 20) && s.StudentName.StartsWith("B")
	    select s;
	teenAgerStudents2.Dump();	
}

// Define other methods and classes here
public class Student{

	public int StudentID { get; set; }
	public string StudentName { get; set; }
	public int Age { get; set; }
	
}
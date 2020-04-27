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
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.OleDb</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
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

public class Program
{
	public static void Main()
	{
		// Student collection
		IList<Student> studentList = new List<Student>() { 
			new Student() { StudentID = 1, StudentName = "John", Age = 18, StandardID = 1 } ,
				new Student() { StudentID = 2, StudentName = "Steve",  Age = 21, StandardID = 1 } ,
				new Student() { StudentID = 3, StudentName = "Bill",  Age = 18, StandardID = 2 } ,
				new Student() { StudentID = 4, StudentName = "Ram" , Age = 20, StandardID = 2 } ,
				new Student() { StudentID = 5, StudentName = "Ron" , Age = 21 } 
		};
		
		IList<Standard> standardList = new List<Standard>() { 
			new Standard(){ StandardID = 1, StandardName="Standard 1"},
			new Standard(){ StandardID = 2, StandardName="Standard 2"},
			new Standard(){ StandardID = 3, StandardName="Standard 3"}
		};
		
		
		var nestedQueries = from s in studentList
                    where s.Age > 18 && s.StandardID == 
                        (from std in standardList
                        where std.StandardName == "Standard 1"
                        select std.StandardID).FirstOrDefault()
                            select s;

		nestedQueries.ToList().ForEach(s => Console.WriteLine(s.StudentName));  
		
	}
}

public class Student{

	public int StudentID { get; set; }
	public string StudentName { get; set; }
	public int Age { get; set; }
	public int StandardID { get; set; }		
}

public class Standard{

	public int StandardID { get; set; }
	public string StandardName { get; set; }	
}

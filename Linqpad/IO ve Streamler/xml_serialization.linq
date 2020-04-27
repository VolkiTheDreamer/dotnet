<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xml.Serialization.dll</Reference>
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

//https://social.technet.microsoft.com/wiki/contents/articles/28151.using-xml-serialization-with-c-and-sql-server.aspx
//https://mac-blog.org.ua/sql-xml-csharp/
void Main()
{
	person p = new person();
	p.name = "Chervine";
	p.surname = "Bhiwoo";
	p.country = "Mauritius";
	
	var xmlperson = ObjectToXMLGeneric<person>(p);
	xmlperson.Dump("ilki");
	
	
	person p1 = new person { name = "a", surname = "a", country = "Mauritius" };
	 
	List<person> persons = new List<person>();
	persons.Add(p);
	persons.Add(p1);
	 
	var xmlperson2 = ObjectToXMLGeneric<List<person>>(persons);
	xmlperson2.Dump("ikinci");
}

[Serializable]
public class person
{
    public string name { get; set; }
    public string surname { get; set; }
    public string country { get; set; }
}

public static String ObjectToXMLGeneric<T>(T filter)
{
 
    string xml = null;
    using (StringWriter sw = new StringWriter())
    {
 
        XmlSerializer xs = new XmlSerializer(typeof(T));
        xs.Serialize(sw, filter);
        try
        {
            xml = sw.ToString();
 
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    return xml;
}
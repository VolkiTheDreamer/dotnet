<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
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

void Main()
{
	//en güzel çıktıyı swlilier veriyor,wmlwr'liler değil
	Employee emp=new Employee(1,"volki", "yurt", 500);
	EmployeeDosyaYaz_withXMLwr(); //xmlwriter ile: yanyana oluyor ama tam bi xml formatı ..<?xml version="1.0" encoding
	xml_string_uret_with_dtvesw();//altalta aşağı yazar ama baştaki <?xml falan yok
	xml_dosya_uret_dtden(); //altalta ve istenen foramtta 
	xml_dosya_uret_xmlwrvedt();
	sqLileXmlStringUret();//yanyanya garip
	xmloku_withsr();
	xmloku_stringrdile();//xml doc döndüren iki metodumuz var(xmldocdondurfromfile ve DBden), onu kullanıyor.
}

//-------------------------------
public class Employee
    {
        int _id;
        string _firstName;
        string _lastName;
        int _salary;

        public Employee(int id, string firstName, string lastName, int salary)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this._salary = salary;
        }

        public int Id { get { return _id; } }
        public string FirstName { get { return _firstName; } }
        public string LastName { get { return _lastName; } }
        public int Salary { get { return _salary; } }            
    }
static void EmployeeDosyaYaz_withXMLwr()
    {
        Employee[] employees = new Employee[4];
        employees[0] = new Employee(1, "David", "Smith", 10000);
        employees[1] = new Employee(3, "Mark", "Drinkwater", 30000);
        employees[2] = new Employee(4, "Norah", "Miller", 20000);
        employees[3] = new Employee(12, "Cecil", "Walker", 120000);

        using (XmlWriter xmlwr = XmlWriter.Create(@"C:\Users\volka\Documents\LINQPad Queries\EmployeeDosyaYaz_withXMLwr.xml"))
        {
            xmlwr.WriteStartDocument();
            xmlwr.WriteStartElement("Employees");

            foreach (Employee employee in employees)
            {
                xmlwr.WriteStartElement("Employee");

                xmlwr.WriteElementString("ID", employee.Id.ToString());
                xmlwr.WriteElementString("FirstName", employee.FirstName);
                xmlwr.WriteElementString("LastName", employee.LastName);
                xmlwr.WriteElementString("Salary", employee.Salary.ToString());

                xmlwr.WriteEndElement();                               
            }

            xmlwr.WriteEndElement();
            xmlwr.WriteEndDocument();
                    
        }
             
    }
	
static void xml_string_uret_with_dtvesw()
{
	SqlConnection con = MyDB.ConYarat();
    string sorgu = "select * from Anakonular";
    SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
    DataTable dt = new DataTable {TableName = "MyTableName"};
    da.Fill(dt);
        
    StringWriter sw = new System.IO.StringWriter();
    dt.WriteXml(sw, XmlWriteMode.IgnoreSchema, true);
	sw.ToString().Dump("xml_string_uret_with_dtvesw"); //veya return sw.tostring, xml metin döndürmek istersek
}	

static void xml_dosya_uret_dtden()
{ //yukardakinden farkı sw ile kullanmadan doğrudan dosyaya yazmak. 
	SqlConnection con = MyDB.ConYarat();
    string sorgu = "select * from Anakonular";
    SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
    DataTable dt = new DataTable {TableName = "MyTableName"};
    da.Fill(dt);
    
    dt.WriteXml(@"C:\Users\volka\Documents\LINQPad Queries\xml_dosya_uret_dtden.xml");
   
}	

static void xml_dosya_uret_xmlwrvedt()
{ //swden farkı, swli olan alatlata iken bu yanyana
	SqlConnection con = MyDB.ConYarat();
    string sorgu = "select * from Anakonular";
    SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
    DataTable dt = new DataTable { TableName = "MyTableName" }; //tablo adı belirtmek laızm yoksa çalışmaz
    da.Fill(dt);
    
    using (XmlWriter wr = XmlWriter.Create(@"C:\Users\volka\Documents\LINQPad Queries\xml_dosya_uret3_xmlwrvedt.xml"))
    {
        dt.WriteXml(wr, XmlWriteMode.IgnoreSchema, false);		
    }
	
	
}
static void sqLileXmlStringUret()
{
	SqlConnection con = MyDB.ConYarat();
	con.Open();
    //string sorgu = "select * from Anakonular FOR XML PATH('Efendi'), ROOT('Volkan')"; //XML'den sonra RAW, EXPLICIT veya AUTO da yazılabilyor, 
		//hen you want full control over the produced XML, you use FOR XML EXPLICIT, but it is difficult to understand, read, or maintain. 
		//FOR XML AUTO produces the most readable SELECT statement. The RAW option is rarely used and therefore not discussed. 
		//The PATH option allows you to mix attributes and elements easier
	string sorgu = "select * from Anakonular FOR XML AUTO, ELEMENTS"; //ELEMENTS ifadesi ile daha bildik format oluyor
	SqlCommand cmd=new SqlCommand(sorgu,con);
	SqlDataReader dr = cmd.ExecuteReader();
	while (dr.Read())
	{
		dr.GetString(0).Dump("sqLileXmlStringUret");
	}
	dr.Close();
	con.Close();
}

static XmlDocument xmldocdondurfromfile()
{
	XmlDocument doc = new XmlDocument();
	doc.PreserveWhitespace = true;
	doc.Load(@"C:\Users\volka\Documents\LINQPad Queries\xml_dosya_uret_dtden.xml");
	return doc;
}

static void xmlyaz() {

	SqlConnection con = MyDB.ConYarat();
	con.Open();
    string sorgu = "select * from Anakonular FOR XML AUTO";
	var doc = new XmlDocument();
	SqlCommand cmd=new SqlCommand(sorgu,con);
	XmlReader xr = cmd.ExecuteXmlReader();
	string output = xr.ReadOuterXml();
	output.Dump();
	xr.Close();
	con.Close();

	
}
static XmlDocument xmldocdondurfromDB() {

	SqlConnection con = MyDB.ConYarat();
	con.Open();
    string sorgu = "select * from Anakonular FOR XML AUTO";
	var doc = new XmlDocument();
	SqlCommand cmd=new SqlCommand(sorgu,con);
	XmlReader xr = cmd.ExecuteXmlReader();
	if (xr.Read())
		doc.Load(xr);//Alternatively you can use xr.ReadOuterXml() to get xml as string,without constructing a document.
	//xr.ReadInnerXml().Dump("xmloku_cmdxmlreaderile");
	xr.Close();
	con.Close();
//	DataSet ds = new DataSet( );
//	ds.ReadXml(xr, XmlReadMode.IgnoreSchema);
//	xr.Close();
//	ds.GetXml().Dump();	
	return doc;
}

static void xmloku_withsr() {
	StreamReader sr =new StreamReader(@"C:\Users\volka\Documents\LINQPad Queries\xml_dosya_uret_dtden.xml");	
    sr.ReadToEnd().Dump("xmlokuwith sr");
}

static void xmloku_stringrdile() {
	StringReader strrd = new StringReader(xmldocdondurfromfile().InnerXml);
	strrd.ReadToEnd().Dump("xmlokuwith strrd");
	StringReader strrd2 = new StringReader(xmldocdondurfromDB().InnerXml);
	strrd2.ReadToEnd().Dump("xmlokuwith strrd");
}



static void xpathile()
{
//hata veriyor: https://www.c-sharpcorner.com/article/transform-xml-output-of-sql-query-using-for-xml-auto-statement-to-html-using-xsl/
	SqlConnection con = MyDB.ConYarat();
	con.Open();
	string sorgu = "select * from Anakonular FOR XML AUTO, ELEMENTS";
	XmlDocument xd = new XmlDocument();  
	SqlCommand cmd = new SqlCommand(sorgu, con);  
	XmlReader xr = cmd.ExecuteXmlReader();  
	XPathDocument xp = new XPathDocument(xr);  //Provides a fast, read-only, in-memory representation of an XML document by using the XPath data model.
	XPathNavigator xpn = xp.CreateNavigator();  
	xd.LoadXml(xpn.OuterXml);  
}

static void XdocileLINQ() {
	SqlConnection con = MyDB.ConYarat();
    string sorgu = "select * from Anakonular";
    SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
    DataTable dt = new DataTable { TableName = "MyTableName" }; //tablo adı belirtmek laızm yoksa çalışmaz
    da.Fill(dt);
	
	XElement xml = new XElement("RootNode", dt.AsEnumerable().Select(r =>
       new XElement("Pathnode",
            new XElement("AnaID", r["AnaID"]),
            new XElement("Anakonu", r["Anakonu"])            
       )));

	xml.Dump();
}
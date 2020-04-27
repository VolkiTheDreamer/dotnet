<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.WebRequest.dll</Reference>
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

static void Main()
{
       StringWriter_HtmlTextWriter();
       StringWriter_HtmlTextWriter2(); 
	   StringWriter_HtmlTextWriter3();
	   formatted_html();
       
}

static void StringWriter_HtmlTextWriter()
{    
    string[] arr = new string[]
    {
        "One",
        "Two",
        "Three"
    };
    // Write markup and strings to StringWriter
    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    {
        foreach (string item in arr)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
            // Send internal StringBuilder to markup method.
            StringBuilder sb=stringWriter.GetStringBuilder();
            sb.Append("Some text");
            writer.RenderEndTag();
        }
    }
    stringWriter.ToString().Dump("StringWriter_HtmlTextWriter");
}

static void StringWriter_HtmlTextWriter2()
{
	string[] _words = { "Sam", "Dot", "Perls" };
    // Initialize StringWriter instance.
    StringWriter stringWriter = new StringWriter();

    // Put HtmlTextWriter in using block because it needs to call Dispose.
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    {
        // Loop over some strings.
        foreach (var word in _words)
        {
            // Some strings for the attributes.
            string classValue = "ClassName";
            string urlValue = "http://www.dotnetperls.com/";
            string imageValue = "image.jpg";

            // The important part:
            writer.AddAttribute(HtmlTextWriterAttribute.Class, classValue);
            writer.RenderBeginTag(HtmlTextWriterTag.Div); // Begin #1

            writer.AddAttribute(HtmlTextWriterAttribute.Href, urlValue);
            writer.RenderBeginTag(HtmlTextWriterTag.A); // Begin #2

            writer.AddAttribute(HtmlTextWriterAttribute.Src, imageValue);
            writer.AddAttribute(HtmlTextWriterAttribute.Width, "60");
            writer.AddAttribute(HtmlTextWriterAttribute.Height, "60");
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, "");

            writer.RenderBeginTag(HtmlTextWriterTag.Img); // Begin #3
            writer.RenderEndTag(); // End #3

            writer.Write(word);

            writer.RenderEndTag(); // End #2
            writer.RenderEndTag(); // End #1
        }
    }
    // Return the result.
    stringWriter.ToString().Dump("StringWriter_HtmlTextWriter2");
}


/*

Outside of benefiting from Adaptive Rendering for alternate devices, does it ever make sense to write all of this code:
cevap:
I can think of two reasons to use HtmlTextWriter:

You can use the writer to keep track of your indents, so that your outputted HTML is formatted nicely, rather than appearing on one line

HtmlTextWriter is usually associated with an output stream, so it should be more efficient than building up a long string in memory (depending upon how much HTML you are generating).

Neither of these are extraordinary reasons, but they are enough to convince me to use the writer when efficiency is needed, or if I am writing a base control that will be reused and should be as
professional as possible. Your mileage may vary :-).
HtmlTextWriter writes directly to the output buffer. StringBuilder on the other hand, has its own buffer. When you call ToString on the StringBuilder, 
a new string has to be built and then it will be written to the output buffer by output.Write. It requires much more work to be done.
*/


static void StringWriter_HtmlTextWriter3()
{
    StringWriter stringWriter = new StringWriter();
    using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
    {
             writer.WriteBeginTag("table");writer.Write(HtmlTextWriter.TagRightChar);
             writer.WriteBeginTag("tr");writer.Write(HtmlTextWriter.TagRightChar);
             writer.WriteBeginTag("td");writer.Write(HtmlTextWriter.TagRightChar);  
             
             //yukardaki WriteBeginTag yöntemi amelasyon. Render olayı daha iyiymiş
             writer.RenderBeginTag("p");
             writer.WriteEncodedText("some tezddfsdfsdf sd fsdfsd");
             writer.RenderEndTag();
             
             writer.WriteEncodedText("huhu");
             writer.WriteEndTag("td");
             writer.WriteEndTag("tr");
             writer.WriteEndTag("table");
             
             writer.AddAttribute(HtmlTextWriterAttribute.Id, "someId");
             //if (!string.IsNullOrEmpty(cssClass)) writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
             writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red");
             writer.RenderBeginTag(HtmlTextWriterTag.Span);
             writer.WriteEncodedText("oooooo");
             writer.RenderEndTag();
             
       }
       Console.WriteLine(stringWriter.ToString()); // niye formatlı yazmıyor?

       StringBuilder sb=new StringBuilder();
       sb.Append("<table><tr><td>");
       sb.Append("huhu");
       sb.Append("</td></tr></table>");
       sb.ToString().Dump("StringWriter_HtmlTextWriter");
}

static void formatted_html() {
	SqlConnection con = MyDB.ConYarat();
    string sorgu = "select isim from ajaxtest";
    SqlDataAdapter adaptor = new SqlDataAdapter(sorgu, con);
    DataTable tablo = new DataTable();
    adaptor.Fill(tablo);

    GridView g = new GridView();
    g.DataSource = tablo;
    g.DataBind();

    StringWriter sw = new StringWriter();
    HtmlTextWriter ht = new HtmlTextWriter(sw);
    g.RenderControl(ht);
    sw.ToString().Dump("gridliformatted");
}
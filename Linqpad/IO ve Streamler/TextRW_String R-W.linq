<Query Kind="Program">
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

/*Cümleyi split etmnini bir alternatifi
The StringReader and StringWriter classes, also derived from TextReader and TextWriter, are mainly used to manipulate strings rather than files. 
The StringWriter class is used to write to a StringBuilder class (from the System.Text namespace). Since strings in C# are immutable, 
the StringBuilder class is used to build a string efficiently
Use these streams if you are dealing with many string manipulations (e.g., a text-to-HTML parser).

SW birçok diğer sınıfla birlitke kullanılabilir, html,xml v.s. genelde bu sınıfların neslesi oluşturulurken parametre olarak verilyor
*/
static void Main()
    {
       const string _input = @"Dot Net Perls 
                                        is a website
                                        you are reading";
        // Creates new StringReader instance from System.IO
        using (StringReader reader = new StringReader(_input))
        {//reader tek başına
            // Loop over the lines in the string.
            int count = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                count++;
                Console.WriteLine("Line {0}: {1}", count, line);
            }
        }
        //2.metod     
        StringRW _ =new StringRW(); //nesneyi yaratmam yeterli, constructurda metodlar çarğılıyor
		
		//3.metod
		another();
             
    }
       
public class StringRW
{
    StringBuilder sb = new StringBuilder();
    public StringRW()
    {
        //Call the Writer Method
        Writer();

        //Call the Reader Method
        Reader();
    }

    //Writer Method
    private void Writer()
    {//writer stringbuilder ile birlitke
        StringWriter sw = new StringWriter(sb);
        Console.WriteLine("Welcome to the Profile Program");
        Console.Write("Name :");

        //Get the name from the console
        string name = Console.ReadLine();

        //Write to StringBuilder
        sw.WriteLine("Name :" + name);
        Console.Write("Country :");
        string country = Console.ReadLine();

        //Write to StringBuilder
        sw.WriteLine("Country :" + country);
        Console.Write("Age :");
        string age = Console.ReadLine();

        //Write to StringBuilder-ilk grişte almıştı bunu
        sw.WriteLine("Age :" + age);
        Console.WriteLine("Thank You");
        Console.WriteLine("Information Saved!");
        Console.WriteLine();

        //Close the stream
        sw.Flush();
        sw.Close();
        Console.ReadLine();
    }

    private void Reader()
    {
        StringReader sr = new StringReader(sb.ToString());
        Console.WriteLine("Reading Profile");

        //Peek to see if the next character exists
        while (sr.Peek() > -1)
        {
            //Read a line from the string and display it on the
            //console
            Console.WriteLine(sr.ReadLine());
        }

        Console.WriteLine("Data Read Complete!");
        //Close the string
        sr.Close();
           }
}


static void another()
    {
        string textReaderText = "TextReader is the abstract base " +
            "class of StreamReader and StringReader, which read " +
            "characters from streams and strings, respectively.\n\n" +

            "Create an instance of TextReader to open a text file " +
            "for reading a specified range of characters, or to " +
            "create a reader based on an existing stream.\n\n" +

            "You can also use an instance of TextReader to read " +
            "text from a custom backing store using the same " +
            "APIs you would use for a string or a stream.\n\n";

        Console.WriteLine("Original text:\n\n{0}", textReaderText);

        // From textReaderText, create a continuous paragraph 
        // with two spaces between each sentence.
        string aLine, aParagraph = null;
        StringReader strReader = new StringReader(textReaderText);
        while(true)
        {
            aLine = strReader.ReadLine();
            if(aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";
            }
            else
            {
                aParagraph = aParagraph + "\n";
                break;
            }
        }
        Console.WriteLine("Modified text:\n\n{0}", aParagraph);

        // Re-create textReaderText from aParagraph.
        int intCharacter;
        char convertedCharacter;
        StringWriter strWriter = new StringWriter();
        strReader = new StringReader(aParagraph);
        while(true)
        {
            intCharacter = strReader.Read();

            // Check for the end of the string 
            // before converting to a character.
            if(intCharacter == -1) break;

            convertedCharacter = Convert.ToChar(intCharacter);
            if(convertedCharacter == '.')
            {
                strWriter.Write(".\n\n");

                // Bypass the spaces between sentences.
                strReader.Read();
                strReader.Read();
            }
            else
            {
                strWriter.Write(convertedCharacter);
            }
        }
        Console.WriteLine("\nOriginal text:\n\n{0}", 
            strWriter.ToString());
    }
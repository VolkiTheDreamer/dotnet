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

static void Main()
{
       KlasorSec();
       DosyaSec();
}

static void KlasorSec() {
       FolderBrowserDialog fbd = new FolderBrowserDialog();
       DialogResult result = fbd.ShowDialog();
       if (result == DialogResult.OK)
       {
           fbd.SelectedPath.Dump();
       }
}

static void DosyaSec() {
       OpenFileDialog fd = new OpenFileDialog();
       DialogResult result = fd.ShowDialog(); // Show the dialog.
       if (result == DialogResult.OK) // Test result.
       {
          string file = fd.FileName;
          file.Dump();
          try
          {
             string text = File.ReadAllText(file);
             int size = text.Length;
               size.Dump();
               text.Dump();
          }
          catch (IOException)
          {
          }
       }
}
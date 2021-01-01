using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using MyUDFs;
using System.Resources;
using System.Reflection;
using System.Diagnostics;

namespace VSTO_UDF
{    
    public partial class ThisAddIn
    {        
        MyFunctions functionsAddinRef = null;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            MyUDFYukle();
            VBA_Addin_Yukle("VBAAddinForVstoUdf.xlam");
        }

        private void MyUDFYukle()
        {
            functionsAddinRef = new MyFunctions();
            string NAME = functionsAddinRef.GetType().Namespace + "." + functionsAddinRef.GetType().Name;
            string GUID = functionsAddinRef.GetType().GUID.ToString().ToUpper();

            // is the add-in already loaded in Excel, but maybe disabled
            // if this is the case - try to re-enable it
            bool fFound = false;
            foreach (Excel.AddIn a in Application.AddIns)
            {
                try
                {
                    if (a.CLSID.Contains(GUID))
                    {
                        fFound = true;
                        if (!a.Installed)
                            a.Installed = true;
                        break;
                    }
                }
                catch { }
            }

            //if we do not see the UDF class in the list of installed addin we need to
            // add it to the collection
            if (!fFound)
            {
                // first register it
                functionsAddinRef.Register();
                // then install it
                this.Application.AddIns.Add(NAME).Installed = true; //Bunlarda Namespace.Class şekilnde eklemek yeterli
            }

            ///checki manuel kaldırınca gitmemesinin sebei ne? unregister laızm mı bi yerde? vbadeki uninstall eventi gibi bişeye mi yamzk lazm veya brdaki shutdown?
        }

       

        private void VBA_Addin_Yukle(string vbaAddin)
        {
            //ilk kurulduğunda var mı diye baksın, varsa işaretli mi yani installed mu diye de baksın
            bool isExist=false;
            foreach (Excel.AddIn a in Application.AddIns)
            {                
                if (a.Name==vbaAddin) //listede varsa ve kurulu değilse kur ve çık, kuruluysa bişey yapmadan çık
                {      
                    if (!a.Installed)
                        a.Installed = true;
                    isExist = true;
                    break;
                }                
            }

            if (isExist==false)
                this.Application.AddIns.Add(@"E:\OneDrive\Dökümanlar\GitHub\dotnet\Ugulamalar\VSTO_UDF\Resources\VBAAddinForVstoUdf.xlam").Installed = true; //ekle ve kur tek satırda
        }
                //catch (Exception ex)
                //{
                //    System.Windows.Forms.MessageBox.Show(ex.Message);
                //}

    //try
    //{
    //    //if (this.Application.Workbooks[this.Application.AddIns[vbaAddin].Name].Name.Length>0)//addin kurulu mu demenin en safe yolu
    //    if (this.Application.AddIns[vbaAddin].Installed==false)
    //    {
    //        ResourceManager rm = new ResourceManager("VSTO_UDF.Resource1",Assembly.GetExecutingAssembly());
    //        string a= rm.BaseName;                    
    //        string strName = rm.GetString(vbaAddin);                               
    //        Excel.AddIn xaddin = this.Application.AddIns.Add(@"C:\\users\volka\dekstop\VBAAddinForVstoUdf.xlam");  ///dinamik                  
    //        xaddin.Installed = true;                    
    //    }
    //}
    //catch (Exception ex)
    //{
    //    System.Windows.Forms.MessageBox.Show(ex.ToString());
    //}


        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace VSTOWorkbook
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            //Globals.ThisWorkbook.Application
        }


        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            if (this.toggleButton1.Checked)
            {
                Globals.ThisWorkbook.Application.DisplayDocumentActionTaskPane = true;                
            }
            else
            {
                Globals.ThisWorkbook.Application.CommandBars["Task Pane"].Visible = false;
            }
        }
    }
}

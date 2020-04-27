using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace MyFirstAddin
{
    public partial class MyRibbon
    {
        private void MyRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RibbonControlEventArgs e)
        {
            if (Globals.ThisAddIn._MyCustomTaskPane != null)
            {
                Globals.ThisAddIn._MyCustomTaskPane.Visible = true;
            }
        }

        private void btnClose_Click(object sender, RibbonControlEventArgs e)
        {
            if (Globals.ThisAddIn._MyCustomTaskPane != null)
            {
                Globals.ThisAddIn._MyCustomTaskPane.Visible = false;
            }
        }
    }
}

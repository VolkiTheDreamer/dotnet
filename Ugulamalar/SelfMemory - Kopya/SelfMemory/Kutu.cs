using System;
using System.Windows.Forms;
using System.Drawing;


namespace SelfMemory
{
    class Kutu : PictureBox
    {
        public Kutu()
        {
            //Image = Bitmap.FromResource(,Properties.Resources.arkaplan.ToString());
            //Image = Bitmap.FromFile(Properties.Resources.arkaplan.ToString());
            this.Image = (Image)Properties.Resources.arkaplan;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }


    }
}

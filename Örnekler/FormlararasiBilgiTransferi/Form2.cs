using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormlararasiBilgiTransferi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        //1.yöntem
        public Form2(string strTextBox)
        {
            InitializeComponent();
            label1.Text = strTextBox;
        }


        //2.yötntem
        private void Form2_Load(object sender, EventArgs e)
        {            
            //1.yöntem denenirse sıkınt yaratmasın diye null kontrolü
            if (frm1 != null)
            { label2.Text = ((Form1)frm1).textBox2.Text; }
        }

        //3.yöntem
        public string Labelmetin3
        {
            set
            {
                label3.Text = value;
            }
        }

        //4.yöntem
        public void MetinTransfer(TextBox txtfromForm1)
        {
            label4.Text = txtfromForm1.Text;
        }
    }
}

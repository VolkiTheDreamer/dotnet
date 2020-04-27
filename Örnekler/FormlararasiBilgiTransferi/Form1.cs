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
//http://www.c-sharpcorner.com/article/passing-data-between-forms/
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(textBox1.Text);
            frm2.Show(); 
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            //Form1in deginerında textbox2 manuel publix yplıdı
            //form2nin designerında da manuel frm1  nesnesi ayratıldı
            Form2 frm2 = new Form2();
            frm2.frm1 = this;
            frm2.Show();
        }


        //3.yöntem:Property:benim seflmemoryde kullandığım yöntem buydu
        public string TextBoxMetin3
        {
            get
            {
                return textBox3.Text;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Labelmetin3= TextBoxMetin3;
            frm2.Show();
        }

        //4.yöntem:DElegate
        public delegate void delPassData(TextBox text);

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            delPassData del = frm2.MetinTransfer;
            del(this.textBox4);
            frm2.Show();
        }

        //5.yöntem: bu benim yöntemim, linkte veirlensitede yoktu. public yaptıgın için kötü ama kabul edilebilir bi yöntem
        private void button5_Click(object sender, EventArgs e)
        {
            //frmo2 desingnerda label5 public yaptım
            string metin = textBox5.Text;
            Form2 frm2 = new Form2();
            frm2.label5.Text = metin;
            frm2.Show();
        }
    }
}

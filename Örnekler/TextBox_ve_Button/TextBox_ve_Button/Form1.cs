using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextBox_ve_Button
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) MessageBox.Show("Enter tuşuna basıldı");
            MessageBox.Show(e.KeyChar + " tuşuna basıldı");
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
            textBox1.Text = "Telefon nosunun başında 0 olmadan yazınız";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("en az 3 karakter girin");
                textBox1.Focus();
            }
            textBox1.BackColor = Color.White;
        }

        private void textBox2_Validated(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bu alanı boş geçemezsiniz");
                textBox2.Focus();
            }
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) MessageBox.Show("Kayıt yapıldı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıt yapıldı");
        }

   

    

 
    }
} 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopMostImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.label1.Text = "";
                BackgroundImage = Clipboard.GetImage();
                this.textBox1.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.label1.Text = "Hafızadaki resmi almak için sağ tık. Textboxı yoketmek için sol tuş";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.textcontent = this.textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.textcontent !=null)
            {
                this.textBox1.Text = Properties.Settings.Default.textcontent;
            }
            await PeriodicFooAsync(1000 * 60 * 30);
        }

        private async Task PeriodicFooAsync(int interval)
        {
            await Task.Delay(interval);
            this.Activate();
            this.WindowState = FormWindowState.Normal;
            await PeriodicFooAsync(1000 * 60 * 30);

        }
    }
}

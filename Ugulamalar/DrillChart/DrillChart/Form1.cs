using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrillChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Minimum = 1;
            numericUpDown1.ValueChanged += (s, e) => { numericUpDown1_ValueChanged(s, e); };
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Width = Width - 40;
            pictureBox1.Height = Height - 150;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1_ResizeEnd(this,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                openFileDialog1.Filter = ".las files|*.las";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog1.FileName;
                    textBox1.Text = filename;
                    toolStripStatusLabel1.Text = filename;

                }
                else
                {
                    toolStripStatusLabel1.Text = "Dosya seçilmedi";
                }
            }
            DrawChart();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DrawChart();
        }

        private void DrawChart()
        {
            DrillChart dc = new DrillChart(textBox1.Text, Convert.ToInt16(numericUpDown1.Value), Convert.ToInt16( (textBox2.Text==""?"-1":textBox2.Text)), Convert.ToInt16((textBox3.Text == "" ? "-1" : textBox3.Text)));
            numericUpDown1.Maximum = dc.Properties.NumFields;

            //Controls.Add(dc.CreateChart()); pictureBox1.Visible = false;
            pictureBox1.Image = dc.CreateImage();
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
            toolStripStatusLabel1.Text = "Resim kopyalandı";
        }
    }
}

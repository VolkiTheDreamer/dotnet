﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSTOcsharp
{
    public partial class RenkliTextBox : UserControl
    {
        public RenkliTextBox() //constructor metod
        {
            InitializeComponent();
            this.textBox1.ForeColor = Color.Red;
        }
    }
}
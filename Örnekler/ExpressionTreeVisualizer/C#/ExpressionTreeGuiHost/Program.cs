﻿//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuiHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
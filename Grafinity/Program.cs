﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Grafinity
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

            Form1 form = new Form1();

            Application.Run(form);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RakenduseLoomine_Valkrusman.PildidApp;

namespace RakenduseLoomine_Valkrusman
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new mäng());

          //  Application.Run(new PildidApp());

        }
    }
}

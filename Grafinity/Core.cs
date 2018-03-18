using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Grafinity
{
    static class Core
    {
        public static void Execute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GrafinityWindow form = new GrafinityWindow();

            Application.Run(form);
        }

        public static void Save()
        {
            ImageManager.SaveScreen(); // add bitmap as argument
        }

        public static void GetFiles()
        {
            ImageManager.GetFiles(); // get all graphical files in folder
        }

        public static void Capture()
        {
            ImageCapturer.Capture();
        }

        public static void BW()
        {
            ImageManipulator.BlackWhite();
        }

        public static void Negative()
        {
            ImageManipulator.Negative();
        }

        public static void Sepia()
        {
            ImageManipulator.Sepia();
        }
    }
}

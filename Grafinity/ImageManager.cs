using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;

namespace Grafinity
{
    /// <summary>
    /// Class maintaining image files created by this program.
    /// </summary>
    static class ImageManager
    {
        private static string path = ConfigManager.GetPath(); //specify path to the directory
        private static string[] allFiles = Directory.GetFiles(Path, "*", SearchOption.AllDirectories);

        /// <summary>
        /// Path to folder where captured images are stored.
        /// </summary>
        public static string Path { get => path; private set => path = value; }

        /// <summary>
        /// List of all files in folder defined as save destination.
        /// </summary>
        public static string[] AllFiles { get => allFiles; private set => allFiles = value; }

        /// <summary>
        /// Returns list of all images in configured path.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFiles()
        {
            List<string> grphFiles = new List<string>(); //empty list to add images to

            foreach (var file in AllFiles)
            {
                if (file.EndsWith(".png"))// | file.EndsWith(".jpeg") | file.EndsWith(".bmp"))
                {
                    grphFiles.Add(file); // if extension is right, add to the list
                }
            }

            return grphFiles;
        }

        /// <summary>
        /// Capture screen and store it in a configured path
        /// </summary>
        /// <param name="screenshot"></param>
        public static string SaveName( )
        {
            string saveName = ConfigManager.GetPath() + "\\" + String.Format("{0}_{1}.png", "Screen", DateTime.Now.ToString("MM/dd_H_mm_s")); // generic name + current date
            return saveName;
        }
    }
}
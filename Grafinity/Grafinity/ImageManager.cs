using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Grafinity
{
    static class ImageManager
    {
        static string path = @"C:\1"; //specify path to the directory
        static string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        public static void GetFiles()
        {
            List<string> grphFiles = new List<string>(); //empty list to add images to
            foreach (var file in allFiles)
            {
                if (file.EndsWith(".png") | file.EndsWith(".jpeg") | file.EndsWith(".bmp"))
                    grphFiles.Add(file); // if extension is right, add to the list
            }
            foreach (var item in grphFiles)
            {
                Console.WriteLine(item); 
            }
        }
        public static void SaveScreen(Bitmap screenshot)
        {
            string screenName = "Screen"; 
            DateTime date = DateTime.Now;
            string saveName = String.Format("{0}_{1}.png", screenName, date.ToString("MM/dd_H_mm_s")); // generic name + current date
            string savePath = String.Format(@"C:\1\{0}", saveName);
            screenshot.Save(savePath, ImageFormat.Png);
        }
        //public static void SaveScreen_BW(Bitmap screenshot)
        //{
        //    string screenName = "BWScreen";
        //    DateTime date = DateTime.Now;
        //    string saveName_BW = String.Format("{0}_{1}.png", screenName, date.ToString("MM/dd_H_mm_s")); // generic name + current date
        //    string savePath_BW = String.Format(@"C:\1\{0}", saveName_BW);
        //    screenshot.Save(savePath_BW, ImageFormat.Png);
        //}
    }
}

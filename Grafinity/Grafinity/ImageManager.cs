using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Grafinity
{
    static class ImageManager
    {
        static string path = ConfigManager.GetPath(); //specify path to the directory
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
            string savePath = path;
            screenshot.Save(savePath);
        }
    }
}
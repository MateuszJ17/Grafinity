using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Grafinity
{
    static class ImageManager
    {
        static string path = ConfigManager.GetPath(); //specify path to the directory
        static string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

        public static ImageList GetFiles()
        {
            List<string> grphFiles = new List<string>(); //empty list to add images to
            ImageList imgs = new ImageList();
            foreach (var file in allFiles)
            {
                if (file.EndsWith(".png") | file.EndsWith(".jpeg") | file.EndsWith(".bmp"))
                //grphFiles.Add(file); // if extension is right, add to the list
                imgs.ImageSize = new Size(100, 100);
                imgs.Images.Add(Image.FromFile(path)); // specify path if its wrong
            }
            foreach (var item in grphFiles)
            {
                Console.WriteLine(item);
            }
            return imgs;
        }
        public static void SaveScreen(Bitmap screenshot)
        {
            DateTime date = DateTime.Now;
            string saveName = String.Format("{0}_{1}.png", "Screen", date.ToString("MM/dd_H_mm_s")); // generic name + current date
            screenshot.Save(path);
        }
    }
}
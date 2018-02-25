using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Grafinity
{
    static class ImageManager
    {
        public static void GetFiles()
        {
            List<string> grphFiles = new List<string>(); //empty list to add images to
            string path = @"C:\1"; //specify path to the directory
            var allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
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
    }
}

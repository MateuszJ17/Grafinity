using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Grafinity
{
    static class ImageManipulator
    {
        public static void BlackWhite()
        {
            Bitmap screenshot = new Bitmap(@"C:\1\Test.png");
           

            for (int i = 0; i < screenshot.Width; i++)
            {
                for (int j = 0; j < screenshot.Height; j++)
                {
                    Color c = screenshot.GetPixel(i, j);

                    //Apply conversion equation
                    byte gray = (byte)(.21 * c.R + .71 * c.G + .071 * c.B);

                    //Set the color of this pixel
                    screenshot.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            screenshot.Save(@"C:\1\test_bw.png", ImageFormat.Png);
        }


    }
}

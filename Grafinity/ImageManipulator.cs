using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Grafinity
{
    /// <summary>
    /// Class containing functions for captured image manipulation.
    /// </summary>
    static class ImageManipulator
    {
        /// <summary>
        /// Turns an image into grayscale alternative.
        /// </summary>
        /// <returns></returns>
        public static Bitmap BlackWhite(Bitmap screenshot)
        {
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
            //screenshot.Save(@"C:\1\test_bw.png", ImageFormat.Png);
            return screenshot;
        }

        /// <summary>
        /// Reverses colors of an image.
        /// </summary>
        /// <returns></returns>
        public static Bitmap Negative(Bitmap screenshot)
        {
            Color c;

            for (int i = 0; i < screenshot.Width; i++)
            {
                for (int j = 0; j < screenshot.Height; j++)
                {
                    c = screenshot.GetPixel(i, j);
                    c = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
                    screenshot.SetPixel(i, j, c);
                }
            }
            //screenshot.Save(@"C:\1\test_negative.png", ImageFormat.Png);
            return screenshot;
        }

        /// <summary>
        /// Apply sepia effect to an image.
        /// </summary>
        /// <returns></returns>
        public static Bitmap Sepia(Bitmap screenshot)
        {
            Color p;

            int a, r, g, b, tr, tg, tb;
            for (int i = 0; i < screenshot.Height; i++)
            {
                for (int j = 0; j < screenshot.Width; j++)
                {
                    p = screenshot.GetPixel(j, i);

                    a = p.A;
                    r = p.R;
                    g = p.G;
                    b = p.B;

                    tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    r = Math.Min(255, tr);
                    g = Math.Min(255, tg);
                    b = Math.Min(255, tb);

                    screenshot.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                }
            }
            //screenshot.Save(@"C:\1\test_sepia.png", ImageFormat.Png);
            return screenshot;
        }

    }
}

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
        public static Bitmap BlackWhite()
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
            //screenshot.Save(@"C:\1\test_bw.png", ImageFormat.Png);
            return screenshot;
        }

        public static Bitmap Negative()
        {
            Bitmap screenshot = new Bitmap(@"C:\1\Test.png");
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

        public static Bitmap Sepia()
        {
            Color p;
            Bitmap screenshot = new Bitmap(@"C:\1\Test.png");
            //sepia
            for (int i = 0; i < screenshot.Height; i++)
            {
                for (int j = 0; j < screenshot.Width; j++)
                {
                    p = screenshot.GetPixel(j, i);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    screenshot.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                }
            }
            //screenshot.Save(@"C:\1\test_sepia.png", ImageFormat.Png);
            return screenshot;
        }

    }
}

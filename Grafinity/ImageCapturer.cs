using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Grafinity
{
    static class ImageCapturer
    {
        public static Bitmap Capture()
        {
            var scrshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, //creating new bitmap
                              Screen.PrimaryScreen.Bounds.Height,
                              PixelFormat.Format32bppArgb);

            var gfxScreenshot = Graphics.FromImage(scrshot); //creating graphics object from bitmap

            gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, //scrnshot from upper left to bottom right
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0,
                                        0,
                                        Screen.PrimaryScreen.Bounds.Size,
                                        CopyPixelOperation.SourceCopy);
            
            ImageManager.SaveScreen(scrshot);

            string mode = ConfigManager.GetMode();

            return scrshot;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;


namespace GrafinityFrontend
{
    class GrafinityWindow : Form
    {
        public GrafinityWindow()
        {
            Height = 550;
            Width = 550;

            ///////////MENU///////////
            MenuStrip menu = new MenuStrip { Parent = this };
            ToolStripMenuItem file = new ToolStripMenuItem { Text = "File" };
            ToolStripMenuItem capture = new ToolStripMenuItem
            {
                Text = "Capture",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.C)))
            };
            ToolStripMenuItem save = new ToolStripMenuItem
            {
                Text = "Save",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.S)))
            };
            ToolStripMenuItem choosedirectory = new ToolStripMenuItem
            {
                Text = "Save directory...",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.D)))
            };
            ToolStripMenuItem choosemode = new ToolStripMenuItem { Text = "Screenshot mode" };
            ToolStripMenuItem grayscale = new ToolStripMenuItem
            {
                Text = "Grayscale",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.D1)))
            };
            ToolStripMenuItem bW = new ToolStripMenuItem
            {
                Text = "BW",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.D2)))
            };        
            ToolStripMenuItem sepia = new ToolStripMenuItem
            {
                Text = "Sepia",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.D3)))
            };
            ToolStripMenuItem negative = new ToolStripMenuItem
            {
                Text = "Negative",
                ShortcutKeys = ((Keys)((Keys.Control | Keys.D4)))
            };
            ToolStripMenuItem sort = new ToolStripMenuItem { Text = "Sort" };
            ToolStripMenuItem byName = new ToolStripMenuItem { Text = "By Name" }; 
            ToolStripMenuItem byDate = new ToolStripMenuItem { Text = "By Date" };
            ToolStripMenuItem about = new ToolStripMenuItem { Text = "About" };

            //Add items to menu
            menu.Items.AddRange(new ToolStripItem[] { file, sort, about });
            file.DropDownItems.AddRange(new ToolStripItem[] { capture, save, choosedirectory, choosemode });
            choosemode.DropDownItems.AddRange(new ToolStripItem[] { grayscale, bW, sepia, negative });
            sort.DropDownItems.AddRange(new ToolStripItem[] { byName, byDate });
            ///////////MENU///////////

            Label screenlabel = new Label
            {
                AutoSize = true,
                Location = new Point(225, 30),
                Parent = this,
                Text = "Your screenshot"
            };

            PictureBox screenbox = new PictureBox
            {
                Parent = this,
                Location = new Point(125, 50),
                Height = 200,
                Width = 300
            };

            ///////FUNCTIONALITY///////
            screenbox.Click += (o, i) =>
            {
                Console.WriteLine("Saving...");                
            };

            void DisplayScreenshot()
            {
                if (File.Exists(ConfigManager.GetPath() + "\\Przechwytywanie.png"))
                {
                    Image image = Image.FromFile(ConfigManager.GetPath() + "\\Przechwytywanie.png");
                    Rectangle destRect = new Rectangle(0, 0, 300, 200);
                    Bitmap destImage = new Bitmap(300, 200);
                    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                    using (Graphics graphics = Graphics.FromImage(destImage))
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                        using (ImageAttributes wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }
                    SolidBrush myBrush = new SolidBrush(Color.FromArgb(22, 33, 33, 33));
                    Graphics formGraphics;
                    formGraphics = CreateGraphics();
                    formGraphics.FillRectangle(myBrush, new Rectangle(120, 45, 310, 210));
                    myBrush.Dispose();
                    formGraphics.Dispose();
                    screenbox.Image = destImage;
                }
            }

            capture.Click += (o, i) =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("Capturing...");
                DisplayScreenshot();
            };

            save.Click += (o, i) =>
            {
                Console.WriteLine("Saving...");
            };

            choosedirectory.Click += (o, i) =>
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                string path = "";

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    path = browser.SelectedPath;
                    ConfigManager.UpdatePath(path);
                }
            };

            grayscale.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("Grayscale");
            };
            bW.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("BW");
            };
            sepia.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("Sepia");
            };
            negative.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("Negative");
            };
            about.Click += (o, i) =>
            {
                MessageBox.Show("        Created by Liamky and Sneaky17");
            };
            ///////FUNCTIONALITY///////
        }
    }
}

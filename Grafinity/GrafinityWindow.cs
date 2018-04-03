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


namespace Grafinity
{
    class GrafinityWindow : Form
    {
        public GrafinityWindow()
        {
            Height = 620;
            Width = 530;

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
                Text = "Your screenshot",
                Visible = false
            };

            Label foldelabel = new Label
            {
                AutoSize = true,
                Location = new Point(160, 255),
                Parent = this,
                Text = "Other image files in the desired directory",
                Visible = true
            };
            PictureBox screenbox = new PictureBox
            {
                Parent = this,
                Location = new Point(110, 50),
                Height = 200,
                Width = 300,
                BackColor = Color.FromArgb(255, 233, 233, 233),
                BorderStyle = BorderStyle.Fixed3D
            };

            Panel imagePanel = new Panel
            {
                Parent = this,
                Location = new Point(10, 275),
                Height = 300,
                Width = 500,
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.Fixed3D
            };

            imagePanel.AutoScroll = false;
            imagePanel.HorizontalScroll.Enabled = false;
            imagePanel.HorizontalScroll.Visible = false;
            imagePanel.HorizontalScroll.Maximum = 0;
            imagePanel.AutoScroll = true;


            ///////FUNCTIONALITY///////

            void DisplayScreenshot()
            {
                Image image = Image.FromFile(ConfigManager.GetPath() + "\\przechwytywanie.png");
                screenbox.Image = ResizeImage(image, 300, 200);
            }

            void DisplayOther()
            {
                imagePanel.Controls.Clear();
                int x = 5;
                int y = 5;

                //placeholder until ImageManager is corrected
                List<string> grphFiles = new List<string>
                {
                    ConfigManager.GetPath() + "\\przechwytywanie.png",
                    ConfigManager.GetPath() + "\\przechwytywanie2.png",
                    ConfigManager.GetPath() + "\\przechwytywanie3.png",
                    ConfigManager.GetPath() + "\\przechwytywanie4.png",
                    ConfigManager.GetPath() + "\\przechwytywanie5.png",
                    ConfigManager.GetPath() + "\\przechwytywanie6.png",
                    ConfigManager.GetPath() + "\\przechwytywanie7.png",
                    ConfigManager.GetPath() + "\\przechwytywanie8.png",
                    ConfigManager.GetPath() + "\\przechwytywanie9.png"
                };

                //foreach (string path in ImageManager.GetFiles())
                foreach (string path in grphFiles)
                {
                    Image img = Image.FromFile(path);
                    PictureBox pic = new PictureBox
                    {
                        Image = ResizeImage(img, 150, 100),
                        Size = new Size(150, 100)
                    };

                    if (x + pic.Width > imagePanel.Width)
                    {
                        x = 5;
                        y += 110;
                    }

                    pic.Location = new Point(x, y);
                    x += pic.Width + 10;

                    imagePanel.Controls.Add(pic);
                }
            }

            Bitmap ResizeImage(Image image, int dw, int dh)
            {
                Rectangle destRect = new Rectangle(0, 0, dw, dh);
                Bitmap destImage = new Bitmap(dw, dh);
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

                return destImage;
            }

            capture.Click += (o, i) =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("Capturing...");
                screenlabel.Visible = true;
                DisplayScreenshot();
            };

            save.Click += (o, i) => Console.WriteLine("Saving...");

            choosedirectory.Click += (o, i) =>
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                browser.SelectedPath = ConfigManager.GetPath();

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    ConfigManager.UpdatePath(browser.SelectedPath);
                }

                DisplayOther();
            };

            grayscale.Click += (o, i) => ConfigManager.UpdateMode("Grayscale");
            bW.Click += (o, i) => ConfigManager.UpdateMode("BW");
            sepia.Click += (o, i) => ConfigManager.UpdateMode("Sepia");
            negative.Click += (o, i) => ConfigManager.UpdateMode("Negative");
            about.Click += (o, i) => MessageBox.Show("        Created by Liamky and Sneaky17");
            ///////FUNCTIONALITY///////
        }
    }
}

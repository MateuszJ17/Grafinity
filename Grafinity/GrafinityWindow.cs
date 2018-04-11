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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Bitmap scrshot = new Bitmap(1, 1);

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

            ToolStripMenuItem normal = new ToolStripMenuItem
            {
                Text = "Normal",
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

            ToolStripMenuItem about = new ToolStripMenuItem { Text = "About" };

            //Add items to menu
            menu.Items.AddRange(new ToolStripItem[] { file, about });
            file.DropDownItems.AddRange(new ToolStripItem[] { capture, save, choosedirectory, choosemode });
            choosemode.DropDownItems.AddRange(new ToolStripItem[] { normal, bW, sepia, negative });
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

            void DisplayScreenshot(Bitmap bitmap)
            {
                Image image = bitmap;
                screenbox.Image = ResizeImage(image, 300, 200);
            }
            
            void DisplayOther()
            {
                imagePanel.Controls.Clear();
                int x = 5;
                int y = 5;
                
                foreach (string path in ImageManager.GetFiles())
                {
                    Console.WriteLine(path);
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
                scrshot = ImageCapturer.Capture();
                Thread.Sleep(1500);
                screenlabel.Visible = true;
                switch (ConfigManager.GetMode())
                {
                    case "Negative":
                        {
                            ImageManipulator.Negative(scrshot);                         
                        }
                        break;
                    case "Sepia":
                        {
                            ImageManipulator.Sepia(scrshot);
                        }
                        break;
                    case "BW":
                        {
                            ImageManipulator.BlackWhite(scrshot);
                        }
                        break;
                }
                DisplayScreenshot(scrshot);
            };

            save.Click += (o, i) =>
            {
                scrshot.Save(ImageManager.SaveName(), ImageFormat.Png);
            };

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

            normal.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("Normal");
                DisplayScreenshot(scrshot);
            };
            bW.Click += (o, i) =>
            {
                ConfigManager.UpdateMode("BW");
                DisplayScreenshot(ImageManipulator.BlackWhite(scrshot));
            };
            sepia.Click += (o, i) =>
            {
                DisplayScreenshot(ImageManipulator.Sepia(scrshot));
                ConfigManager.UpdateMode("Sepia");
            };
            negative.Click += (o, i) =>
            {
                DisplayScreenshot(ImageManipulator.Negative(scrshot));
                ConfigManager.UpdateMode("Negative");
            };
            about.Click += (o, i) => MessageBox.Show("        Created by Liamky and Sneaky17");
            ///////FUNCTIONALITY///////
        }
    }
}

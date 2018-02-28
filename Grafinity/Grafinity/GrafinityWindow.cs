using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Grafinity
{
    class GrafinityWindow : Form
    {
        public GrafinityWindow()
        {
            Height = 150;
            Width = 310;

            Button screenshot = new Button
            {
                Parent = this,
                Width = 90,
                Height = 50,
                Text = "Capture",
                Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\camera.png"),
                TextAlign = ContentAlignment.MiddleRight,
                ImageAlign = ContentAlignment.MiddleLeft
            };

            //Podpiac screenshot
            screenshot.Click += (o, i) =>
            {
                
            };

            Button savescreen = new Button
            {
                Parent = this,
                Left = 90,
                Width = 80,
                Height = 50,
                Text = "Save",
                Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\floppy.png"),
                TextAlign = ContentAlignment.MiddleRight,
                ImageAlign = ContentAlignment.MiddleLeft
            };

            savescreen.Click += (o, i) =>
            {
                FolderBrowserDialog browser = new FolderBrowserDialog();
                string path = "";

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    path = browser.SelectedPath;
                    ConfigManager.UpdatePath(path);
                }              
            };

            ComboBox chmode = new ComboBox
            {
                Parent = this,
                Left = 170
            };

            chmode.Items.Add("Normal");
            chmode.Items.Add("Grayscale");
            chmode.Items.Add("Sepia");
            chmode.Items.Add("Negative");

            chmode.SelectedValueChanged += (o, i) =>
            {
                Object selectedItem = chmode.SelectedItem;
                ConfigManager.UpdateMode(selectedItem.ToString());
            };

        }
    }
}

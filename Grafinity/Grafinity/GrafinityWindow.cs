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
            Width = 350;

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

            ///////FUNCTIONALITY///////
            capture.Click += (o, i) =>
            {
                Console.WriteLine("Capturing...");
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
            ///////FUNCTIONALITY///////
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafinity
{
    class GrafinityWindow : Form
    {
        public GrafinityWindow()
        {
            Button screenshot = new Button();
            screenshot.Parent = this;
            screenshot.Left = 20;
            ComboBox comboBox1 = new ComboBox();
            comboBox1.Parent = this;
            comboBox1.Left = 100;
            comboBox1.Items.Add("Normal Screenshot");
        }
    }
}

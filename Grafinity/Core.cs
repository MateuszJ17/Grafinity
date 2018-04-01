using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Grafinity
{
    static class Core
    {
        public static void Execute()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GrafinityWindow form = new GrafinityWindow();

            Application.Run(form);

            //TODO: add rest of funcionality
        }

    }
}

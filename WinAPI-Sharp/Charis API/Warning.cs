using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charis
{
    public static class Warning
    {
        public static void Execute(string title, string message)
        {
            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                Environment.Exit(0);
        }
        public static void Execute(string title, string message, MessageBoxIcon icon)
        {
            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo, icon) == DialogResult.No)
                Environment.Exit(0);
        }
    }
}
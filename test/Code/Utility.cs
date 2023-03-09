using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.Code
{
    public class Utility
    {
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OKCancel);
        }
    }
}

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
        public bool ValidateEmpty(string textBoxEmpty,string message)
        {
            if (textBoxEmpty == "")
            {
                ShowMessageBox("Please enter a "+message);
                return true;
            }
            return false;
        }
    }
}

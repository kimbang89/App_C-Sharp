using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace test.View
{
   
    public partial class MessageBoxCus : Form
    {
        private bool ok;
        private bool modeConfirm;
       
        public MessageBoxCus()
        {
            InitializeComponent();
        }
        public bool OK
        {
            get { return ok; }
            set { ok = value; }
        }
        public bool ModeConfirm
        {
            get { return modeConfirm; }
            set { modeConfirm = value; }
        }
        public void InitModeConfirm()
        {
            lbTitle.Text = "Confirm";
            lbTitle.ForeColor = ColorTranslator.FromHtml("#00dfc2");
            lbContent.ForeColor = ColorTranslator.FromHtml("#00dfc2");
            ptError.Visible = false;
            ptWarning.Visible = false;
            ptConfirm.Visible = true;
        }
        public void InitModeWarning()
        {
            lbTitle.Text = "Warning";
            lbTitle.ForeColor = ColorTranslator.FromHtml("#F16767");
            lbContent.ForeColor= ColorTranslator.FromHtml("#F16767");
            ptError.Visible = false;
            ptWarning.Visible = true;
        }
        public string Content
        {
            set { lbContent.Text = value; }
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            if (modeConfirm)
            {
                Exam exam = new Exam();
                exam.ShowDialog();
                return;
            }
            ptError.Visible = true;
            ptWarning.Visible = false;
            ptConfirm.Visible = false;
            this.Close();
            OK= true;
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            ptError.Visible = true;
            ptWarning.Visible = false;
            ptConfirm.Visible = false;
            this.Close();
            OK= false;
        }
    }
}

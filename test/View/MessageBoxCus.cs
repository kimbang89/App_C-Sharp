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
        private bool modeCreate;
       
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
        public bool ModeCreate
        {
            get { return modeCreate; }
            set { modeCreate = value; }
        }
        public void InitModeCreate()
        {
            lbTitle.Text = "CREATE";
            lbTitle.ForeColor = ColorTranslator.FromHtml("#00ABB3");
            tbnameFile.Focus();
            tbnameFile.Visible= true;
            lbContent.Visible= false;
            ptError.Visible = false;
            ptWarning.Visible = false;
            ptConfirm.Visible = false;
            ptExport.Visible = true;
        }
        public void InitModeConfirm()
        {
            lbTitle.Text = "CONFIRM";
            lbTitle.ForeColor = ColorTranslator.FromHtml("#00dfc2");
            lbContent.ForeColor = ColorTranslator.FromHtml("#00dfc2");
            ptError.Visible = false;
            ptWarning.Visible = false;
            ptConfirm.Visible = true;
        }
        public void InitModeWarning()
        {
            lbTitle.Text = "WARNING";
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
            if (modeCreate)
            {
                Main main= new Main();
                main.Hide();
                formCreate fC = new formCreate();
                //xử lý tạo mới excel
                if (fC.LinkFile == "")
                {
                    this.Close();//ẩn form tạo file

                    new formCreate("create");
                    //tạo file excel
                    fC.CreateDataToExcel(tbnameFile.Text, "create");

                    fC.LinkFile = tbnameFile.Text;
                    fC.ShowDialog();
                }
                //xử lý export excel
                else
                {
                    fC.CreateDataToExcel(tbnameFile.Text, "");
                    this.Close();
                }
            }

            this.Close();
            ptError.Visible = true;
            ptWarning.Visible = false;
            ptConfirm.Visible = false;
            ptExport.Visible = false;
            modeConfirm= false;
            modeCreate= false;
            OK= true;
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            if (modeCreate)
            {
                Main main = new Main();
                main.ShowDialog();
            }

            this.Close();
            ptError.Visible = true;
            ptWarning.Visible = false;
            ptConfirm.Visible = false;
            ptExport.Visible = false;
            modeConfirm = false;
            modeCreate = false;
            OK = false;
        }
    }
}

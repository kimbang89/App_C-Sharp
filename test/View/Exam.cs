using Guna.UI2.WinForms;
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
using test.Code;
using static Guna.UI2.Native.WinApi;

namespace test.View
{
    public partial class Exam : Form
    {
        private Utility util= new Utility();
        public Exam()
        {
            InitializeComponent();
        }
        private void btBack_Click(object sender, EventArgs e)
        {
            if (WarningExitTest()==false)
                return;
            timer1.Stop();
            this.Close();
            Main main = new Main();
            main.ShowDialog();
        }
        public bool WarningExitTest()
        {
            DialogResult result = new DialogResult();
            result=MessageBox.Show("Are you sure you want to exit now?","Warning",MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                return true;
            }
            return false;
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            if (WarningExitTest())
                Application.Exit();
        }
        public void ResetRadioBt()
        {
            //radio nào checked thì ẩn, không thì hiện
            foreach (Guna2CustomRadioButton radioButton in panel.Controls.OfType<Guna2CustomRadioButton>())
            {
                if (radioButton.Checked)
                    radioButton.Visible = false;
                else
                    radioButton.Visible = true;
            }
            //ẩn tất cả tick.gif
            foreach (PictureBox pictureBox in panel.Controls.OfType<PictureBox>())
            {
                if (pictureBox.Name == "ptCountdown") //bỏ qua picture clock
                        continue;
                pictureBox.Visible = false;
            }

            foreach (Control control in panel.Controls)
            {
                if (control is Guna2GradientPanel childPanel)//childPanel là biến đại diện cho một control của kiểu Panel trong danh sách các controls con của parentPanel.
                {
                    childPanel.BorderColor = ColorTranslator.FromHtml("#3A98B9");
                }
            }
        }
        private void radioBt_CheckedChanged(object sender, EventArgs e)
        {
            string nameRadioBt = ((Guna2CustomRadioButton)sender).Name;
            ResetRadioBt();
            switch (nameRadioBt)
            {
                case "radioBt1":
                    {
                        tick1.Visible = true;
                        panelAns1.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                    }
                    break;
                case "radioBt2":
                    {
                        tick2.Visible = true;
                        panelAns2.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                    }
                    break;
                case "radioBt3":
                    {
                        tick3.Visible = true;
                        panelAns3.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                    }
                    break;
                case "radioBt4":
                    {
                        tick4.Visible = true;
                        panelAns4.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                    }
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int countdown = int.Parse(lbCountdown.Text.Substring(0, 2));
            lbCountdown.Text = (countdown - 1).ToString() + " S";

            if (countdown <= 30)
            {
                lbCountdown.ForeColor = ColorTranslator.FromHtml("#FFB84C");
            }
            if(countdown<= 15) {
                lbCountdown.ForeColor = ColorTranslator.FromHtml("#DF2E38");
            }
            if (countdown == 0)
            {
                ptCountdown.Visible = false;
                lbCountdown.Visible=false;
                timer1.Stop();
                util.ShowMessageBox("TIME OUT!!!!");
            }
        }

        
    }
}

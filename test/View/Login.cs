using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Code;
using test.View;

namespace test
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSingIn_Click(object sender, EventArgs e)
        {
            ////validate
            //Utility util = new Utility();
            //if (util.ValidateEmpty(tbUserName.Text, "UserName") || util.ValidateEmpty(tbPassWord.Text, "Password"))
            //    return;

            if (Application.OpenForms.Count < 1) // Nếu còn form khác đang mở
            {
                this.Close();
                    
            }
                // Thực hiện ẩn form hiện tại
                this.Hide();//Ẩn form nếu Close sẽ tắt cả CT
                Main main = new Main();
                main.ShowDialog();
    
        }
        private void Application_Idle(object sender, EventArgs e)
        {
            // Huỷ đăng ký sự kiện Application.Idle
            Application.Idle -= Application_Idle;// Sự kiện xảy ra khi ứng dụng rảnh (idle).

            // Tắt chương trình
            Application.Exit();
        }
    }
}

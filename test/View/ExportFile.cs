using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test.View
{
    public partial class ExportFile : Form
    {
      
        public ExportFile()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Main main= new Main();
            main.ShowDialog();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            formCreate fC= new formCreate();
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
                fC.CreateDataToExcel(tbnameFile.Text,"");
                this.Close();
            }
        }
    }
}

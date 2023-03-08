using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Code;

namespace test.View
{
    public partial class formCreate : Form
    {
        private static int rowIndexCurent;
        private DataTable dt;
        private DataRow rowCurrent;
        private static string linkFile;
        public formCreate()
        {
            InitializeComponent();
        }
        private void formCreate_Load(object sender, EventArgs e)
        {
            dt = new DataTable(); //Tạo một DataTable mới để lưu trữ dữ liệu.
            dt.Columns.Add("ID");
            dt.Columns.Add("CONTENT");
            dt.Columns.Add("ANSWER1");
            dt.Columns.Add("ANSWER2");
            dt.Columns.Add("ANSWER3");
            dt.Columns.Add("ANSWER4");
            dt.Columns.Add("CORRECT_ANSWER");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();//Tạo một đối tượng OpenFileDialog mới để cho phép người dùng chọn tệp tin.
            openFile.ShowDialog();//Hiển thị hộp thoại cho phép người dùng chọn tệp tin.
            linkFile = openFile.FileName;//gán linkFile để dùng toàn cục
            if (linkFile != "")
            {
                //textBox1.Text = openFile.FileName;//Hiển thị đường dẫn đến tệp tin đã chọn lên TextBox.
                string etx = Path.GetExtension(linkFile);//lấy kiểu file xls là định dạng cũ, xlsx là mới
                if (etx.ToLower() != ".xls" || etx.ToLower().Equals(".xlsx"))//etx có thể là hoa hoặc thường=>thường
                {
                    var excel = new ExcelQueryFactory(linkFile);// Tạo một đối tượng workBook, chứa các trang tính (workshet)

                    //lấy từng row trong sheet1 trả về một mảng chứa các row kiểu Test(..,..,..)
                    var test = from ts in excel.Worksheet<Test>("Sheet1") select ts;//truy vấn dữ liệu từ Sheet1 trong excel, và lưu kết quả vào biến hocVien.

                    //test là từng row trong workSheet
                    foreach (var item in test)
                    {
                        dt.Rows.Add(item.ID, item.Content, item.Answer1, item.Answer2, item.Answer3, item.Answer4, item.CorrectAnswer);
                    }
                    dt.AcceptChanges();//Xác nhận việc thay đổi dữ liệu trên DataTable.
                    QuestionsDtgv.DataSource = dt;// Gán dữ liệu từ DataTable cho DataSource của DataGridView để hiển thị lên giao diện.
                }
                else
                {
                    MessageBox.Show("choose file Excel ,plese", "Error", MessageBoxButtons.OKCancel);
                }
            }
        }

    }
}

﻿using LinqToExcel;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using OfficeOpenXml;
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
using LinqToExcel.Extensions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test.View
{
    public partial class formCreate : Form
    {
        private static int rowIndexCurent;
        private DataTable dt;
        private DataRow rowCurrent;
        private  string linkFile=Application.StartupPath+ "\\Resources\\TableQuestion.xlsx";
        private Utility util= new Utility();
        public formCreate()
        {
            InitializeComponent();
        }
        //đưa file ngoài vào quản lý
        public formCreate(string linkFile)
        {
            this.linkFile=linkFile;
        }
      
        public bool validateFieldId()
        {
            try
            {
                int.Parse(idQuestion.Text);
                idQuestion.BackColor = Color.Transparent;
                return false;//not error
            }
            catch (FormatException)
            {
                util.ShowMessageBox("         Field ID is not valid! ");//lấy string lỗi
                idQuestion.BackColor = Color.Red;
                idQuestion.Focus();
                return true;//error
            }
        }
        private void formCreate_Load(object sender, EventArgs e)
        {
            content.Focus();
            dt = new DataTable(); //Tạo một DataTable mới để lưu trữ dữ liệu.
            dt.Columns.Add("ID");
            dt.Columns.Add("CONTENT");
            dt.Columns.Add("ANSWER1");
            dt.Columns.Add("ANSWER2");
            dt.Columns.Add("ANSWER3");
            dt.Columns.Add("ANSWER4");
            dt.Columns.Add("CORRECT_ANSWER");
            idAns.SelectedIndex = 0;//mặc định chọn Id Answer là A
            getData();
        }
        public void getData()
        {
            if (linkFile != "")
            {
                //textBox1.Text = openFile.FileName;//Hiển thị đường dẫn đến tệp tin đã chọn lên TextBox.
                string etx = Path.GetExtension(linkFile);//lấy kiểu file xls là định dạng cũ, xlsx là mới
                if (etx.ToLower().Equals(".xlsx"))//etx có thể là hoa hoặc thường=>thường
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
                    questionsDtgv.DataSource = dt;// Gán dữ liệu từ DataTable cho DataSource của DataGridView để hiển thị lên giao diện.
                }
            }
        }
        private void btCreate_Click(object sender, EventArgs e)
        {
            if (validateFieldId())//nếu lỗi thì break;
            {
                return;
            }
            if (idAns.Text != "" && content.Text != "" && ans1.Text != "" && ans2.Text != "" && ans3.Text != "" && ans3.Text != "" )
            {
                dt.Rows.Add(idQuestion.Text, content.Text, ans1.Text,ans2.Text , ans3.Text, ans4.Text, idAns.Text);
                idQuestion.Clear();
                content.Clear();
                ans1.Clear();
                ans2.Clear();   
                ans3.Clear();
                ans4.Clear();
                // Mở tệp Excel
                using (ExcelPackage package = new ExcelPackage(linkFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];//tạo đối tượng bảng tính worksheet
                    int rowCount = worksheet.Dimension.Rows;//số lượng dòng trong bảng tính 
                    //Cells[row,col]
                    //row[nameCol] hiểu là lấy giá trị của nameCol current gán cho row vị trí vế phải
                    worksheet.Cells[rowCount + 1, 1].Value = dt.Rows[rowCount - 1]["ID"];//ô đầu tiên dòng tiếp theo
                    worksheet.Cells[rowCount + 1, 2].Value = dt.Rows[rowCount - 1]["CONTENT"];//ô thứ 2
                    worksheet.Cells[rowCount + 1, 3].Value = dt.Rows[rowCount - 1]["ANSWER1"];//ô thứ 3
                    worksheet.Cells[rowCount + 1, 4].Value = dt.Rows[rowCount - 1]["ANSWER2"];
                    worksheet.Cells[rowCount + 1, 5].Value = dt.Rows[rowCount - 1]["ANSWER3"];
                    worksheet.Cells[rowCount + 1, 6].Value = dt.Rows[rowCount - 1]["ANSWER4"];
                    worksheet.Cells[rowCount + 1, 7].Value = dt.Rows[rowCount - 1]["CORRECT_ANSWER"];

                    package.Save();// Lưu tệp Excel
                }
            }
            else
            {
                util.ShowMessageBox("you haven't entered some fields yet");
            }
        }
        private void questionsDtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //get selected row
            rowIndexCurent = e.RowIndex;
            rowCurrent = dt.Rows[rowIndexCurent];

            //assign textBox
            idQuestion.Text = rowCurrent["ID"].ToString();
            content.Text = rowCurrent["CONTENT"].ToString();
            ans1.Text = rowCurrent["ANSWER1"].ToString();
            ans2.Text = rowCurrent["ANSWER2"].ToString();
            ans3.Text = rowCurrent["ANSWER3"].ToString();
            ans4.Text = rowCurrent["ANSWER4"].ToString();
            idAns.Text = rowCurrent["CORRECT_ANSWER"].ToString();
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            validateFieldId();

            rowCurrent = dt.Rows[rowIndexCurent];
            //update in DataTable
            rowCurrent[0] = idQuestion.Text;
            rowCurrent[1] = content.Text;
            rowCurrent[2] = ans1.Text;
            rowCurrent[3] = ans2.Text;
            rowCurrent[4] = ans3.Text;
            rowCurrent[5] = ans4.Text;
            rowCurrent[6] = idAns.Text;

            //Update in Excel
            // Mở tệp Excel
            using (ExcelPackage package = new ExcelPackage(linkFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];//tạo đối tượng bảng tính worksheet
                //Cells[row,col], cộng 2 vì bỏ qua tiêu đề và excel bắt đầu từ 1
                for(int i = 0; i < 7; i++)
                {
                    worksheet.Cells[rowIndexCurent + 2, (i+1)].Value = rowCurrent[i];
                }
                // Lưu tệp Excel
                package.Save();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // Mở tệp Excel
            using (ExcelPackage package = new ExcelPackage(linkFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];// tạo đối tượng bảng tính worksheet
                //delete row in datatable & Excel
                dt.Rows.RemoveAt(rowIndexCurent);
                worksheet.DeleteRow(rowIndexCurent + 2);//cộng 2 vì bỏ qua tiêu đề và excel bắt đầu từ 1

                package.Save();//lưu để tránh rò rỉ dữ liệu  
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void questionsDtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

       
    }
}
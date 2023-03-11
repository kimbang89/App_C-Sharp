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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test.View
{
    public partial class Main : Form
    {
        private ImageList img;
        private List<string> excelFiles = new List<string>();
        private static string[] files;

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            LoadImageList();

            listTests.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            Color customColor = Color.FromArgb(44, 125, 160);
            listTests.ForeColor = customColor;

            //duyệt show các file
            for (int i = 0; i < files.Length; i++)
            {
                ListViewItem parentItem = new ListViewItem(Path.GetFileNameWithoutExtension(files[i]), i);
                listTests.Items.Add(parentItem);
            }
            //phân quuyền admin user
            //Login login = new Login();
            //if (login.Role != "admin")
            //{
            //    btCreateTest.Visible = false;
            //    btEditTest.Visible = false;
            //}
        }
        public void LoadImageList()
        {
            // Lấy đường dẫn của thư mục đã chọn
            string path = Application.StartupPath + @"\\Resources\\";
            // Lấy danh sách các file Excel trong thư mục
            files = Directory.GetFiles(path, "*.xlsx");
            //thêm vào List để quản lý
            excelFiles.AddRange(files);

            img = new ImageList() { ImageSize = new Size(140, 152) };

            for(int i=0;i<excelFiles.Count; i++)
            {
                img.Images.Add(new Bitmap(Application.StartupPath + "\\image\\test.jpg"));
            }
            listTests.LargeImageList = img;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void listTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btStartTest.FillColor = ColorTranslator.FromHtml("#0093E9");
            btStartTest.FillColor2 = ColorTranslator.FromHtml("#80D0C7");
            btEditTest.FillColor2 = ColorTranslator.FromHtml("#0093E9");
            btEditTest.FillColor = ColorTranslator.FromHtml("#80D0C7");
        }
        private void btEditTest_Click(object sender, EventArgs e)
        {
            //nếu chưa select file thì validate
            if (listTests.SelectedItems.Count < 1)
            {
                MessageBox.Show("Please select the file you want to edit!");
                return;
            }
            this.Hide();//vì không cần dữ liệu form nên dùng Close
            string nameFile= listTests.SelectedItems[0].Text;

            formCreate formCreate = new formCreate();
            formCreate.LinkFile=nameFile;
            formCreate.ShowDialog();
        }
        private void btCreateTest_Click(object sender, EventArgs e)
        {
            this.Hide();

            ExportFile exportFile= new ExportFile();
            exportFile.ShowDialog();

            formCreate formCreate = new formCreate();//issues
            formCreate.ShowDialog();
        }
        private void btStartTest_Click(object sender, EventArgs e)
        {

        }
    }
}

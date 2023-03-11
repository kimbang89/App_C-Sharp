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
            this.Close();
        }
        private void btCreateTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            formCreate formCreate = new formCreate();
            formCreate.ShowDialog();
        }

        private void listTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            btStartTest.FillColor = ColorTranslator.FromHtml("#ff0080");
            btStartTest.FillColor2 = ColorTranslator.FromHtml("#0080ff");

        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using test.Code;
using static Guna.UI2.Native.WinApi;
using static OfficeOpenXml.ExcelErrorValue;

namespace test.View
{
    public partial class Exam : Form
    {
        //Utility
        private AnsModel mapAnswerItem;
        MessageBoxCus messageBoxCus = new MessageBoxCus();
        //Property
        private int indexPageCurrent = 0;
        private int ansNumber = 0;
        private string selectedAns;
        private bool allowNext = false;
        private bool isGoBack = false;
        //List Manager
        private List<TestModel> tests = new List<TestModel>();//list ques
        private List<AnsModel> mapAnswers = new List<AnsModel>();//listAns
        //List Manager Control
        private List<Guna2PictureBox> arrPictureBoxTick= new List<Guna2PictureBox>();
        private List<System.Windows.Forms.Label> arrLabel= new List<System.Windows.Forms.Label>();
        private List<Guna2GradientPanel> arrGradientPanel= new List<Guna2GradientPanel>();
        private List<Guna2CustomRadioButton> arrRadioButton = new List<Guna2CustomRadioButton>();


        public List<TestModel> Tests
        {
            set { tests = value; }
        }
        public Exam()
        {
            InitializeComponent();
        }



        public bool WarningExitTest()
        {
            messageBoxCus.InitModeWarning();
            messageBoxCus.Content = "Are you sure you want to exit now?";
            messageBoxCus.ShowDialog();

            return messageBoxCus.OK ? true : false;
        }
        public bool ValidateEmpty(string textBoxEmpty, string message)
        {
            if (textBoxEmpty == "")
            {
                messageBoxCus.Content = "Please enter a " + message;
                messageBoxCus.ShowDialog();
                return true;
            }
            return false;
        }
        public void InitDataTests()
        {
            try
            {

            btQuestion.Text = btQuestion.Text.Substring(0, 9) + tests[indexPageCurrent].Id;
            }catch(Exception ex)
            {
                return;
            }
            content.Text = tests[indexPageCurrent].Content;
            ans1.Text = tests[indexPageCurrent].AnsOne;
            ans2.Text = tests[indexPageCurrent].AnsTwo;
            ans3.Text = tests[indexPageCurrent].AnsThree;
            ans4.Text = tests[indexPageCurrent].AnsFour;
        }
        public bool CheckChecked()
        {
             //xử lý các controls
            foreach (Control control in panel.Controls)
            {
                if (control is Guna2CustomRadioButton radioButton && radioButton.Checked  )
                {
                    return true;
                }
            }
            return false;
        }
        public void AddAns()
        {
            //xử lý các controls
            foreach (Control control in panel.Controls)
            {
                if (control is Guna2CustomRadioButton radioButton && radioButton.Checked )
                {
                    mapAnswerItem = new AnsModel(ansNumber, selectedAns, tests[indexPageCurrent].AnsCorrect, radioButton.Name);
                    mapAnswers.Add(mapAnswerItem);
                }
            }
        }
        public void ResetControl(bool next = false)
        {
            //xử lý các controls
            foreach (Control control in panel.Controls)
            {
                //ẩn tất cả tick, trừ clock
                if (control is Guna2PictureBox pictureBox)
                {
                    if (pictureBox.Name != "ptCountdown")
                        pictureBox.Visible = false;
                }

                if (control is Guna2CustomRadioButton radioButton)
                {
                    if (next)
                    {
                        radioButton.Checked = false;
                        radioButton.Visible = true;
                    }
                    radioButton.Visible = radioButton.Checked ? false : true;
                }

                if (control is Guna2GradientPanel childPanel)//childPanel là biến đại diện cho một control của kiểu Panel trong danh sách các controls con của parentPanel.
                {
                    //bỏ qua border question
                    if (childPanel.Name != "pnQues")
                        //đưa về màu border mặc định
                        childPanel.BorderColor = ColorTranslator.FromHtml("#3A98B9");
                }

                if (control is System.Windows.Forms.Label label)
                {
                    label.ForeColor = ColorTranslator.FromHtml("#0E8388");
                }
            }
        }

        public void RestoreChecked()
        {
            int useCheckedCurrent;
            
            ResetControl();
            useCheckedCurrent= mapAnswers[indexPageCurrent].Id;

            arrLabel[useCheckedCurrent].ForeColor = ColorTranslator.FromHtml("#62CDFF");
            arrPictureBoxTick[useCheckedCurrent].Visible = true;
            arrRadioButton[useCheckedCurrent].Visible = false;
            arrRadioButton[useCheckedCurrent].Checked = true;
            arrGradientPanel[useCheckedCurrent].BorderColor = ColorTranslator.FromHtml("#62CDFF");

            //MessageBox.Show("Restore");
        }






        ///                            EVENT                //


        private void Exam_Load(object sender, EventArgs e)
        {
            btPrevious.Visible = false;

            //getControls into List
            foreach (Control control in panel.Controls)
            {
                if (control is Guna2PictureBox pictureBox)
                {
                    if (pictureBox.Name != "ptCountdown")
                        arrPictureBoxTick.Add(pictureBox);
                }

                if (control is Guna2CustomRadioButton radioButton)
                    arrRadioButton.Add(radioButton);

                if (control is Guna2GradientPanel panel)//childPanel là biến đại diện cho một control của kiểu Panel trong danh sách các controls con của parentPanel.
                {
                    if (panel.Name != "pnQues")
                        arrGradientPanel.Add(panel);
                }

                if (control is System.Windows.Forms.Label label)
                {
                    if(label.Name!= "lbCountdown")
                        arrLabel.Add(label);
                }
            }
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
        private void btExit_Click(object sender, EventArgs e)
        {
            if (WarningExitTest())
                Application.Exit();
        }
       
        //Chú ý CheckedChange gọi khi radioButton được checked và unchecked
        private void radioBt_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CustomRadioButton radioButton = ((Guna2CustomRadioButton)sender);
            string nameRadioBt = radioButton.Name;
            ResetControl();

            //Nếu Nó Checked thì mới xử lý, nếu không thì không checked nó cũng xử lý sự kiện styles
            if (radioButton.Checked)
            {

                switch (nameRadioBt)
                {
                    case "radioBt1":
                        {
                            tick1.Visible = true;
                            panelAns1.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                            lbA.ForeColor = ColorTranslator.FromHtml("#62CDFF");

                            ansNumber=0;
                            selectedAns = "A";
                        }
                        break;
                    case "radioBt2":
                        {
                            tick2.Visible = true;
                            panelAns2.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                            lbB.ForeColor = ColorTranslator.FromHtml("#62CDFF");

                            ansNumber = 1;
                            selectedAns = "B";
                        }
                        break;
                    case "radioBt3":
                        {
                            tick3.Visible = true;
                            panelAns3.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                            lbC.ForeColor = ColorTranslator.FromHtml("#62CDFF");

                            ansNumber = 2;
                            selectedAns = "C";
                        }
                        break;
                    case "radioBt4":
                        {
                            tick4.Visible = true;
                            panelAns4.BorderColor = ColorTranslator.FromHtml("#62CDFF");
                            lbD.ForeColor = ColorTranslator.FromHtml("#62CDFF");

                            ansNumber = 3;
                            selectedAns = "D";
                        }
                        break;
                    default:
                        break;
                }
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

                messageBoxCus.InitModeTimeOut();
                messageBoxCus.ShowDialog();
            }
        }
        private void btPrevious_Click(object sender, EventArgs e)
        {
            //trường hợp ở page mới nhất và đã checked
            if(indexPageCurrent==mapAnswers.Count && CheckChecked())
                AddAns();

            this.indexPageCurrent--;

            isGoBack = true;

                            label4.Text = (mapAnswers.Count).ToString();
                            label5.Text = indexPageCurrent.ToString();

                            string s = "";
                            foreach (AnsModel ans in mapAnswers)
                            {
                                s+= $" {indexPageCurrent} {ans.Id} {ans.UserAns} {ans.AnsCorrect} {ans.RBSelected} |";
                            }
                            lbAns.Text = s;

            //khôi phục các checked
            RestoreChecked();

            //kiểm tra chuyển trang
            //case chỉ còn 1 item
            if (indexPageCurrent == 0)
            {
                btPrevious.Visible = false;
                btNext.Visible = true;
            }
            //case có 2 giá item
            else if (indexPageCurrent == 1)
            {
                btPrevious.Visible = true;
            }
            //trường hợp nhiều indexPageCurrent nhỏ hơn số lượng Tests
            else if (indexPageCurrent <tests.Count-1)
            {
                btNext.Visible = true;
            }
            
                            lbGoBack.Text = isGoBack.ToString();

            InitDataTests();
        }
        private void btNext_Click(object sender, EventArgs e)
        {
            lbCountdown.Text = "60 S";
////////////
            this.indexPageCurrent++;

            //trường hợp đang GoBack và đến page mới nhất(page này đã checked, vì đã checked thì pageCurrent=mapAnswers.Count-1)
            if (isGoBack && indexPageCurrent != mapAnswers.Count)
                    RestoreChecked();

            //nếu isGoBack thì không thêm Checked
            if (!isGoBack)
                AddAns(); 

            if (CheckChecked() == false || !isGoBack && (mapAnswers.Count) == (indexPageCurrent+1))//trong truường hợp Previous rồi Next thì bỏ qua những RBSelected
            {
                messageBoxCus.Content = "You haven't selected any option";
                messageBoxCus.ShowDialog();

                return;
            }
            
                            label4.Text = (mapAnswers.Count).ToString();
                            label5.Text = indexPageCurrent.ToString();

                            string s = "";
                            foreach (AnsModel ans in mapAnswers)
                            {
                                s += $" {indexPageCurrent} {ans.Id} {ans.UserAns} {ans.AnsCorrect} {ans.RBSelected} |";
                            }
                            lbAns.Text = s;

            //kiểm tra chuyển trang
            //trường hợp = max amount tests
            if (indexPageCurrent == (tests.Count - 1))
            {
                btNext.Visible = false;
            }
            //trường hợp có 2 item trong tests
            else if (indexPageCurrent == 1)
            {
                btPrevious.Visible = true;
            }
                
            //nếu đang ở page mới nhất và chưa checked
            //( dành cho trường hợp isGoBack, Next đến Page mới nhất thì gán thành false)
            if(isGoBack && indexPageCurrent == mapAnswers.Count)
                isGoBack = false;

                            lbGoBack.Text = isGoBack.ToString();

            //nếu isGoBack thì chạy hàm ResetChecked ở trên
            //và bỏ qua hàm làm mới Control(ResetControl)
            if (!isGoBack)
                ResetControl(true);
            
            InitDataTests();
        }





























 //////CLASS 
    }
}

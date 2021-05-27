using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SNSForm : Form
    {
        Student std = new Student("null");
        Note note;
        bool is_like = false;
        int num = 0; // 좋아요 숫자를 저장할 변수. 총 수는 서버에서 받아와야함. 일단은 하드코딩
        public SNSForm(Student st)
        {
            InitializeComponent();
            std = st;

            lblID.Text = st.Id + " " + st.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리", "SNS" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 4;
            txtBox.Text = num.ToString();

            /*
             쓰여진 글들을 모두 서버로부터 받아옴. 
             Note라는 클래스로 정의되어있으며, 제목, 글, 좋아요 수, 댓글목록으로 구성되어있음. 일단은 그림이 없다고 가정.
             쓰여진 글들을 서버로부터 받아오면 cmbPost라는 콤보박스에 추가하여 각 글마다 볼 수 있도록 함.
             */
            // 그림을 전송하는 것이 구현이 힘들다면 해당 부분은 삭제해도됨
            if (picBox.Image == null)//서버로부터 받아온 글이 그림이 없다면
            {
                txtBox.Location = new Point(40, 20);
                txtBox.Size = new Size(360, 270);
                txtCom.Location = new Point(40, 324);
            }
            else
            {
                //그림이 있다면
            }
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedIndex == 1)
            {
                //강의자료실 폼으로 이동
                ArticleViewMain articleViewMain = new ArticleViewMain(std);
                this.Hide();
                articleViewMain.Show();
            }
            else if (cmbMenu.SelectedIndex == 2)
            {
                //온라인강의보기 폼을 이동
                LectureViewForm lectureView = new LectureViewForm(std);
                this.Hide();
                lectureView.Show();
            }
            else if (cmbMenu.SelectedIndex == 3)
            {
                GradeForm grade = new GradeForm(std);
                this.Hide();
                grade.Show();
            }
            else if (cmbMenu.SelectedIndex == 0)
            {
                TimeTableForm time = new TimeTableForm(std);
                this.Hide();
                time.Show();
            }
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void addPost(string myPost)
        {
            txtBox.Text = myPost;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            num = Int32.Parse(lblLike.Text);
            if (!is_like) // 좋아요를 누르면
            {
                lblLike.Text = (num + 1).ToString();
                button1.ForeColor = System.Drawing.Color.DarkRed;
                is_like = true;
            }
            else
            {
                lblLike.Text = (num - 1).ToString();
                button1.ForeColor = System.Drawing.Color.White;
                is_like = false;
            }
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            WritingPostForm write = new WritingPostForm(this);
            write.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            this.Close();
            login.Show();
        }

        public void addComment(string com)
        {
            txtCom.Text = txtCom.Text + std.Id + " : " + com + Environment.NewLine;
        }
        private void btnCom_Click(object sender, EventArgs e)
        {
            WritingComForm com = new WritingComForm(this);
            com.Show();
        }
    }
}

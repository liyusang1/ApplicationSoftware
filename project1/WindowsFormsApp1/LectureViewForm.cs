using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    public partial class LectureViewForm : Form
    {
        Student std;
        public LectureViewForm(Student st)
        {
            InitializeComponent();

            std = new Student(st.Id, st.Pw, st.Name, st.Number, st.Tokens, st.Department, st.Friends, st.Subjects, st.Scores);
            txtUser.Text = st.Id + " " + st.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 2;

            lvwLecture.View = View.Details;

            lvwLecture.Columns.Add("주차", "주차");
            lvwLecture.Columns.Add("학습단원", "학습단원");
            lvwLecture.Columns.Add("구분", "구분");
            lvwLecture.Columns.Add("학습목차", "학습목차");
            lvwLecture.Columns.Add("인정시간", "인정시간");
            lvwLecture.Columns.Add("학습하기", "학습하기");
            lvwLecture.Columns.Add("달성시간", "달성시간");

            lvwLecture.Columns[0].Width = 100;
            lvwLecture.Columns[1].Width = 210;
            lvwLecture.Columns[2].Width = 100;
            lvwLecture.Columns[3].Width = 180;
            lvwLecture.Columns[4].Width = 120;
            lvwLecture.Columns[5].Width = 110;
            lvwLecture.Columns[6].Width = 110;

            string[] subject = { "알고리즘", "응용소프트웨어실습", "알고리즘", "컴퓨터구조" };
            cmbSubject.Items.AddRange(subject);
            cmbSubject.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            this.Close();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMenu.Visible)
                cmbMenu.Visible = false;
            else
                cmbMenu.Visible = true;
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedIndex == 0)
            {
                //시간표 폼으로 이동
                TimeTableForm timeTable = new TimeTableForm(std);
                this.Hide();
                timeTable.Show();
            }
            else if (cmbMenu.SelectedIndex == 1)
            {
                //강의자료실 폼을 이동
                ArticleViewMain articleView = new ArticleViewMain();
                this.Hide();
                articleView.Show();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwLecture.Items.Clear();
        
            for(int i = 0; i < 3; i++) // 해당 강의 수 만큼 반복
            {
                string[] lectureInfo = { "1", "Introduction", "강의영상", "알고리즘 강의소개", "30분", "보기", "30/30" };
                ListViewItem item = new ListViewItem(lectureInfo);
                lvwLecture.Items.Add(item);
            }

        }

        private void lvwLecture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LecturePlayer lecturePlayer = new LecturePlayer();
            lecturePlayer.Show();
        }
    }
}

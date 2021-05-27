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
    public partial class GradeForm : Form
    {
        Student std = new Student("null");
        Professor pro = new Professor("null");
        public GradeForm(Student st)
        {
            InitializeComponent();
            panel2.Hide();
            lvwLectureGrade.Hide();
            std = st;
            txtUser.Text = st.Id + " " + st.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리"};
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 3;
            
            lvwLectureGradestd.View = View.Details;

            lvwLectureGradestd.Columns.Add("학정번호", 180);
            lvwLectureGradestd.Columns.Add("과목명", 240);
            lvwLectureGradestd.Columns.Add("개설학과", 180);
            lvwLectureGradestd.Columns.Add("이수구분", 110);
            lvwLectureGradestd.Columns.Add("학점", 110);
            lvwLectureGradestd.Columns.Add("성적", 110);

            int LectureCount = 3;
            for (int i = 0; i < LectureCount; i++)
            {
                string[] LectureGradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", st.Scores[i].Item2.ToString() }; // 서버에서 받아올 정보

                if (LectureGradeInfo[5].Equals("APLUS"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "A+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if(LectureGradeInfo[5].Equals("AZERO"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "A" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("BPLUS"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "B+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("BZERO"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "B" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("CPLUS"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "C+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("CZERO"))
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "C" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else
                {
                    string[] GradeInfo = { "H030-3-0969-02", "알고리즘", "소프트웨어학부", "전선", "3", "F" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }

            }
        }

        public GradeForm(Professor prof)
        {
            InitializeComponent();
            pro = prof;
            lvwLectureGradestd.Hide();
            txtUser.Text = prof.Id + " " + prof.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리", "SNS" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 3;

            lvwLectureGrade.View = View.Details;

            lvwLectureGrade.Columns.Add("학생명", 500);
            lvwLectureGrade.Columns.Add("성적", 500);

            var client = new RestClient("https://team.liyusang1.site/schedule");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", prof.Tokens);
            IRestResponse response = client.Execute(request);


            var jObject = JObject.Parse(response.Content);
            int resultCode = (int)jObject["code"];

            if (resultCode == 200)
            {
                int scheduleCount = (int)jObject["count"]; //이 학생이 수강하고 있는 과목 수

                for (int i = 0; i < scheduleCount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    cmbSubject.Items.Add(className);
                }
            }
            cmbSubject.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            this.Close();
            login.Show();
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMenu.SelectedIndex == 0)
            {
                // 학생일 때
                if (pro.Tokens == "null")
                {
                    //시간표 폼으로 이동
                    TimeTableForm timeTable = new TimeTableForm(std);
                    this.Hide();
                    timeTable.Show();
                }
                // 교수일 때
                else
                {
                    //시간표 폼으로 이동
                    PTimeTableForm timeTable = new PTimeTableForm(pro);
                    this.Hide();
                    timeTable.Show();
                }
            }
            else if (cmbMenu.SelectedIndex == 1)
            {
                // 학생일 때
                if (pro.Tokens == "null")
                {
                    //강의자료실 폼을 이동
                    ArticleViewMain articleView = new ArticleViewMain(std);
                    this.Hide();
                    articleView.Show();
                }

                // 교수일 때
                else
                {
                    //강의자료실 폼을 이동
                    ArticleViewMain articleView = new ArticleViewMain(pro);
                    this.Hide();
                    articleView.Show();
                }
            }
            else if (cmbMenu.SelectedIndex == 2)
            {
                if (pro.Tokens == "null")
                {
                    LectureViewForm lectureView = new LectureViewForm(std);
                    this.Hide();
                    lectureView.Show();
                }

                // 교수일 때
                else
                {
                    LectureViewForm lectureView = new LectureViewForm(pro);
                    this.Hide();
                    lectureView.Show();
                }
            }
            else if (cmbMenu.SelectedIndex == 4)
            {
                SNSForm sns = new SNSForm(std);
                this.Hide();
                sns.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMenu.Visible)
                cmbMenu.Visible = false;
            else
                cmbMenu.Visible = true;
        }

        public void updateStudentGrade(string grade)
        {
            string[] UpdateGrade = { cmbSubject.SelectedItem.ToString(), grade }; // 서버에 올릴 정보

            if (grade.Equals("APLUS"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "A+";
            else if (grade.Equals("AZERO"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "A";
            else if (grade.Equals("BPLUS"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "B+";
            else if (grade.Equals("BZERO"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "B";
            else if (grade.Equals("CPLUS"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "C+";
            else if (grade.Equals("CZERO"))
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "C";
            else
                lvwLectureGrade.SelectedItems[0].SubItems[1].Text = "F";
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwLectureGrade.Items.Clear();
            int StudentCount = 3;

            string[] GetLectureGrade = { "대학물리학", "황소연", "APLUS" }; // 서버에서 받아올 정보
            string[] LectureGradeInfo = { "황소연", "APLUS" };

            if (cmbSubject.SelectedItem.ToString().Equals(GetLectureGrade[0]))
            {
                for (int i = 0; i < StudentCount; i++)
                {
                    if (LectureGradeInfo[1].Equals("APLUS"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "A+" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else if (LectureGradeInfo[1].Equals("AZERO"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "A" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else if (LectureGradeInfo[1].Equals("BPLUS"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "B+" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else if (LectureGradeInfo[1].Equals("BZERO"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "B" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else if (LectureGradeInfo[1].Equals("CPLUS"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "C+" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else if (LectureGradeInfo[1].Equals("CZERO"))
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "C" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                    else
                    {
                        string[] GradeInfo = { LectureGradeInfo[0].ToString(), "F" };
                        ListViewItem item = new ListViewItem(GradeInfo);
                        lvwLectureGrade.Items.Add(item);
                    }
                }
            }
        }

        private void lvwLectureGrade_DoubleClick(object sender, EventArgs e)
        {
            if (lvwLectureGrade.SelectedItems.Count == 1)
            {
                GradeUpdateForm gradeUpdate = new GradeUpdateForm(this);
                gradeUpdate.Show();
            }
        }

      
    }
}

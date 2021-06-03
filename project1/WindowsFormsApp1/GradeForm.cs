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
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리", "SNS" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 3;
            
            lvwLectureGradestd.View = View.Details;

            lvwLectureGradestd.Columns.Add("학정번호", 180);
            lvwLectureGradestd.Columns.Add("과목명", 240);
            lvwLectureGradestd.Columns.Add("개설학과", 180);
            lvwLectureGradestd.Columns.Add("이수구분", 110);
            lvwLectureGradestd.Columns.Add("학점", 110);
            lvwLectureGradestd.Columns.Add("성적", 110);

            var client = new RestClient("https://team.liyusang1.site/personal-grade");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", st.Tokens);
            IRestResponse response = client.Execute(request);
            var jObject = JObject.Parse(response.Content);

            int LectureCount = (int)jObject["count"];


            for (int i = 0; i < LectureCount; i++)
            {
                //학정번호  과목이름  개설학과  전선  
                string[] LectureGradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3",  jObject["result"][i]["grade"].ToString() }; // 서버에서 받아올 정보

                if (LectureGradeInfo[5].Equals("APLUS"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "A+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if(LectureGradeInfo[5].Equals("AZERO"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "A" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("BPLUS"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "B+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("BZERO"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "B" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("CPLUS"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "C+" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else if (LectureGradeInfo[5].Equals("CZERO"))
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "C" };
                    ListViewItem item = new ListViewItem(GradeInfo);
                    lvwLectureGradestd.Items.Add(item);
                }
                else
                {
                    string[] GradeInfo = { jObject["result"][i]["infoNumber"].ToString(), jObject["result"][i]["className"].ToString(),
                    jObject["result"][i]["department"].ToString(),  jObject["result"][i]["category"].ToString(), "3", "F" };
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
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리"};
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
            int Id = 0;

            for (int i = 0; i < pro.StudentScores.Count; i++)
            {
                if ((cmbSubject.SelectedItem.ToString().Equals(pro.StudentScores[i].ClassName))
                    && (pro.StudentScores[i].StudentName.Equals(lvwLectureGrade.SelectedItems[0].SubItems[0].Text)))
                {
                    Id = pro.StudentScores[i].ScoreID;
                }
            }

            string[] UpdateGrade = { Id.ToString(), grade }; // 서버에 올릴 정보
            //서버에 넘겨야할때필요한 정보는 265번째줄에서 준 인덱스번호와 변경할 성적 정보 두개 입니다.

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

            var client = new RestClient("https://team.liyusang1.site/personal-grade/"+Id);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            //서버로 값을 보냄
            request.AddJsonBody(
                       new
                       {
                           grade = grade
                       });
            IRestResponse response = client.Execute(request);;
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwLectureGrade.Items.Clear();

            var client = new RestClient("https://team.liyusang1.site/grade");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);


            var jObject = JObject.Parse(response.Content);
            int StudentCount = (int)jObject["count"];


            for (int i=0; i<StudentCount;i++)
            {
                int index =(int)jObject["result"][i]["idx"];  // 해당 인덱스를 저장하고 있다가 성적을 입력할때 필요로 합니다.

                StudentScore studScore = new StudentScore(index, jObject["result"][i]["className"].ToString(), jObject["result"][i]["name"].ToString(), jObject["result"][i]["grade"].ToString());
                pro.StudentScores.Add(studScore);
                //과목이름 //이름 // 성적
                string[] GetLectureGrade = { jObject["result"][i]["className"].ToString(), jObject["result"][i]["name"].ToString(), jObject["result"][i]["grade"].ToString() }; // 서버에서 받아올 정보
                string[] LectureGradeInfo = { jObject["result"][i]["name"].ToString(), jObject["result"][i]["grade"].ToString() };

                if (cmbSubject.SelectedItem.ToString().Equals(GetLectureGrade[0]))
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

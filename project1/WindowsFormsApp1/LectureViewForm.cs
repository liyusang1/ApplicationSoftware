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
using Newtonsoft.Json;  //Newtonsoft 라이브러리 사용예정


//testId 
//id : 2021
//password :test123

//test 교수 아이디
//id : 0000 password:test123 (김물리)

//test 교수 아이디
//id : 0001 password:test123 (김코딩)

namespace WindowsFormsApp1
{
    public partial class LectureViewForm : Form
    {
        Student std = new Student("null");
        Professor pro = new Professor("null");
        public LectureViewForm(Student st)
        {
            InitializeComponent();
            btnUpload.Hide();
            btnDel.Hide();
            std = st;
            txtUser.Text = st.Id + " " + st.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 2;

            lvwLecture.View = View.Details;

            lvwLecture.Columns.Add("주차");
            lvwLecture.Columns.Add("학습단원");
            lvwLecture.Columns.Add("구분");
            lvwLecture.Columns.Add("학습목차");
            lvwLecture.Columns.Add("인정시간");
            lvwLecture.Columns.Add("학습하기");
            //lvwLecture.Columns.Add("달성시간");

            lvwLecture.Columns[0].Width = 100;
            lvwLecture.Columns[1].Width = 210;
            lvwLecture.Columns[2].Width = 100;
            lvwLecture.Columns[3].Width = 180;
            lvwLecture.Columns[4].Width = 120;
            lvwLecture.Columns[5].Width = 110;
            //lvwLecture.Columns[6].Width = 110;

            var client = new RestClient("https://team.liyusang1.site/schedule");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", st.Tokens);
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

        public LectureViewForm(Professor prof)
        {
            InitializeComponent();

            pro = prof;
            txtUser.Text = prof.Id + " " + prof.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기", "성적관리" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 2;

            lvwLecture.View = View.Details;

            lvwLecture.Columns.Add("주차");
            lvwLecture.Columns.Add("학습단원");
            lvwLecture.Columns.Add("구분");
            lvwLecture.Columns.Add("학습목차");
            lvwLecture.Columns.Add("인정시간");
            lvwLecture.Columns.Add("URL");
            //lvwLecture.Columns.Add("달성시간");

            lvwLecture.Columns[0].Width = 100;
            lvwLecture.Columns[1].Width = 210;
            lvwLecture.Columns[2].Width = 100;
            lvwLecture.Columns[3].Width = 180;
            lvwLecture.Columns[4].Width = 120;
            lvwLecture.Columns[5].Width = 110;
            //lvwLecture.Columns[6].Width = 110;

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
            else if (cmbMenu.SelectedIndex == 3)
            {
                if (pro.Tokens == "null")
                {
                    GradeForm grade = new GradeForm(std);
                    this.Hide();
                    grade.Show();
                }

                // 교수일 때
                else
                {
                    GradeForm grade = new GradeForm(std);
                    this.Hide();
                    grade.Show();
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadForm upload = new UploadForm(this);
            upload.Show();
        }

        public void addLecture(string week, string chap, string dist, string cont, string time, string url)
        {
            string[] row = { week, chap, dist, cont, time, url };

            int classId=0;
            if (cmbSubject.SelectedItem.Equals("대학물리학"))
                classId = 1;
            else if (cmbSubject.SelectedItem.Equals("알고리즘"))
                classId = 2;
            else if (cmbSubject.SelectedItem.Equals("자료구조"))
                classId = 3;
            else if (cmbSubject.SelectedItem.Equals("객체지향프로그래밍"))
                classId = 4;
            else if (cmbSubject.SelectedItem.Equals("고급물리이론"))
                classId = 5;
            else if (cmbSubject.SelectedItem.Equals("운영체재"))
                classId = 6;

            var client = new RestClient("https://team.liyusang1.site/class-room");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-access-token", pro.Tokens);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(
                       new
                       {
                           classId=classId,
                           classWeek=week,
                           classChapter=chap,
                           classDistinct=dist,
                           classTime=time,
                           classContext=cont,
                           classUrl=url
                       });

            IRestResponse response = client.Execute(request);
  

            var listrow = new ListViewItem(row);
            lvwLecture.Items.Add(listrow); //추가한 강의에 대한 정보를 서버로 옮겨야함. 옮긴 후에는 계속해서 학생과 교수 모두 정보를 볼 수 있도록 함.
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //서버에서 삭제를 하기 위해서는 293번째 줄의 classRoomId가 필요로함
            int classRoomId = lvwLecture.SelectedItems[0].Index;
            int count = lvwLecture.SelectedItems.Count;
            for(int i = count - 1; i >= 0; i--)
            {
                lvwLecture.Items.Remove(lvwLecture.SelectedItems[i]);
            }
        }

        private void lvwLecture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lvwLecture.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lvwLecture.SelectedItems;
                ListViewItem lvItem = items[0];
                string url = lvItem.SubItems[5].Text;
                System.Diagnostics.Process.Start(url);
            }
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            // 학생일 때
            if (pro.Tokens == "null")
            {

                lvwLecture.Items.Clear();

                var client = new RestClient("https://team.liyusang1.site/class-room");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-access-token",std.Tokens);
                IRestResponse response = client.Execute(request);
                var jObject = JObject.Parse(response.Content);

                int lecturecount = (int)jObject["count"]; // 총 듣고 있는 과목의 강의 수 ex) 알고리즘 강의3개 대학물리학강의가 2개면 lectureCount = 5

                for (int i = 0; i < lecturecount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    string week = jObject["result"][i]["classWeek"].ToString();
                    string chapter = jObject["result"][i]["classChapter"].ToString();
                    string classDistinct = jObject["result"][i]["classDistinct"].ToString(); //구분
                    string classContext = jObject["result"][i]["classContext"].ToString(); //목차
                    string classTime = jObject["result"][i]["classTime"].ToString();
                    string classUrl = jObject["result"][i]["classUrl"].ToString();

                    int classRoomId = (int)jObject["result"][i]["classRoomId"]; //나중에강의 삭제 수정등에 필요합니다.
                    //삭제를 할때 그 강의의id를 서버로 보내야지 서버에서 그것에 해당하는 강의를 삭제할 수 있음

                    string[] GetLecture = { className, week, chapter, classDistinct, classContext, classTime, classUrl}; // 서버에서 받아올 정보
                    string[] lectureInfo = { week, chapter, classDistinct, classContext, classTime, classUrl};

                    if (cmbSubject.SelectedItem.ToString().Equals(GetLecture[0]))
                    { 
                            ListViewItem item = new ListViewItem(lectureInfo);
                            lvwLecture.Items.Add(item);
                    }
                }
            }
            // 교수일 때
            else
            {
                lvwLecture.Items.Clear();

                var client = new RestClient("https://team.liyusang1.site/class-room");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-access-token", pro.Tokens);
                IRestResponse response = client.Execute(request);
                var jObject = JObject.Parse(response.Content);

                int lecturecount = (int)jObject["count"]; // 강의 수

                for (int i = 0; i < lecturecount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    string week = jObject["result"][i]["classWeek"].ToString();
                    string chapter = jObject["result"][i]["classChapter"].ToString();
                    string classDistinct = jObject["result"][i]["classDistinct"].ToString(); //구분
                    string classContext = jObject["result"][i]["classContext"].ToString(); //목차
                    string classTime = jObject["result"][i]["classTime"].ToString();
                    string classUrl = jObject["result"][i]["classUrl"].ToString();

                    int classRoomId = (int)jObject["result"][i]["classRoomId"]; //나중에강의 삭제 수정등에 필요합니다.
                    //삭제를 할때 그 강의의id를 서버로 보내야지 서버에서 그것에 해당하는 강의를 삭제할 수 있음

                    string[] GetLecture = { className, week, chapter, classDistinct, classContext, classTime, classUrl }; // 서버에서 받아올 정보
                    string[] lectureInfo = { week, chapter, classDistinct, classContext, classTime, classUrl };

                    if (cmbSubject.SelectedItem.ToString().Equals(GetLecture[0]))
                    {
                        ListViewItem item = new ListViewItem(lectureInfo);
                        lvwLecture.Items.Add(item);
                    }
                }
            }


        }
    }
}

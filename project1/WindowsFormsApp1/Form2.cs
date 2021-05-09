using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp; //RestSharp 라이브러리를 사용 예정
using Newtonsoft.Json;  //Newtonsoft 라이브러리 사용예정
using Newtonsoft.Json.Linq;

//testId 
//id : 2021
//password :test123

namespace WindowsFormsApp1
{
    public partial class TimeTableForm : Form
    {
        loginForm login = new loginForm();
        Student std;
        public TimeTableForm(Student st)
        {
            InitializeComponent();
            
            txtUser.Text = st.Id + " " + st.Name;

            department.Text =  st.Department; //학과표시
            
            std = new Student(st.Id, st.Pw, st.Name, st.Number, st.Tokens, st.Department, st.Friends, st.Subjects, st.Scores);


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

                for(int i=0; i<scheduleCount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    int time1 = (int)jObject["result"][i]["time1"];
                    int day1 = (int)jObject["result"][i]["day1"];
                    int time2 = (int)jObject["result"][i]["time2"];
                    int day2 = (int)jObject["result"][i]["day2"];
                    string classRoom= jObject["result"][i]["classRoom"].ToString();
                    string professorName = jObject["result"][i]["professorName"].ToString();

                    //체크용
                    Console.WriteLine(className);
                    Console.WriteLine(time1);
                    Console.WriteLine(day1);
                    Console.WriteLine(time2);
                    Console.WriteLine(day2);
                    Console.WriteLine(classRoom);
                    Console.WriteLine(professorName);
                }

                DataTable time = new DataTable();
                //열 추가
                time.Columns.Add(" ", typeof(string));
                time.Columns.Add("월", typeof(string));
                time.Columns.Add("화", typeof(string));
                time.Columns.Add("수", typeof(string));
                time.Columns.Add("목", typeof(string));
                time.Columns.Add("금", typeof(string));

                //행 추가 임의로
                time.Rows.Add("0", "데이터베이스", "", "", "", "");
                time.Rows.Add("1", "", "자료구조", "", "", "");
                time.Rows.Add("2", "", "", "알고리즘", "", "");
                time.Rows.Add("3", "", "", "", "운영체제", "");
                time.Rows.Add("4", "", "", "", "", "컴퓨터구조");
                time.Rows.Add("5", "선형대수학", "", "", "", "");
                time.Rows.Add("6", "", "", "공학수학", "", "");
                time.Rows.Add("99", "", "", "", "", "");

                dgvTime.DataSource = time;

                string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
                cmbMenu.Items.AddRange(menu);
                cmbMenu.SelectedIndex = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private Point mousePoint;

        private void TimeTableForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void TimeTableForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMenu.Visible)
                cmbMenu.Visible = false;
            else
                cmbMenu.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbMenu.SelectedIndex == 1)            {
                //강의자료실 폼으로 이동
            }
            else if(cmbMenu.SelectedIndex == 2){
                //온라인강의보기 폼을 이동
                LectureViewForm lectureView = new LectureViewForm(std);
                this.Hide();
                lectureView.Show();
            }
        }
    }
}

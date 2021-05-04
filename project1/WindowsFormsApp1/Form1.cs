/*
 변수명은 소문자
 property는 변수명을 대문자로 시작
 상수명은 전부 대문자
 클래스명은 대문자로 시작/낙타문자
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using RestSharp; //RestSharp 라이브러리를 사용 예정
using Newtonsoft.Json;  //Newtonsoft 라이브러리 사용예정
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    public partial class loginForm : Form
    {
        enum Day // 요일
        {
            MON,TUE,WED,THU,FRI
        }

        enum Score // 성적의 종류
        {
            APLUS,AZERO,BPLUS,BZERO,CPLUS,CZERO,F
        }

        class User
        {
            private string id; // 아이디
            private string pw; // 비밀번호
            private string name; // 이름
            private int number; // 번호
            private string tokens; // 유상씨가 추가하래서 한 것
            private string department; // 학과명
            
            public string Id
            {
                get { return id; }
                set { id = value; }
            }

            public string Pw
            {
                get { return pw; }
                set { pw = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Number
            {
                get { return number; }
                set { number = value; }
            }

            public string Tokens
            {
                get { return tokens; }
                set { tokens = value; }
            }

            public string Department
            {
                get { return department; }
                set { department = value; }
            }
        }

        class Student : User
        {
            private List<Student> friends; // 친구목록
            private List<Subject> subjects; // 듣고 있는 과목 목록
            private List<(Subject, Score)> scores; // 나의 성적들 (과목명,점수) - 이때 점수는 enum Score 중 하나

            public Student(string id, string pw, string name, int number, string tokens, string department,
                List<Student> friends, List<Subject> subjects, List<(Subject, Score)> scores)
            {
                Id = id;
                Pw = pw;
                Name = name;
                Number = number;
                Tokens = tokens;
                Department = department;
                Friends = friends;
                this.subjects = subjects;
                this.scores = scores;
            }

            public List<Student> Friends
            {
                get { return friends; }
                set { friends = value; }
            }

            public List<Subject> Subjects
            {
                get { return subjects; }
                set { subjects = value; }
            }

            public List<(Subject, Score)> Scores
            {
                get { return scores; }
                set { scores = value; }
            }

        }

        class Professor : User {
            private List<Subject> subjects; // 가르치는 과목 목록
            // 과목별 학생목록은 subject에 students에 있음

            public Professor(string id, string pw, string name, int number, string tokens, string department,
                 List<Subject> subjects)
            {
                Id = id;
                Pw = pw;
                Name = name;
                Number = number;
                Tokens = tokens;
                Department = department;
                this.subjects = subjects;
            }

            public List<Subject> Subjects
            {
                get { return subjects; }
                set { subjects = value; }
            }
        }

        class Subject {
            //이 과목이 열린 학기도 필요한지 모르겠음 - 성적 입력할 때 필요할 수도
            private string name; // 과목이름
            private int number; // 과목번호
            private short credits; // 학점
            private List<(Day, short)> times; // (요일,교시) ex) 화1목2 면 (화,1) , (목,2) 
            private string professor_name; // 교수 이름
            private string classroom; // 교실 이름
            private List<Student> students; // 수강하는 학생 목록
            private string department; // 개설된 학과 이름

            public Subject(string name,int number,short credits,List<(Day,short)> times,string professor_name,
                string classroom, List<Student> students,string department)
            {
                this.name = name;
                this.number = number;
                this.credits = credits;
                this.times = times;
                this.professor_name = professor_name;
                this.classroom = classroom;
                this.students = students;
                this.department = department;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Number
            {
                get { return number; }
                set { number = value; }
            }

            public short Credits
            {
                get { return credits; }
                set { credits = value; }
            }

            public List<(Day, short)> Times
            {
                get { return times; }
                set { times = value; }
            }

            public string Professor_name
            {
                get { return professor_name; }
                set { professor_name = value; }
            }

            public string Classroom
            {
                get { return classroom; }
                set { classroom = value; }
            }

            public List<Student> Students
            {
                get { return students; }
                set { students = value; }
            }

            public string Department
            {
                get { return department; }
                set { department = value; }
            }
        }

        public loginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Point mousePoint; // 폼을 움직이기 위해 마우스 좌표를 저장할 변수

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string password = txtPassword.Text;

            var client = new RestClient("https://team.liyusang1.site/sign-in");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //서버로 값을 보낼때 이런식으로 보내게 됩니다. 
            request.AddJsonBody(
                       new
                       {
                           id = id,
                           password = password,
                       });

            IRestResponse response = client.Execute(request);

            //받아온 데이터를 json형태로 묶음
            var jObject = JObject.Parse(response.Content);

            //code 를 resultCode에 저장
            int resultCode = (int)jObject["code"];

            //로그인 성공시
            if (resultCode == 200)
            {
                string jwtToken = jObject["jwt"].ToString();
              
                //jwtToken을 저장해야함

                this.Hide(); // 로그인 창 숨김

                TimeTableForm TimeTable = new TimeTableForm(); // 로그인 시 첫 화면은 시간표 폼을 열음
                TimeTable.Show();
            }
            
            //로그인 실패시 에러메시지 출력되도록
            else
            {

            }

            /*
              if()문으로 유저의 아이디와 비밀번호를 비교함. 추가 예정
            */

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide(); // 로그인 창 숨김

            SignUpForm signup = new SignUpForm(); // 회원가입 폼 열음
            signup.Show();
        }
    }
}
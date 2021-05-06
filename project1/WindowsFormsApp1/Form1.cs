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
        public loginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelError.Hide();
            txtPassword.PasswordChar = '*';
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

                //학생이라 가정
                List<Student> usr_friend = new List<Student>(new Student[10]);
                List<Subject> usr_subject = new List<Subject>(new Subject[7]);
                List<(Subject, Score)> usr_score = new List<(Subject, Score)>(new (Subject, Score)[7]);
                
                Student stu = new Student(id, password, "", Convert.ToInt32(id), jwtToken, "", usr_friend, usr_subject, usr_score);//임의로 지정
                
                TimeTableForm TimeTable = new TimeTableForm(stu); // 로그인 시 첫 화면은 시간표 폼을 열음
                TimeTable.Show();
            }
            
            //로그인 실패시 에러메시지 출력되도록
            else
            {
                panelError.Show();
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

        private void btnError_Click(object sender, EventArgs e)
        {
            panelError.Hide();
        }
    }
}
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

//test 교수 아이디
//id : 0000 password:test123 (김물리)

//test 교수 아이디
//id : 0001 password:test123 (김코딩)


namespace WindowsFormsApp1
{
    public partial class PTimeTableForm : Form
    {
        loginForm login = new loginForm();
        Professor pro;
        private Point mousePoint;
        public PTimeTableForm(Professor pr)
        {
            InitializeComponent();

            txtUser.Text = pr.Id + " " + pr.Name;
            department.Text = pr.Department;

            pro = new Professor(pr.Id, pr.Pw, pr.Name, pr.Tokens, pr.Department,pr.Subjects);

            var client = new RestClient("https://team.liyusang1.site/schedule");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", pr.Tokens);
            IRestResponse response = client.Execute(request);


            var jObject = JObject.Parse(response.Content);
            int resultCode = (int)jObject["code"];

            if (resultCode == 200)
            {
                int scheduleCount = (int)jObject["count"]; //이 학생이 수강하고 있는 과목 수

                for (int i = 0; i < scheduleCount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    int time1 = (int)jObject["result"][i]["time1"];
                    int day1 = (int)jObject["result"][i]["day1"];
                    int time2 = (int)jObject["result"][i]["time2"];
                    int day2 = (int)jObject["result"][i]["day2"];
                    string classRoom = jObject["result"][i]["classRoom"].ToString();
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
                time.Columns.Add(" ", typeof(int));
                time.Columns.Add("월", typeof(string));
                time.Columns.Add("화", typeof(string));
                time.Columns.Add("수", typeof(string));
                time.Columns.Add("목", typeof(string));
                time.Columns.Add("금", typeof(string));

                //행 추가
                for (int i = 0; i < 8; i++)
                {
                    string[] day = new string[5];
                    for (int j = 0; j < scheduleCount; j++)
                    {
                        string className = jObject["result"][j]["className"].ToString();
                        int time1 = (int)jObject["result"][j]["time1"];
                        int day1 = (int)jObject["result"][j]["day1"];
                        int time2 = (int)jObject["result"][j]["time2"];
                        int day2 = (int)jObject["result"][j]["day2"];

                        if (time1 == i)
                            day[day1 - 1] = className;
                        if (time2 == i)
                            day[day2 - 1] = className;

                        if (j == scheduleCount - 1)
                        {
                            DataRow week = time.NewRow();
                            for (int k = 0; k < 6; k++)
                            {
                                if (k == 0)
                                {
                                    if (i != 7)
                                        week[k] = i;
                                    else
                                        week[k] = 99;
                                }
                                else
                                {
                                    week[k] = day[k - 1];
                                }
                            }
                            time.Rows.Add(week);
                        }

                    }
                }

                dgvTime.DataSource = time; 
            }
       
        string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }

        private void PTimeTableForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void PTimeTableForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbMenu.Visible)
                cmbMenu.Visible = false;
            else
                cmbMenu.Visible = true;
        }

        private void cmbMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 교수용 강의자료실과 온라인강의실 추가 후 수정할 예정
            if (cmbMenu.SelectedIndex == 1)
            {
                //강의자료실 폼으로 이동
                ArticleViewMain articleViewMain = new ArticleViewMain(pro);
                this.Hide();
                articleViewMain.Show();
            }
            else if(cmbMenu.SelectedIndex == 2)
            {
                LectureViewForm lecture = new LectureViewForm(pro);
                this.Hide();
                lecture.Show();
            }
        }
    }
}

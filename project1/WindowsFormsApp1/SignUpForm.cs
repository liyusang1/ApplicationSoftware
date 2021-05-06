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

namespace WindowsFormsApp1
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            panelAlready.Hide();
            panelError.Hide();
        }

        loginForm login = new loginForm();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string id = txtId.Text;
            string password = txtPassword.Text;
            string passwordCheck = txtPasswordCheck.Text;
            string major = txtMajor.Text;

            var client = new RestClient("https://team.liyusang1.site/sign-up");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //서버로 값을 보낼때 이런식으로 보내게 됩니다. 
            request.AddJsonBody(
                       new
                       {
                           name = name,
                           id = id,
                           major = major,
                           password = password,
                           passwordCheck = passwordCheck
                       });

            IRestResponse response = client.Execute(request);

            //받아온 데이터를 json형태로 묶음
            var jObject = JObject.Parse(response.Content);

            //code 를 resultCode에 저장
            int resultCode = (int)jObject["code"];

            //회원가입 성공시
            if (resultCode == 200)
            {
                TimeTableForm timetable = new TimeTableForm(id, name);
                this.Close();
                timetable.Show();
            }
            //이미 같은 학번으로 가입이 되어 있는 경우
            else if (resultCode == 302)
            {
                panelAlready.Show();
            }
            //그외의 경우
            else
            {
                panelError.Show();
            }

        }

        private void btnError_Click(object sender, EventArgs e)
        {
            panelError.Hide();
        }

        private void btnAlready_Click(object sender, EventArgs e)
        {
            panelAlready.Hide();
        }
    }
}

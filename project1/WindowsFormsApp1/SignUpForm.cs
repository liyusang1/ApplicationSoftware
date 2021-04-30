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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        loginForm login = new loginForm();
        TimeTableForm timetable = new TimeTableForm();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            login.Show();
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string number = txtNum.Text;
            string id = txtID.Text;
            string password = txtPassword.Text;

            /*
             if()문 비교 후 이름과 학번이 일치한다고 가정하여 가입완료
            */

            this.Close();
            timetable.Show();
        }
    }
}

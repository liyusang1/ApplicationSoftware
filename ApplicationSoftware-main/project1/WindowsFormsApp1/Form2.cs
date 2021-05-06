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
    public partial class TimeTableForm : Form
    {
        loginForm login = new loginForm();
        public TimeTableForm(string id, string name)
        {
            InitializeComponent();
            if (name == "")
                txtUser.Text = id + " 홍길동"; // 임의로 지정
            else
                txtUser.Text = id + " " + name;
            
            DataTable time = new DataTable();

            //열 추가
            time.Columns.Add(" ", typeof(string));
            time.Columns.Add("월", typeof(string));
            time.Columns.Add("화", typeof(string));
            time.Columns.Add("수", typeof(string));
            time.Columns.Add("목", typeof(string));
            time.Columns.Add("금", typeof(string));

            //행 추가 임의로(과목)
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
            }
        }
    }
}

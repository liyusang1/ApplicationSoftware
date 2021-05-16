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
    public partial class PTimeTableForm : Form
    {
        loginForm login = new loginForm();
        Professor pro;
        private Point mousePoint;
        public PTimeTableForm(Professor pro)
        {
            InitializeComponent();

            txtUser.Text = this.pro.Id + " " + this.pro.Name;
            department.Text = this.pro.Department;

            pro = new Professor(this.pro.Id, this.pro.Pw, this.pro.Name, this.pro.Tokens, this.pro.Department, this.pro.Subjects);

            /*
              교수 정보가 없어서 일단은 비워둠.
             */

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
        }
    }
}

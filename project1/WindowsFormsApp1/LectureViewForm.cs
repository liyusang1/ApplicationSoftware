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
    public partial class LectureViewForm : Form
    {
        public LectureViewForm()
        {
            InitializeComponent();

            string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 2;

            lvwLecture.View = View.Details;

            lvwLecture.Columns.Add("주차");
            lvwLecture.Columns.Add("학습단원");
            lvwLecture.Columns.Add("구분");
            lvwLecture.Columns.Add("학습목차");
            lvwLecture.Columns.Add("인정시간");
            lvwLecture.Columns.Add("학습하기");
            lvwLecture.Columns.Add("달성시간");

            lvwLecture.Columns[0].Width = 100;
            lvwLecture.Columns[1].Width = 210;
            lvwLecture.Columns[2].Width = 100;
            lvwLecture.Columns[3].Width = 180;
            lvwLecture.Columns[4].Width = 120;
            lvwLecture.Columns[5].Width = 110;
            lvwLecture.Columns[6].Width = 110;
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
                //시간표 폼으로 이동
                TimeTableForm timeTable = new TimeTableForm();
                this.Hide();
                timeTable.Show();
            }
            else if (cmbMenu.SelectedIndex == 1)
            {
                //강의자료실 폼을 이동
            }
        }
    }
}

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
    public partial class LectureUploadForm : Form
    {
        public LectureUploadForm()
        {
            InitializeComponent();

            lvwLecture.View = View.Details;

            lvwLecture.Columns.Add("주차", "주차");
            lvwLecture.Columns.Add("학습단원", "학습단원");
            lvwLecture.Columns.Add("구분", "구분");
            lvwLecture.Columns.Add("학습목차", "학습목차");
            lvwLecture.Columns.Add("인정시간", "인정시간");
            lvwLecture.Columns.Add("학습하기", "학습하기");
            lvwLecture.Columns.Add("달성시간", "달성시간");

            lvwLecture.Columns[0].Width = 100;
            lvwLecture.Columns[1].Width = 210;
            lvwLecture.Columns[2].Width = 100;
            lvwLecture.Columns[3].Width = 180;
            lvwLecture.Columns[4].Width = 120;
            lvwLecture.Columns[5].Width = 110;
            lvwLecture.Columns[6].Width = 110;

            string[] subject = { "알고리즘", "응용소프트웨어실습", "알고리즘", "컴퓨터구조" };
            cmbSubject.Items.AddRange(subject);
            cmbSubject.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbMenu.Visible)
                cmbMenu.Visible = false;
            else
                cmbMenu.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            this.Close();
            login.Show();
        }

        private void btnAddLecture_Click(object sender, EventArgs e)
        {
            AddLectureForm addLecture = new AddLectureForm();
            addLecture.Show();
        }
    }
}

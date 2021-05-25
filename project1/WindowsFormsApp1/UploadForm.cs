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
    public partial class UploadForm : Form
    {
        LectureViewForm lecture;
        public UploadForm(LectureViewForm lec)
        {
            InitializeComponent();
            lecture = lec;
        }

        private void UploadForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lecture.addLecture(txtWeek.Text, txtChap.Text, txtDist.Text, txtCon.Text, Int32.Parse(txtTime.Text), txtURL.Text);
            //주차 학습단원 구분 학습목차 인정시간 url
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

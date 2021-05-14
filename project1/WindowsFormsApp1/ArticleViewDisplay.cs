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
    public partial class ArticleViewDisplay : Form
    {
        Article selectedArticle;
        public ArticleViewDisplay(Article article)
        {
            selectedArticle = article;

            // 현재 접속되어있는 사용자가 학생이라면 수정/삭제 버튼을 비활성화 시켜아한다.
            InitializeComponent();
            btnSave.Hide();
            cmbFont.Hide();
            cmbSize.Hide();
            btn굵게.Hide();
            btn기울임.Hide();
            btn밑줄.Hide();

            if (selectedArticle.Content == null)
                return;

            titleTB.Text += selectedArticle.Title;

            foreach (var element in selectedArticle.Content)
            {
                articleTB.Text += element;
                articleTB.Text += System.Environment.NewLine;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (MessageBox.Show("정말 글을 닫으시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        //btnSave, tool들 전부 활성화
        private void btnModify_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            cmbFont.Enabled = true;
            cmbSize.Enabled = true;
            btn굵게.Enabled = true;
            btn기울임.Enabled = true;
            btn밑줄.Enabled = true;
            
            //cmbFont,cmbSize dialog으로 목록 넣음
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("정말 글을 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 해당 글 삭제
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 해당 Article을 덮어씌움
        }
    }
}

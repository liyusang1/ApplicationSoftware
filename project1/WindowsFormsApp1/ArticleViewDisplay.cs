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
        Student std;
        public ArticleViewDisplay(Article article,Student st)
        {
            selectedArticle = article;
            std = st;
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

            articleTB.Text = selectedArticle.Content;

            Font articlefont = new Font(article.article_font_type.Item1, article.article_font_type.Item2);
            articleTB.Font = articlefont;

            if (article.article_font_type.Item3)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Bold);
            if (article.article_font_type.Item4)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Italic);
            if (article.article_font_type.Item5)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Underline);

            
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
            ArticleViewMain articleViewMain = new ArticleViewMain(std);
            articleViewMain.Show();
        }

        //btnSave, tool들 전부 활성화
        private void btnModify_Click(object sender, EventArgs e)
        {
            btnModify.Hide();
            btnSave.Show();
            cmbFont.Show();
            cmbSize.Show();
            btn굵게.Show();
            btn기울임.Show();
            btn밑줄.Show();

            articleTB.ReadOnly = false;

            //cmbFont,cmbSize 생성
            cmbFont.Items.Add("돋움");
            cmbFont.Items.Add("바탕");
            cmbFont.Items.Add("굴림");
            cmbFont.Items.Add("궁서");

            cmbSize.Items.Add(10);
            cmbSize.Items.Add(12);
            cmbSize.Items.Add(14);
            cmbSize.Items.Add(16);
            cmbSize.Items.Add(18);
            cmbSize.Items.Add(20);
            cmbSize.Items.Add(32);
            cmbSize.Items.Add(48);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("정말 글을 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 해당 글 삭제

                this.Close();
                ArticleViewMain articleViewMain = new ArticleViewMain(std);
                articleViewMain.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Hide();
            cmbFont.Hide();
            cmbSize.Hide();
            btn굵게.Hide();
            btn기울임.Hide();
            btn밑줄.Hide();
            btnModify.Show();
            articleTB.ReadOnly = true;

            selectedArticle.Content = articleTB.Text;
            selectedArticle.article_font_type = (articleTB.Font.Name.ToString(),
                (int)articleTB.Font.Size, articleTB.Font.Bold, articleTB.Font.Italic, articleTB.Font.Underline);
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedIndex != -1)
                articleTB.Font = new Font(Font.FontFamily, (int)cmbSize.SelectedItem, articleTB.Font.Style);
        }

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFont.SelectedIndex != -1)
                articleTB.Font = new Font(cmbFont.SelectedItem.ToString(), articleTB.Font.Size, articleTB.Font.Style);
        }

        private void btn굵게_Click(object sender, EventArgs e)
        {
            articleTB.Font = new Font(Font.FontFamily, articleTB.Font.Size, articleTB.Font.Style ^ FontStyle.Bold);
        }

        private void btn기울임_Click(object sender, EventArgs e)
        {
            articleTB.Font = new Font(Font.FontFamily, articleTB.Font.Size, articleTB.Font.Style ^ FontStyle.Italic);
        }

        private void btn밑줄_Click(object sender, EventArgs e)
        {
            articleTB.Font = new Font(Font.FontFamily, articleTB.Font.Size, articleTB.Font.Style ^ FontStyle.Underline);
        }
    }
}

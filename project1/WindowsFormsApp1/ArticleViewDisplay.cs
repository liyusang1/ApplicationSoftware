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
        Student std = new Student("null");
        Professor pro = new Professor("null");
        public ArticleViewDisplay(Article article, Student st)
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
            btnModify.Hide();
            btnDelete.Hide();


            if (selectedArticle.Content == null)
                return;

            titleTB.Text += selectedArticle.Title;

            articleTB.Text = selectedArticle.Content;

            Font articlefont = new Font(article.Font_type, article.Font_Size);
            articleTB.Font = articlefont;

            if (article.Is_bold)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Bold);
            if (article.Is_italic)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Italic);
            if (article.Is_underline)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Underline);
        }

        public ArticleViewDisplay(Article article, Professor pr)
        {
            selectedArticle = article;
            pro = pr;
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
            Font articlefont = new Font(article.Font_type, article.Font_Size);
            articleTB.Font = articlefont;

            if (article.Is_bold)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Bold);
            if (article.Is_italic)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Italic);
            if (article.Is_underline)
                articleTB.Font = new Font(articleTB.Font, FontStyle.Underline);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (std.Tokens == "null")
            { 
                if (btnSave.Enabled)
                {
                    if (MessageBox.Show("정말 글을 닫으시겠습니까?\n수정한 글은 저장되지않습니다", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
                ArticleViewMain articleViewMain = new ArticleViewMain(pro);
                articleViewMain.Show();
            }
            else
            {
                this.Close();
                ArticleViewMain articleViewMain = new ArticleViewMain(std);
                articleViewMain.Show();
            }
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

            titleTB.ReadOnly = false;
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
                ArticleViewMain articleViewMain = new ArticleViewMain(pro);
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
            titleTB.ReadOnly = true;
            articleTB.ReadOnly = true;

            selectedArticle.Content = articleTB.Text;
            selectedArticle.Font_Size = (int)articleTB.Font.Size;
            selectedArticle.Font_type = articleTB.Font.Name;
            selectedArticle.Is_bold = articleTB.Font.Bold;
            selectedArticle.Is_italic = articleTB.Font.Italic;
            selectedArticle.Is_underline = articleTB.Font.Underline;
            selectedArticle.Title = titleTB.Text;
            //만약 이 글이 새로운 글일 때, id를 설정해줘야한다.
            if (selectedArticle.ArticleID < 0)
            {
                //selectedArticle.ArticleID = ;
                //selectedArticle.Date = System.DateTime.Now.ToString("yyyy-MM-dd");
            }

            //이 글이 기존의 있던 글일 때, id를 따로 설정해줄 필요가 없다.
            else
            {
                selectedArticle.ArticleID = 1;
                // db에서 selectedArticle에 해당하는 ID를 통해서 Article ID 를 비교해서 그 Article를 찾아내고,
                // 그 article의 content,article_font_type,title을 바꿔줘야한다.

            }
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

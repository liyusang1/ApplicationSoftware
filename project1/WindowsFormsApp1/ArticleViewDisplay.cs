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
using System.IO;

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
            btnFileUpload.Hide();

            //조회수 증가
            var client = new RestClient("https://team.liyusang1.site/class-reference/view/" + selectedArticle.ArticleID);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            IRestResponse response = client.Execute(request);

            if (selectedArticle.FIle_Bytes != null)
                txtFileName.Text = selectedArticle.File_name;

            if (selectedArticle.Content == null)
                return;

            titleTB.Text += selectedArticle.Title;

            articleTB.Text = selectedArticle.Content;
            //이름 추가
            txtFileName.Text = selectedArticle.File_name;

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
            btnFileUpload.Hide();

            //조회수 증가
            var client = new RestClient("https://team.liyusang1.site/class-reference/view/"+selectedArticle.ArticleID);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            IRestResponse response = client.Execute(request);

            if (selectedArticle.Content == null)
                return;

            titleTB.Text += selectedArticle.Title;

            articleTB.Text = selectedArticle.Content;
            //이름 추가
            txtFileName.Text = selectedArticle.File_name;
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
            btnFileUpload.Show();

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

                var client = new RestClient("https://team.liyusang1.site/class-reference/" + selectedArticle.ArticleID);
                client.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("x-access-token", pro.Tokens);
                IRestResponse response = client.Execute(request);


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

            string className = selectedArticle.SubjectName;
            selectedArticle.Title = titleTB.Text;
            selectedArticle.Content = articleTB.Text;
            selectedArticle.Font_Size = (int)articleTB.Font.Size;
            selectedArticle.Is_bold = articleTB.Font.Bold;
            selectedArticle.Is_italic = articleTB.Font.Italic;
            selectedArticle.Is_underline = articleTB.Font.Underline;
            selectedArticle.Font_type = articleTB.Font.Name;

            int classId=0;

            if (className.Equals("대학물리학"))
                classId = 1;
            else if (className.Equals("알고리즘"))
                classId = 2;
            else if (className.Equals("자료구조"))
                classId = 3;
            else if (className.Equals("객체지향프로그래밍"))
                classId = 4;
            else if (className.Equals("고급물리이론"))
                classId = 5;
            else if (className.Equals("운영체재"))
                classId = 6;

            //만약 이 글이 새로운 글일 때, id를 설정해줘야한다.
            if (selectedArticle.ArticleID < 0)
            {
                var client = new RestClient("https://team.liyusang1.site/class-reference");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("x-access-token", pro.Tokens);
                request.AddHeader("Content-Type", "application/json");

                //서버로 값을 보냄
                request.AddJsonBody(
                           new
                           {
                               classId = classId,
                               contentName = selectedArticle.Title,
                               content = selectedArticle.Content,
                               fontSize = selectedArticle.Font_Size,
                               isBold = selectedArticle.Is_bold,
                               isItalic = selectedArticle.Is_italic,
                               isUnderline = selectedArticle.Is_underline,
                               fontType = selectedArticle.Font_type,
                               fileName = selectedArticle.File_name,
                               file = Convert.ToBase64String(selectedArticle.FIle_Bytes)
                           });

                IRestResponse response = client.Execute(request);
                Console.WriteLine(Convert.ToBase64String(selectedArticle.FIle_Bytes));
            }

            //이 글이 기존의 있던 글일 때, id를 따로 설정해줄 필요가 없다.
            else
            {
                Console.WriteLine(selectedArticle.ArticleID);
                var client = new RestClient("https://team.liyusang1.site/class-reference/"+ selectedArticle.ArticleID);
                client.Timeout = -1;
                var request = new RestRequest(Method.PATCH);
                request.AddHeader("x-access-token", pro.Tokens);
                request.AddHeader("Content-Type", "application/json");

                //서버로 값을 보냄
                request.AddJsonBody(
                           new
                           {
                               contentName = selectedArticle.Title,
                               content = selectedArticle.Content,
                               fontSize = selectedArticle.Font_Size,
                               isBold = selectedArticle.Is_bold,
                               isItalic = selectedArticle.Is_italic,
                               isUnderline = selectedArticle.Is_underline,
                               fontType = selectedArticle.Font_type,
                               fileName = selectedArticle.File_name,
                               file = Convert.ToBase64String(selectedArticle.FIle_Bytes)
                           });

                IRestResponse response = client.Execute(request);
                // db에서 selectedArticle에 해당하는 ID를 통해서 Article ID 를 비교해서 그 Article를 찾아내고,
                // 그 article의 content,article_font_type,title을 바꿔줘야한다.
                Console.WriteLine(Convert.ToBase64String(selectedArticle.FIle_Bytes));
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

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            ofd.InitialDirectory = "C:\\";
            ofd.Filter = "All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            var filePath = string.Empty;
            byte[] fileBytes=new byte[0];

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                fileBytes = GetFileByte(filePath);
                Console.WriteLine(fileBytes.ToString());
                txtFileName.Text = Path.GetFileName(filePath);
                selectedArticle.File_name = Path.GetFileName(filePath);
                selectedArticle.FIle_Bytes = fileBytes;
            }
        }

        private byte[] GetFileByte(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] fileBytes = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();

            return fileBytes;
        }

        private void txtFileName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedArticle.File_name==null)
                return;

            if (MessageBox.Show(selectedArticle.File_name + " 파일을 다운로드 하시겠습니까?","Inform",MessageBoxButtons.OKCancel)!=DialogResult.OK)
                return;

            string filePath = "";
            string fileDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            filePath = fileDir + "\\"+ selectedArticle.File_name;
            byte[] outByte = selectedArticle.FIle_Bytes;

            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(outByte, 0, outByte.GetUpperBound(0));
            fs.Close();

            MessageBox.Show(selectedArticle.File_name + " 파일이 내 문서에 다운로드하였습니다.", "Inform",MessageBoxButtons.OK);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    public partial class ArticleViewMain : Form
    {
        Student std = new Student("null");
        Professor pro = new Professor("null");
        public ArticleViewMain(Student st)
        {
            InitializeComponent();
            btnWrite.Hide();
            std = st;
            department.Text = st.Department;
            txtUser.Text = st.Id + " " + st.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 1;

            /*
            먼저 학생이 듣는 과목 중에서 Article.subject 와 일치하는 것들을 전부다 불러온다.
            그 다음 cmbLectureLIst에서 선택된 과목과 일치하는 글만을 노출시킨다.
            */
            //lstArticles 항목 불러오기
            lvwArticles.View = View.Details;

            lvwArticles.Columns.Add("번호", 100);
            lvwArticles.Columns.Add("제목", 536);
            lvwArticles.Columns.Add("작성자", 100);
            lvwArticles.Columns.Add("작성일", 100);
            lvwArticles.Columns.Add("조회수", 100);

            var client = new RestClient("https://team.liyusang1.site/schedule");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", st.Tokens);
            IRestResponse response = client.Execute(request);


            var jObject = JObject.Parse(response.Content);
            int resultCode = (int)jObject["code"];

            if (resultCode == 200)
            {
                int scheduleCount = (int)jObject["count"]; //이 학생이 수강하고 있는 과목 수

                for (int i = 0; i < scheduleCount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    cmbSubject.Items.Add(className);
                }
            }
            cmbSubject.SelectedIndex = 0;

            //글이 잘 들어왔다는 가정하에 실험하느라 임시로 넣음
            // 글을 서버에서 가져와서 visible_article에 넣어주면 됨
            string content = "안녕하세요\r\n반갑습니다.";

            Article testarticle1 = new Article(1,"대학물리학","1장","김코딩","2021-03-01",1,content,"굴림",10,true,true,true);
            List<Article> visible_articles = new List<Article>(10);
            for(int count=0;count<10;count++)
                visible_articles.Add(testarticle1);
            //여기까지 임시
            
            std.VisibleArticles = visible_articles;

            //글번호
            int article_count = 0;

            lvwArticles.Items.Clear();
            foreach (var element in std.VisibleArticles) {
                if (cmbSubject.SelectedItem.ToString() == element.SubjectName)
                {
                    article_count++;
                    String[] item = { article_count.ToString(), element.Title, element.Author, element.Date, element.Views.ToString() };
                    ListViewItem newitem = new ListViewItem(item);
                    lvwArticles.Items.Add(newitem);
                }
            }

            //역순으로 정렬하는 거 구현해야함
        }

        public ArticleViewMain(Professor pr)
        {
            InitializeComponent();
            pro = pr;
            department.Text = pr.Department;
            txtUser.Text = pr.Id + " " + pr.Name;
            string[] menu = { "시간표", "강의자료실", "온라인강의보기" };
            cmbMenu.Items.AddRange(menu);
            cmbMenu.SelectedIndex = 1;

            /*
            먼저 교수의 과목 중에서 Article.subject 와 일치하는 것들을 전부다 불러온다.
            그 다음 cmbLectureLIst에서 선택된 과목과 일치하는 글만을 노출시킨다.
            */
            //lstArticles 항목 불러오기
            lvwArticles.View = View.Details;

            lvwArticles.Columns.Add("번호", 100);
            lvwArticles.Columns.Add("제목", 536);
            lvwArticles.Columns.Add("작성자", 100);
            lvwArticles.Columns.Add("작성일", 100);
            lvwArticles.Columns.Add("조회수", 100);

            
            var client = new RestClient("https://team.liyusang1.site/schedule");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-access-token", pr.Tokens);
            IRestResponse response = client.Execute(request);


            var jObject = JObject.Parse(response.Content);
            int resultCode = (int)jObject["code"];

            if (resultCode == 200)
            {
                int scheduleCount = (int)jObject["count"]; //이 교수가 담당하고있는 과목의 수

                for (int i = 0; i < scheduleCount; i++)
                {
                    string className = jObject["result"][i]["className"].ToString();
                    cmbSubject.Items.Add(className);

                    
                }
            }

            cmbSubject.SelectedIndex = 0;
            List<Article> visibleArticles = new List<Article>();
            for (int j=0;j<2;j++)
            {
                int articleID = 1;
                string subjectname = "대학물리학";
                string title = "제목";
                string author = "김물리";
                string date = "2021-03-01";
                int views = 1;
                string content = "안녕하세요\n\r반갑습니다";
                string font_type = "굴림";
                int font_size = 12;
                bool is_bold = true;
                bool is_italic = false;
                bool is_underline = false;
                Article article = new Article(articleID,subjectname,title,author,date,views,content,font_type,font_size,is_bold,is_italic,is_underline);
                visibleArticles.Add(article);
            }
            
            /*
            //글이 잘 들어왔다는 가정하에 실험하느라 임시로 넣음
            // 글을 서버에서 가져와서 visible_article에 넣어주면 됨
            string content = "안녕하세요\r\n반갑습니다.";
            Article testarticle1 = new Article(1, "대학물리학", "1장", "김코딩", "2021-03-01", 1, content, "굴림", 10, true, true, true);
            List<Article> visible_articles = new List<Article>(10);
            for (int count = 0; count < 10; count++)
                visible_articles.Add(testarticle1);
            //여기까지 임시
            */

            std.VisibleArticles = visibleArticles;

            //글번호
            int article_count = 0;

            lvwArticles.Items.Clear();
            foreach (var element in std.VisibleArticles)
            {
                if (cmbSubject.SelectedItem.ToString() == element.SubjectName)
                {
                    article_count++;
                    String[] item = { article_count.ToString(), element.Title, element.Author, element.Date, element.Views.ToString() };
                    ListViewItem newitem = new ListViewItem(item);
                    lvwArticles.Items.Add(newitem);
                }
            }

            //역순으로 정렬하는 거 구현해야함
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
                // 학생일 때
                if (pro.Tokens == "null")
                {
                    //시간표 폼으로 이동
                    TimeTableForm timeTable = new TimeTableForm(std);
                    this.Hide();
                    timeTable.Show();
                }
                // 교수일 때
                else
                {
                    //시간표 폼으로 이동
                    PTimeTableForm timeTable = new PTimeTableForm(pro);
                    this.Hide();
                    timeTable.Show();
                }
            }
            else if (cmbMenu.SelectedIndex == 2)
            {
                // 학생일 때
                if (pro.Tokens == "null")
                {
                    //온라인강의보기 폼을 이동
                    LectureViewForm lectureView = new LectureViewForm(std);
                    this.Hide();
                    lectureView.Show();
                }

                // 교수일 때
                else
                {
                    /*
                    //온라인강의보기 폼을 이동
                    LectureViewForm lectureView = new LectureViewForm(pro);
                    this.Hide();
                    lectureView.Show();
                    */
                }
            }
        }

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (std.VisibleArticles == null)
                return;

            int article_count = 0;
            lvwArticles.Items.Clear();

            foreach (var element in std.VisibleArticles)
            {
                if (cmbSubject.SelectedItem.ToString() == element.SubjectName)
                {
                    ++article_count;
                    String[] item = { article_count.ToString(), element.Title, element.Author, element.Date, element.Views.ToString() };
                    ListViewItem newitem = new ListViewItem(item);
                    lvwArticles.Items.Add(newitem);
                }
            }
        }

        private void lvwArticles_Click(object sender, EventArgs e)
        {
            //선택한 아이템의 글 번호를 통해서 article을 알아낸다.
            int article_count = 0;
            Article selectedArticle = new Article();
            foreach (var element in std.VisibleArticles)
            {
                if (cmbSubject.SelectedItem.ToString() == element.SubjectName)
                {
                    ++article_count;
                    if (lvwArticles.FocusedItem.SubItems[0].Text.ToString() == article_count.ToString())
                    {
                        selectedArticle = element;
                    }
                }
            }
            this.Close();
            if (pro.Tokens == "null")
            {
                ArticleViewDisplay articleViewDisplay = new ArticleViewDisplay(selectedArticle, std);
                articleViewDisplay.Show();
            }
            else
            {
                ArticleViewDisplay articleViewDisplay = new ArticleViewDisplay(selectedArticle, pro);
                articleViewDisplay.Show();
            }

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Article selectedArticle = new Article();
            selectedArticle.ArticleID = -1;
            selectedArticle.Author = pro.Name;
            selectedArticle.SubjectName = cmbSubject.SelectedItem.ToString();
            ArticleViewDisplay articleViewDisplay = new ArticleViewDisplay(selectedArticle, pro);
            this.Close();
            articleViewDisplay.Show();
        }
    }
}

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
    public partial class ArticleViewMain : Form
    {
        public ArticleViewMain()
        {
            InitializeComponent();
        }

        private void ArticleViewMain_Load(object sender, EventArgs e)
        {
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

            //cmbLectureList 항목 불러오기
            /*
             현재 로그인 되어있는 학생의 subject들을 모두 추가한다.
             */
        }

        // lvwArticles에 selected Item을 클릭했을때 일어나는 이벤트
        // 해당 글을 담고 있는 Article class를 이용하여 ArticleViewDisplay Form을 실행한다.
        private void lvwArticlesSelectedItemClicked(object sender, EventArgs e)
        {

        }
    }
}

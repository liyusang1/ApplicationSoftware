using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /* 일관성 없는 액세스 가능성 오류를 피하기 위해 public으로 바꿀 수 있는 것은 바꿈*/
    public enum Day // 요일
    {
        MON, TUE, WED, THU, FRI
    }

    public enum Score // 성적의 종류
    {
        APLUS, AZERO, BPLUS, BZERO, CPLUS, CZERO, F
    }

    public class User
    {
        private string id; // 아이디
        private string pw; // 비밀번호
        private string name; // 이름
        private string tokens; // 유상씨가 추가하래서 한 것
        private string department; // 학과명

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Pw
        {
            get { return pw; }
            set { pw = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Tokens
        {
            get { return tokens; }
            set { tokens = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
    }

    public class Student : User
    {
        private List<Student> friends; // 친구목록
        private List<Subject> subjects; // 듣고 있는 과목 목록
        private List<(Subject, Score)> scores; // 나의 성적들 (과목명,점수) - 이때 점수는 enum Score 중 하나
        private List<Article> visibleArticles; // 학생이 볼 수 있는 모든 글

        public Student(string tokens)
        {
            Tokens = tokens;
        }

        public Student(string id, string pw, string name, string tokens, string department,
            List<Student> friends, List<Subject> subjects, List<(Subject, Score)> scores)
        {
            Id = id;
            Pw = pw;
            Name = name;

            Tokens = tokens;
            Department = department;
            Friends = friends;
            this.subjects = subjects;
            this.scores = scores;
        }

        public List<Student> Friends
        {
            get { return friends; }
            set { friends = value; }
        }

        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }

        public List<(Subject, Score)> Scores
        {
            get { return scores; }
            set { scores = value; }
        }
        
        public List<Article> VisibleArticles
        {
            get { return visibleArticles; }
            set { visibleArticles = value; }
        }

    }

    public class Professor : User
    {
        private List<Subject> subjects; // 가르치는 과목 목록
                                        // 과목별 학생목록은 subject에 students에 있음

        public Professor(string tokens)
        {
            Tokens = tokens;
        }

        public Professor(string id, string pw, string name, string tokens, string department,
             List<Subject> subjects)
        {
            Id = id;
            Pw = pw;
            Name = name;
            Tokens = tokens;
            Department = department;
            this.subjects = subjects;
        }

        public List<Subject> Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
    }

    public class Subject
    {
        //이 과목이 열린 학기도 필요한지 모르겠음 - 성적 입력할 때 필요할 수도
        private string name; // 과목이름
        private int number; // 과목번호
        private short credits; // 학점
        public List<(Day, short)> times; // (요일,교시) ex) 화1목2 면 (화,1) , (목,2) 
        private string professor_name; // 교수 이름
        private string classroom; // 교실 이름
        private List<Student> students; // 수강하는 학생 목록
        private string department; // 개설된 학과 이름

        public Subject(string name, int number, short credits, List<(Day, short)> times, string professor_name,
            string classroom, List<Student> students, string department)
        {
            this.name = name;
            this.number = number;
            this.credits = credits;
            this.times = times;
            this.professor_name = professor_name;
            this.classroom = classroom;
            this.students = students;
            this.department = department;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public short Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public List<(Day, short)> Times
        {
            get { return times; }
            set { times = value; }
        }

        public string Professor_name
        {
            get { return professor_name; }
            set { professor_name = value; }
        }

        public string Classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }
    }

    public class Article
    {
        private int articleID; //모든 글들을 구별할 수 있게하는 ID
        private string subjectname; //과목명
        private string title; //제목
        private string author; //작성자
        private string date; //날짜
        private int views; //조회수
        private string content; //글내용
        private string font_type; // 글꼴
        private int font_size; // 글자 크기
        private bool is_bold; // 굵기 유무
        private bool is_italic; // 기울임 유무
        private bool is_underline; // 언더바 유무
        private byte[] file_bytes; // BLOB 형식의 파일
        private string file_name; //파일이름 ex) 제안서.txt

        public Article() {}

        public Article(int articleID, string subjectname,
            string title, string author, string date, int views,
            string content, string font_type, int font_size, bool is_bold,
            bool is_italic, bool is_underline, byte[] file_bytes,string file_name)
        {
            this.articleID = articleID;
            this.subjectname = subjectname;
            this.title = title;
            this.author = author;
            this.date = date;
            this.views = views;
            this.content = content;
            this.font_type = font_type;
            this.font_size = font_size;
            this.is_bold = is_bold;
            this.is_italic = is_italic;
            this.is_underline = is_underline;
            this.file_bytes = file_bytes;
            this.file_name = file_name;
        }

        public int ArticleID
        {
            get { return articleID; }
            set { articleID = value; }
        }

        public string SubjectName
        {
            get { return subjectname; }
            set { subjectname = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Views
        {
            get { return views; }
            set { views = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string Font_type
        {
            get { return font_type; }
            set { font_type = value; }
        }

        public int Font_Size
        {
            get { return font_size; }
            set { font_size = value; }
        }

        public bool Is_bold
        {
            get { return is_bold; }
            set { is_bold = value; }
        }

        public bool Is_italic
        {
            get { return is_italic; }
            set { is_italic = value; }
        }

        public bool Is_underline
        {
            get { return is_underline; }
            set { is_underline = value; }
        }

        public byte[] FIle_Bytes
        {
            get { return file_bytes; }
            set { file_bytes = value; }
        }

        public string File_name
        {
            get { return file_name; }
            set { file_name = value; }
        }
    }

    public class Note
    {
        private string title;
        private string post;
        private int like;
        private string[] comment;

        public Note() { }

        public Note(string title, string post, int like, string[] comment)
        {
            this.title = title;
            this.post = post;
            this.like = like;
            Array.Copy(comment, this.comment, comment.Length);
        }

        public string Tittle
        {
            get { return title; }
            set { title = value; }
        }

        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        public int Like
        {
            get { return like; }
            set { like = value; }
        }

        public string[] Comment
        {
            get { return comment; }
            set { Array.Copy(value, comment, value.Length); }
        }
    }
}
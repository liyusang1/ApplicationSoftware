using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    enum Day // 요일
    {
        MON, TUE, WED, THU, FRI
    }

    enum Score // 성적의 종류
    {
        APLUS, AZERO, BPLUS, BZERO, CPLUS, CZERO, F
    }

    class User
    {
        private string id; // 아이디
        private string pw; // 비밀번호
        private string name; // 이름
        private int number; // 번호
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

        public int Number
        {
            get { return number; }
            set { number = value; }
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

    class Student : User
    {
        private List<Student> friends; // 친구목록
        private List<Subject> subjects; // 듣고 있는 과목 목록
        private List<(Subject, Score)> scores; // 나의 성적들 (과목명,점수) - 이때 점수는 enum Score 중 하나

        public Student(string id, string pw, string name, int number, string tokens, string department,
            List<Student> friends, List<Subject> subjects, List<(Subject, Score)> scores)
        {
            Id = id;
            Pw = pw;
            Name = name;
            Number = number;
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

    }

    class Professor : User
    {
        private List<Subject> subjects; // 가르치는 과목 목록
                                        // 과목별 학생목록은 subject에 students에 있음

        public Professor(string id, string pw, string name, int number, string tokens, string department,
             List<Subject> subjects)
        {
            Id = id;
            Pw = pw;
            Name = name;
            Number = number;
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

    class Subject
    {
        //이 과목이 열린 학기도 필요한지 모르겠음 - 성적 입력할 때 필요할 수도
        private string name; // 과목이름
        private int number; // 과목번호
        private short credits; // 학점
        private List<(Day, short)> times; // (요일,교시) ex) 화1목2 면 (화,1) , (목,2) 
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
}

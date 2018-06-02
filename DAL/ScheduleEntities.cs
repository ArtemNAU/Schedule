using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Group
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Day> Days { get; set; }

        public Group() { }
        public Group(int num)
        {
            this.Number = num;
            Days = new List<Day>();
        }

        public Day this[int index]
        {
            get
            {
                return Days[index];
            }
        }
    }
    public class Day
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public virtual List<Lesson> Lessons { get; set; }

        public Day()
        {
            Lessons = new List<Lesson>();
        }

        public void SetLesson(int pos, int Room, int tId, int sId)
        {
            Lessons[pos] = new Lesson(pos, Room, tId, sId);
        }

        public Lesson this[int index] { get { return Lessons[index]; } }
    }

    public class Lesson
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Lesson(int id, int r, int t, int s)
        {
            Id = id;
            Room = r;
            TeacherId = t;
            SubjectId = s;
        }

        public void Edit(int r, int t, int s)
        {
            if (r > 0) Room = r;
            if (t > 0) TeacherId = t;
            if (s > 0) SubjectId = s;
        }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher(string name)
        {
            this.Name = name;
        }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject(string name)
        {
            this.Name = name;
        }
    }
}

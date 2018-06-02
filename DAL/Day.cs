using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Day
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public virtual List<Lesson> Lessons { get; set; }

        public Day()
        {
            Lessons = new List<Lesson>();
        }

        public void SetLesson(int pos, int Room, string tName, string sName)
        {
            Teacher teacher = new Teacher(tName);
            Subject subject = new Subject(sName);
            Lessons[pos] = new Lesson(pos, Room, teacher, subject);
        }

        public Lesson this[int index] { get { return Lessons[index]; } }

        /*public int LessonsNum 
        {
            get
            {
                int num = 0;
                for(int i = 0; i < 8; i++)
                {
                    if (Lessons[i] != null) num++;
                }
                return num;
            }
        }*/
    }
}

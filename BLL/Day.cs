using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHNIWIMD
{
    public class Day
    {
        Lesson[] Lessons;

        public Day()
        {
            Lessons = new Lesson[8];
        }

        public void ChangeLesson(int pos, int Teacher, int Subject, string Room)
        {
            if(Lessons[pos] != null)
            {
                Lessons[pos].Change(Subject, Room, Teacher);
            }else
            {
                Lesson NewLesson = new Lesson(Subject, Room, Teacher);
                Lessons[pos] = NewLesson;
            }
        }

        public Lesson this[int index]
        {
            get
            {
                return Lessons[index];
            }
        }

        public int LessonsNum
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
        }
    }
}

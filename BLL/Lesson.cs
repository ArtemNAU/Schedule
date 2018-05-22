using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHNIWIMD
{
    public class Lesson
    {
        int Subject;
        string Room;
        int Teacher;

        public Lesson(int s, string r, int t)
        {
            Subject = s;
            Room = r;
            Teacher = t;
        }

        public void Change(int s, string r, int t)
        {
            Subject = s;
            Room = r;
            Teacher = t;
        }

        public void Read(out int s, out int t, out string r)
        {
            s = Subject;
            t = Teacher;
            r = Room;
        }
    }
}

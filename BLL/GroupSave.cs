using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class GroupSave
    {
        string Name;
        int[] Lessons;
        int[] Days;
        int[] Teachers;
        int[] Subjects;
        string[] Rooms;

        public GroupSave(string n, int[] l, int[] d, int[] t, int[] s, string[] r)
        {
            Name = n;
            Lessons = l;
            Days = d;
            Teachers = t;
            Subjects = s;
            Rooms = r;
        }
    }
}

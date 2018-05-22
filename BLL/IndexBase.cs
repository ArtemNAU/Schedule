using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHNIWIMD
{
    public class IndexBase
    {
        List<string> Teachers;
        List<string> Subjects;

        public IndexBase()
        {
            Teachers = new List<string>();
            Teachers.Add("none");
            Subjects = new List<string>();
            Subjects.Add("none");
        }

        public void AddT(string teacher)
        {
            Teachers.Add(teacher);
        }

        public void AddS(string subject)
        {
            Subjects.Add(subject);
        }

        public string[] ArrayT
        {
            get
            {
                return Teachers.ToArray();
            }
        }

        public string[] ArrayS
        {
            get
            {
                return Subjects.ToArray();
            }
        }
    }
}

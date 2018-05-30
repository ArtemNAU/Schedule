using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class UnitOfWork
    {
        private ScheduleContext db = new ScheduleContext();

        private GenericRepository<Group> GroupRep;
        private GenericRepository<Teacher> TeachRep;
        private GenericRepository<Subject> SubRep;

        public GenericRepository<Group> Groups
        {
            get
            {
                if (GroupRep == null)
                    GroupRep = new GenericRepository<Group>(db);
                return GroupRep;
            }
        }

        public GenericRepository<Teacher> Teachers
        {
            get
            {
                if (TeachRep == null)
                    TeachRep = new GenericRepository<Teacher>(db);
                return TeachRep;
            }
        }

        public GenericRepository<Subject> Subjects
        {
            get
            {
                if (SubRep == null)
                    SubRep = new GenericRepository<Subject>(db);
                return SubRep;
            }
        }

        public bool CheckElement(int g = -1, string n = "", bool s = false)
        {
            bool check = false;
            if (g == -1)
            {
                if (s)
                {
                    foreach (Subject sub in SubRep.GetArray())
                        if (sub.Name == n)
                            check = true;
                }
                else
                {
                    foreach (Teacher t in TeachRep.GetArray())
                        if (t.Name == n)
                            check = true;
                }
            }
            else
            {
                foreach (Group gp in GroupRep.GetArray())
                    if (gp.Number == g)
                        check = true;
            }
            return check;
        }
    }
}

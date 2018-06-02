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
                {
                    TeachRep = new GenericRepository<Teacher>(db);
                    TeachRep.Create(new Teacher("Преподаватель не найден"));
                }
                return TeachRep;
            }
        }

        public GenericRepository<Subject> Subjects
        {
            get
            {
                if (SubRep == null)
                {
                    SubRep = new GenericRepository<Subject>(db);
                    SubRep.Create(new Subject("Предмет не найден"));
                }
                return SubRep;
            }
        }

        public int CheckElement(int g = -1, string n = "", bool s = false)
        {
            int check = -1;
            if (g == -1)
            {
                if (s)
                {
                    for(int i = 0; i < SubRep.Length; i++)
                        if (SubRep.GetArray()[i].Name == n)
                            check = i;
                }
                else
                {
                    for (int i = 0; i < TeachRep.Length; i++)
                        if (TeachRep.GetArray()[i].Name == n)
                            check = i;
                }
            }
            else
            {
                for (int i = 0; i < GroupRep.Length; i++)
                    if (GroupRep.GetArray()[i].Number == g)
                        check = i;
            }
            return check;
        }
    }
}

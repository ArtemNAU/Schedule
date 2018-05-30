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

        public GenericRepository<Group> Groups
        {
            get
            {
                if (GroupRep == null)
                    GroupRep = new GenericRepository<Group>(db);
                return GroupRep;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Schedule
{
    public class UserContext : DbContext
    {
        public UserContext()
            :base("DbConnection"){ }

        public DbSet<string> Teachers { get; set; }
        public DbSet<string> Subjects { get; set; }

        public DbSet<GroupSave> Groups { get; set; }
    }
}

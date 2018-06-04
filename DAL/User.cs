using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }

        public User(string name, int type)
        {
            this.Name = name;
            this.Type = type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Group
    { 
        public int Id { get; set; }
        public int Number { get; set; }
        public Day Day { get; set; }
        public List<Day> Days { get; set; }

        public Group()
        {
            Days = new List<Day>();
        }

        public Group(int n)
        {
            Number = n;
            Days = new List<Day>();
        }

        //public Day this[int index] { get { return Days[index]; } }
    }
}

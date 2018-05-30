using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Group
    {
        public int Number { get; }
        private Day[] Days;

        public Group(int num)
        {
            this.Number = num;
            Days = new Day[10];
        }

        public Day this[int index]
        {
            get
            {
                    return Days[index];
            }
        }
    }
}

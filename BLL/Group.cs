using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Group
    {

        string Name;
        Day[] Days;

        public Group(string n)
        {
            Name = n;
            Days = new Day[10];
            for(int i = 0; i < 10; i++)
            {
                Days[i] = new Day();
            }
        }

        public Day this[int index]
        {
            get
            {
                return Days[index];
            }
        }

        public void Save()
        {
            int size = 0;

            for(int i = 0; i < 10; i++)
            {
                size += Days[i].LessonsNum;
            }

            int[] lessons = new int[size];
            int[] days = new int[size];
            int[] teachers = new int[size];
            int[] subjects = new int[size];
            string[] rooms = new string[size];

            size = 0;

            for(int d = 0; d < 10; d++)
            {
                for(int l = 0; l < 8; l++)
                {
                    if(Days[d][l] != null)
                    {
                        lessons[size] = l;
                        days[size] = d;
                        Days[d][l].Read(out subjects[size], out teachers[size], out rooms[size]);
                        size++;
                    }
                }
            }
            SaveAndLoad.SaveThisGroup(Name, lessons, days, teachers, subjects, rooms);
        }
    }
}

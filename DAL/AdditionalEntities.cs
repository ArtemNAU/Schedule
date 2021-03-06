﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public class Lesson
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Lesson(int id, int r, int t, int s)
        {
            Id = id;
            Room = r;
            TeacherId = t;
            SubjectId = s;
        }

        public void Edit(int r, int t, int s)
        {
            if (r > 0) Room = r;
            if (t > 0) TeacherId = t;
            if (s > 0) SubjectId = s;
        }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher(string name)
        {
            this.Name = name;
        }
    }

    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject(string name)
        {
            this.Name = name;
        }
    }

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

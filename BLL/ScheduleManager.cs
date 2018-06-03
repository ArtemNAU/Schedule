using AutoMapper;
using System;
using System.Collections.Generic;

namespace Schedule
{
    public class ScheduleManager
    {
        UnitOfWork unitOfWork;

        public ScheduleManager()
        {
            unitOfWork = new UnitOfWork();
        }

        public void AddGroup(int num)
        {
            Group newGroup = new Group(num);
            unitOfWork.Groups.Create(newGroup);
        }
        
        public void EditLesson(int g, int d, int l, int room, int teacher, int subject) //если не нужно редачить тот или иной елемент - юзать 0 для входящего значения
        {
            unitOfWork.Groups[g][d][l].Edit(room, teacher, subject);
        }

        public bool AddElement(string Name, bool s)
        {
            if(unitOfWork.CheckElement(-1,Name,s) == -1)
            {
                if (s)
                    unitOfWork.Subjects.Create(new Subject(Name));
                else
                    unitOfWork.Teachers.Create(new Teacher(Name));
                return true;
            }else
            {
                return false;
            }
        }

        public void EditElement(int id, string NewName, bool s)
        {
            if (s)
                unitOfWork.Subjects[id].Name = NewName;
            else
                unitOfWork.Teachers[id].Name = NewName;
        }

        public void DeleteElement(int id, bool s)
        {
            if (s)
                unitOfWork.Subjects.DeleteAt(id);
            else
                unitOfWork.Teachers.DeleteAt(id);
        }

        public void DeleteGroup(int id)
        {
            unitOfWork.Groups.Delete(unitOfWork.Groups[id]);
        }

        public bool AddElement(int GroupNum = -1, string Name = "none", bool Subj = false)
        {
            if (unitOfWork.CheckElement(GroupNum, Name, Subj) == -1)
            {
                if (GroupNum == -1)
                {
                    if (Subj)
                    {
                        unitOfWork.Subjects.Create(new Subject(Name));
                    }
                    else
                    {
                        unitOfWork.Teachers.Create(new Teacher(Name));
                    }
                }
                else
                {
                    unitOfWork.Groups.Create(new Group(GroupNum));
                }
                return true;
            }
            return false;
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            return Mapper.Map<IEnumerable<Teacher>, List<TeacherDTO>>(unitOfWork.Teachers.Get());
        }

        public List<SubjectDTO> GetAllSubjects()
        {
            return Mapper.Map<IEnumerable<Subject>, List<SubjectDTO>>(unitOfWork.Subjects.Get());
        }
        public List<UserDTO> GetAllUsers()
        {
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(unitOfWork.Users.Get());
        }
    }
}
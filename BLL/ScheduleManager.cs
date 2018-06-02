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

        public Table GetTable(int Num, int filter) //0 - группа, 1 - предмет, 2 - препод, 3 - аудитория
        {
            Table table = new Table();
            if (filter != 0)
            {
                for (int d = 0; d < 10; d++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        foreach (Group gp in unitOfWork.Groups.Get())
                        {
                            if (filter == 1 && Num == gp[d][l].SubjectId)
                            {
                                table.Cells[d, l].Edit(unitOfWork.Teachers[Num].Name, gp.Number.ToString(), gp[d][l].Room.ToString());
                                break;
                            }
                            else if (filter == 2 && Num == gp[d][l].TeacherId)
                            {
                                table.Cells[d, l].Edit(unitOfWork.Subjects[Num].Name, gp.Number.ToString(), gp[d][l].Room.ToString());
                                break;
                            }
                            else if (filter == 3 && Num == gp[d][l].Room)
                            {
                                table.Cells[d, l].Edit(unitOfWork.Subjects[Num].Name, unitOfWork.Teachers[Num].Name, gp.Number.ToString());
                                break;
                            }
                        }
                    }
                }
            }else
            {
                for(int d = 0; d < 10; d++)
                {
                    for(int l = 0; l < 8; l++)
                    {
                        int sID = unitOfWork.Groups[Num][d][l].SubjectId;
                        int tID = unitOfWork.Groups[Num][d][l].TeacherId;
                        int Room = unitOfWork.Groups[Num][d][l].Room;
                        table.Cells[d, l].Edit(unitOfWork.Subjects[sID].Name, unitOfWork.Teachers[tID].Name, Room.ToString());
                    }
                }
            }

            return table;
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

        public List<int> GetGroupNameList()
        {
            var list = new List<int>(); // юзаем var т.к. левая часть очевидна
            var groups = unitOfWork.Groups.Get();
            foreach (Group g in groups)
                list.Add(g.Number);
            return list;
        }
    }
}
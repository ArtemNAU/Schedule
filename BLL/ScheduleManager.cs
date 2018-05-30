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

        public void DeleteGroup(int Id)
        {
            unitOfWork.Groups.Delete(unitOfWork.Groups.FindById(Id));
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
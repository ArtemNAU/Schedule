using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schedule
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void AddAndRemove_Teacher()
        {
            ScheduleManager sm = new ScheduleManager();

            string FName = "Иванов";
            string SName = "Федоров";
            string TName_Expected = "Петров";

            sm.AddElement(FName, false);
            sm.AddElement(SName, false);
            sm.AddElement(TName_Expected, false);

            sm.DeleteElement(1,false);

            Assert.Equals(TName_Expected, sm.GetElement(1,false));
        }


        [TestMethod]
        public void AddAndRemove_Groups()
        {
            ScheduleManager sm = new ScheduleManager();

            sm.AddGroup(219);
            sm.AddGroup(217);
            sm.AddGroup(219);
            sm.AddGroup(118);
            sm.AddGroup(314);

            sm.DeleteGroup(2);

            int[] list_expected = new int[] { 219, 217, 314 };

            Assert.Equals(list_expected, sm.GetGroupNameList().ToArray());
        }

        [TestMethod]
        public void Get_WrongIndex()
        {
            ScheduleManager sm = new ScheduleManager();

            string expected = "Предмет не найден";

            Assert.Equals(expected, sm.GetElement(5,true));
        }

        [TestMethod]
        public void Edit_Day()
        {
            ScheduleManager sm = new ScheduleManager();

            sm.AddGroup(219);
            sm.AddElement("Федулкин", false);
            sm.AddElement("Сетевые технологии", true);
            sm.EditLesson(0, 1, 3, 114, 1, 1);

            Table tb = new Table(0, 0);
            TableCell tc = new TableCell();
            tc.Edit("Сетевые технологии", "Федулкин", "114");

            Assert.Equals(tc, tb.Cells[1,3]);
        }
    }
}

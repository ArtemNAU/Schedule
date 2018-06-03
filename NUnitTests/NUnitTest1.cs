using System;
using NUnit.Framework;

namespace Schedule
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test()]
        public void AddAndRemove_Teacher()
        {
            ScheduleManager sm = new ScheduleManager();

            string FName = "Иванов";
            string SName = "Федоров";
            string TName_Expected = "Петров";

            sm.AddElement(FName, false);
            sm.AddElement(SName, false);
            sm.AddElement(TName_Expected, false);

            sm.DeleteElement(1, false);

            Assert.AreEqual(TName_Expected, sm.GetElement(1, false));
        }
        [Test()]
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

            Assert.AreEqual(list_expected, sm.GetGroupNameList().ToArray());
        }

        [Test()]
        public void Get_WrongIndex()
        {
            ScheduleManager sm = new ScheduleManager();

            string expected = "Предмет не найден";

            Assert.AreEqual(expected, sm.GetElement(5, true));
        }

        [Test()]
        public void Edit_Element()
        {
            ScheduleManager sm = new ScheduleManager();

            string expected = "Васильева";

            sm.AddElement("Для теста", false);
            sm.EditElement(0, expected, false);

            Assert.AreEqual(expected, sm.GetElement(0, false));
        }

        [Test()]
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

            Assert.AreEqual(tc, tb.Cells[1, 3]);
        }
    }
}
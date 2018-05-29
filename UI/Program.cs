using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Program
    {
        //static IndexBase IBase;

        static void Main()
        {
            ScheduleManager m = new ScheduleManager();
            m.AddGroup(219);

            Console.WriteLine("Список групп:");
            var gList = m.GetGroupNameList();
            foreach (int s in gList)
                Console.WriteLine(s);

            Console.ReadLine();

            /*IBase = new IndexBase();
            Group PI2192 = new Group("PI-219");
            Setup(PI2192);
            PI2192.Save(); //не пашет ибо ругается на SQL*/
        }

        /*static void Setup(Group group)
        {
            IBase.AddT("Іванова Л.М.");
            IBase.AddT("Сідоркіна О.М.");
            IBase.AddT("Дишлевой О.П.");
            IBase.AddT("Вербило Г.П.");
            IBase.AddS("Алгоритми та структури даних");
            IBase.AddS("Філософія");
            IBase.AddS("Архітектура та проектування прог. заб.");
            IBase.AddS("Англійська мова");
            group[0].ChangeLesson(2, 0, 1, "6.200");
            group[0].ChangeLesson(3, 1, 2, "1.303");
            group[1].ChangeLesson(1, 2, 3, "6.201");
            group[1].ChangeLesson(2, 1, 2, "6.201");
            group[1].ChangeLesson(3, 3, 4, "8.1001");
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHNIWIMD
{
    public static class DataControler
    {

        public static void Load() //отсюда будет запуск загрузки данных с БД
        {

        }

        public static int GroupsCount
        {
            get
            {
                return SaveAndLoad.GroupsSize;
            }
        }

    }
}

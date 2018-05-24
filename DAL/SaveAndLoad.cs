using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    public static class SaveAndLoad
    {
        public static void SaveThisGroup(string n, int[] l, int[] d, int[] t, int[] s, string[] r)
        {
            using (UserContext db = new UserContext())
            {
                GroupSave GP = new GroupSave(n, l, d, t, s, r);
                db.Groups.Add(GP);
                db.SaveChanges();
            }
        }

        public static void LoadGroups()
        {

        }

        public static int GroupsSize
        {
            get{
                using (UserContext db = new UserContext())
                {
                    return db.Groups.Count();
                }
            }
        }

    }
}

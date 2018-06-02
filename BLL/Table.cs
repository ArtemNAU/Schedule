using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Schedule
{
    public class Table
    {
        public TableCell[,] Cells;

        public Table()
        {
            Cells = new TableCell[10,8];
            for (int d = 0; d < 10; d++) {
                for (int l = 0; l < 8; l++)
                {
                    TableCell cell = new TableCell();
                    Cells[d, l] = cell;
                }
            }
        }
    }

    public class TableCell
    {
        string FirstRow, SecondRow, ThirdRow;

        public TableCell()
        {
            FirstRow = SecondRow = ThirdRow = "";
        }

        public void Edit(string f, string s, string t)
        {
            FirstRow = f;
            SecondRow = s;
            ThirdRow = t;
        }
    }
}

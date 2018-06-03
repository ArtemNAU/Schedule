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

        public Table (int Num, int filter) //0 - группа, 1 - предмет, 2 - препод, 3 - аудитория
        {
            Cells = new TableCell[10,8];
            UnitOfWork unitOfWork = new UnitOfWork();
            for (int d = 0; d < 10; d++) {
                for (int l = 0; l < 8; l++)
                {
                    TableCell cell = new TableCell();
                    Cells[d, l] = cell;
                }
            }
            if (filter != 0)
            {
                for (int d = 0; d < 10; d++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        foreach (Group gp in unitOfWork.Groups.GetAll(dl => dl.Days))
                        {
                            if (filter == 1 && Num == gp[d][l].SubjectId)
                            {
                                Cells[d, l].Edit(unitOfWork.Teachers[Num].Name, gp.Number.ToString(), gp[d][l].Room.ToString());
                                break;
                            }
                            else if (filter == 2 && Num == gp[d][l].TeacherId)
                            {
                                Cells[d, l].Edit(unitOfWork.Subjects[Num].Name, gp.Number.ToString(), gp[d][l].Room.ToString());
                                break;
                            }
                            else if (filter == 3 && Num == gp[d][l].Room)
                            {
                                Cells[d, l].Edit(unitOfWork.Subjects[Num].Name, unitOfWork.Teachers[Num].Name, gp.Number.ToString());
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int d = 0; d < 10; d++)
                {
                    for (int l = 0; l < 8; l++)
                    {
                        int sID = unitOfWork.Groups[Num][d][l].SubjectId;
                        int tID = unitOfWork.Groups[Num][d][l].TeacherId;
                        int Room = unitOfWork.Groups[Num][d][l].Room;
                        Cells[d, l].Edit(unitOfWork.Subjects[sID].Name, unitOfWork.Teachers[tID].Name, Room.ToString());
                    }
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

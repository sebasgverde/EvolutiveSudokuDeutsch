using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    class Evolution
    {
        List<Sudoku> poblation;
        Fitness fitn;
        Natur natur;

        public Evolution(String sud)
        {
            poblation = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            erstePoblation(sud);
        }

        public void erstePoblation(String sud)
        {
            int [,] matSud = new int[9,9];

            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int aktuell = Convert.ToByte(array[i][j]) - 48;
                    matSud[i, j] = aktuell;
                    if (aktuell != 0)
                        natur.matFest[i, j] = 1;
                }
            }

            poblation.Add(new Sudoku(matSud));
        }

    }
}

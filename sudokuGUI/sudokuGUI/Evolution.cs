using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    public class Evolution
    {
        List<Sudoku> poblation;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;

        public Evolution(String sud)
        {
            poblation = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            setGrundSudoku(sud);
            erstePoblation();
        }

        public void setGrundSudoku(String sud)
        {
            int [,] matSud = new int[9,9];

            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            Console.WriteLine(sud);
            //Console.Read();
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
            grundSudoku = new Sudoku(matSud);
            Console.WriteLine(grundSudoku.sudToString());
        }

        public void erstePoblation()
        { 
            Sudoku temp = new Sudoku();

            for (int j = 0; j < grundSudoku.listSudoku.Count; j++)
                temp.listSudoku.Add(natur.mutationRandom(grundSudoku.listSudoku[j],j));

            Console.WriteLine(temp.sudToString());

            poblation.Add(temp);           
        }

    }
}

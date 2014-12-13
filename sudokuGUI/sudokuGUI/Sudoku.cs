using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    class Sudoku
    {
        private const int GROESS = 9;

        //public int[,] matrixSudoku;        
        public List<int[]> listSudoku;

        public Sudoku(int[,] mat)
        { 
            //matrixSudoku = new int [GROESS, GROESS];
            listSudoku = new List<int[]>();
            setList(mat);

        }

        public void setList(int[,] mat)
        {
            for (int i = 0; i < GROESS; i++)
            {
                int[] temp = new int[9];
                for (int j = 0; j < GROESS; j++)
                {
                    temp[j] = mat[i, j];                  
                }
                listSudoku.Add(temp);
            }
        }

        public void setChromosom(int i, int[] n)
        {
            listSudoku[i] = n;
        }
        /*public int[,] getMatSud()
        {
            return matrixSudoku;
        }

        public int[,] getMatFest()
        {
            return matFest;
        }*/
    }
}

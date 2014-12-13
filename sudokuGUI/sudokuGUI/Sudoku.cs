using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    public class Sudoku
    {
        private const int GROESS = 9;

        //public int[,] matrixSudoku;        
        public List<int[]> listSudoku;

        public Sudoku()
        {
            listSudoku = new List<int[]>();
        }

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

        public String chromoToString(int[] a)
        {
            String b = "";
            for (int i = 0; i < a.Length; i++)
            {
                b += a[i] + "  ";
            }
            return b;
        }

        public String sudToString()
        {
            String b = "";
            for (int i = 0; i < listSudoku.Count; i++)
            {
                b += chromoToString(listSudoku[i]) + "\n";
            }
            return b;
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

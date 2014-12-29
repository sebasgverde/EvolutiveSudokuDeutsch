using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modell
{
    public class Sudoku
    {
        private const int GROESS = 9;

        //public int[,] matrixSudoku;        
        public List<int[]> listSudoku;
        public String[] sudokuStr;
        public int fitness;
        public int fitTotChr;
        public int fitTotSub;
        public int[] fitnessChrom;
        public int[,] fitnessSubMat;
        public float gluckRadSektorGross;

        public Sudoku()
        {
            sudokuStr = new String[9];
            fitnessChrom = new int[9];
            fitnessSubMat = new int[3, 3];
        }

        public Sudoku(String[] s)
        { 
            //matrixSudoku = new int [GROESS, GROESS];
            sudokuStr = s;
        }

        public void setStr(String[] s)
        {
            sudokuStr = s;
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

        public void setChromStr(int i, String a)
        {
            sudokuStr[i] = a;
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
            for (int i = 0; i < sudokuStr.Length; i++)
            {
                b += sudokuStr[i] + "\n";
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

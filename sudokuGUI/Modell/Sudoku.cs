using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modell
{
    /// <summary>
    /// In diesem Class haben wir die Wichtige Information fur ein Sudoku, seine Werte, Fitness usw
    /// </summary>
    public class Sudoku
    {
        private const int GROESS = 9;
          
        /// <summary>
        /// Sudoku Repräsentation als List von Integers
        /// </summary>
        public List<int[]> listSudoku;
        /// <summary>
        /// Sudoku Repräsentation als Array von Strings "viel effizienter"
        /// </summary>
        public String[] sudokuStr;
        /// <summary>
        /// Total Fitness dieses Sudokus
        /// </summary>
        public int fitness;
        /// <summary>
        /// Total Fitness aller Zeile (oder Chromosom)
        /// </summary>
        public int fitTotChr;
        /// <summary>
        /// Total fitness aller Submatrix
        /// </summary>
        public int fitTotSub;
        /// <summary>
        /// Total fitness jedes Zeile
        /// </summary>
        public int[] fitnessChrom;
        /// <summary>
        /// Total fitness jedes Submatrix
        /// </summary>
        public int[,] fitnessSubMat;
        /// <summary>
        /// Gross des Sektors dieses Individuum (es benutzt wird in gluckRadswahl)
        /// </summary>
        public double gluckRadSektorGross;
        /// <summary>
        /// um zu wissen, in welche generation erschaft wurde
        /// </summary>
        public int generation;

        /// <summary>
        /// Constructor
        /// </summary>
        public Sudoku()
        {
            sudokuStr = new String[9];
            fitnessChrom = new int[9];
            fitnessSubMat = new int[3, 3];
        }

        /// <summary>
        /// Constructor, um ein Sudoku zu klonen
        /// </summary>
        /// <param name="s">Sudoku Repräsentation als Array von Strings</param>
        public Sudoku(String[] s)
        { 
            //matrixSudoku = new int [GROESS, GROESS];
            sudokuStr = new String[9];
            fitnessChrom = new int[9];
            fitnessSubMat = new int[3, 3];

            for (int i = 0; i<s.Length;i++ )
                sudokuStr[i] = s[i].Clone().ToString();
        }

        /// <summary>
        /// um ein Sudoku zu aktualisieren
        /// </summary>
        /// <param name="s">Sudoku Repräsentation als Array von Strings</param>
     
        public void setStr(String[] s)
        {
            sudokuStr = s;
        }

        /// <summary>
        /// nicht benutzt, Repräsentation als Liste ist nicht effizient
        /// </summary>
        /// <param name="mat"></param>
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

        /// <summary>
        /// um ein der Zeile zu aktualisieren, es ist notwendig für Mutationen
        /// </summary>
        /// <param name="i">Index in array von integers</param>
        /// <param name="a">Neue chromosom</param>
        public void setChromStr(int i, String a)
        {
            sudokuStr[i] = a;
        }

        /*public void setChromosom(int i, int[] n)
        {
            listSudoku[i] = n;
        }*/

       /* public String chromoToString(int[] a)
        {
            String b = "";
            for (int i = 0; i < a.Length; i++)
            {
                b += a[i] + "  ";
            }
            return b;
        }*/

        /// <summary>
        /// Um Ergebnisse zu zeigen
        /// </summary>
        /// <returns>String Repräsentation des Sudokus in einem Schonen Format</returns>
        public String sudToString()
        {
            String b = "";
            for (int i = 0; i < sudokuStr.Length; i++)
            {
                if (i == 3 || i == 6) b += "--- --- ---\n";
                for (int j = 0; j < 9; j++)
                {
                    if (j == 3 || j == 6) b += "|";
                    b += sudokuStr[i][j];
                }
                b += "\n";
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    class Natur
    {
        private const int GROESS = 9;

        public int[,] matFest;
        Random rand;

        public Natur()
        {
            rand = new Random();
            matFest = new int[GROESS, GROESS];
        }


        public int[] randomVariationVector()
        {
            int[] rv = new int[9];
            for (int i = 0; i < 9; i++)
            {
                rv[i] = rand.Next(-2, 2);
            }
            return rv;
        }

        //j is der position in matrix feste
        public int[] mutationRandom(int[] a, int j)
        {
            for (int i = 0; i < 9; i++)
            {
                if(matFest[j,i] != 1)
                    a[i] = rand.Next(1,9);
            }
            return a;
        }

        public int[] mutation(int[] a, int[] b)
        {
            for (int i = 0; i < 9; i++)
            {
                a[i] += b[i];
            }
            return a;
        }
    }
}

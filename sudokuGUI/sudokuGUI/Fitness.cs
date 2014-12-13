using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    class Fitness
    {
        public Fitness()
        { }

        /*Ich benutze ein Array mit Booleans, wenn cr einen nummer hat, dann werde es ein 1 in dieser Position geben
 * hier das maximal fitness ist 9 (hat die 9 nummer)
 */
        public int fitnessArray(int[] cr)
        {
            int[] numbers = new int[9];
            int fitness = 0;
            for (int i = 0; i < cr.Length; i++)
            {
                if (cr[i] > 0 && cr[i] < 10)
                    numbers[cr[i] - 1] = 1;
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 1)
                    fitness += 1;
            }

            return fitness;
        }
        public int fitnessSubMat(List<int[]> listSudoku, int i, int j)
        {
            int[] numbers = new int[9];
            int fitness = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    int aktuell = listSudoku[i*3 + k][j*3 + l];
                    if (aktuell > 0 && aktuell < 10)
                        numbers[aktuell] = 1;
                }
            }
            for (int k = 0; k < numbers.Length; k++)
            {
                if (numbers[k] == 1)
                    fitness += 1;
            }

            return fitness;
        }                        

        /*das ist nicht effizient
         * public int fitnessSubMat(int[] mat, int i, int j)
        {
            int[] numbers = new int[9];
            int fitness = 0;
            for (int k = 0; k < numbers.Length; k++)
            {
                int aktuell = mat[i*27 + j*3 + k*9];
                if (aktuell > 0 && aktuell < 10)
                    numbers[aktuell] = 1;
            }
            for (int k = 0; k < numbers.Length; k++)
            {
                if (numbers[k] == 1)
                    fitness += 1;
            }

            return fitness;
        }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sudokuGUI;

namespace sudokuConsole
{
    class Sudoku
    {
        int[] numbers;
        Random rand;

        public Sudoku()
        {
            numbers = new int[9];
            rand = new Random();
        }

        public void test()
        {
            Console.WriteLine("hallo hallo");
            //Console.WriteLine(numbers);
            printArray(numbers);
            int fitn = fitnessArray(numbers);

            int i = 0;
            while (fitn < 9)
            {
                numbers = mutation(numbers, randomVariationVector());
                printArray(numbers);
                fitn = fitnessArray(numbers);
                Console.WriteLine(fitn);
                Console.WriteLine(i++);
            }
            Console.ReadLine();
        }

        public int[] randomVariationVector()
        {
            int[] rv = new int [9];
            for(int i = 0; i < 9; i++)
            {
                rv[i] = rand.Next(-2, 2);
            }
            return rv;
        }

        public int[] mutation(int[] a, int[] b)
        {
            for (int i = 0; i < 9; i++)
            {
                a[i] += b[i];
            }
            return a;
        }

        public void printArray(int [] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + "  ");
            }
            Console.WriteLine();
        }


        /*Ich benutze ein Array mit Booleans, wenn cr einen nummer hat, dann werde es ein 1 in dieser Position geben
         * hier das maximal fitness ist 9 (hat die 9 nummer)
         */
        public int fitnessArray(int [] cr)
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
                if(numbers[i] == 1)
                    fitness += 1;
            }

            return fitness;   
        }

        public int fitnessSubMat(int[] mat, int i, int j)
        {
            int[] numbers = new int[9];
            int fitness = 0;
            for (int k = 0; k < numbers.Length; k++)
            {
                int aktuell = mat[i * 27 + j * 3 + k * 9];
                if (aktuell > 0 && aktuell < 10)
                    numbers[aktuell] = 1;
            }
            for (int k = 0; k < numbers.Length; k++)
            {
                if (numbers[k] == 1)
                    fitness += 1;
            }

            return fitness;
        }
    }
}

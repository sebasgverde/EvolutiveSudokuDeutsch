using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    public class Evolution
    {
        List<Sudoku> population;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;

        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            setGrundSudoku(sud);

            int aktuelFit = 0;

            erstePoblation();
            aktuelFit = rechnenFitnessSudoku(population[0]);

            int i = 1;
            while(aktuelFit < 103) 
            {
                Console.WriteLine("\nmutation nummer " + i++);
                teilMutation(0);
                Console.WriteLine(population[0].sudToString());
                aktuelFit = rechnenFitnessSudoku(population[0]);
                //Console.WriteLine(fitn.fitnessArray());            
            } 
            Console.ReadLine();
        }

        public int rechnenFitnessSudoku(Sudoku sudFit)
        {
            int fitTotalChrom = 0;
            int fitTotSubMat = 0;

            foreach(int[] a in  sudFit.listSudoku)
            {
                int fc = fitn.fitnessArray(a);
                fitTotalChrom += fc;
                Console.Write(fc);
            }

            Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int fs = fitn.fitnessSubMat(sudFit.listSudoku, i, j);
                    fitTotSubMat += fs;
                    Console.WriteLine("Fitness subMat " + i + ","+j + " : " + fs);
                }
            }
            Console.WriteLine("Fitn tot chr : " + fitTotalChrom);
            Console.WriteLine("Fitn tot sub ma : " + fitTotSubMat);
            int totalFitness = fitTotalChrom + fitTotalChrom;
            Console.WriteLine("Fitn tot sudoku : " + (totalFitness));
            return totalFitness;

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

            population.Add(temp);           
        }

        //i pos in population, welche sudoku will ich andern
        public void teilMutation(int i)
        {
            int j = 0;
            foreach (int[] a in population[i].listSudoku)
            {
                //population[i].setChromosom(j, 
                natur.mutationRandom2(a, j);
                j++;
            }
        }

    }
}

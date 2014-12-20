using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    public class Evolution
    {
        List<Sudoku> population;
        int maxPopulation;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;
        int populationSize = 4;
        bool print = false;

        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            maxPopulation = 20;
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);

            int aktuelFit = 0;
            int besteFit = 0;

            erstePoblation(populationSize);

            int i = 1;
            while(aktuelFit < 154 && i<1000000) 
            {
               //mutation mit selektion von beste
                int posSel = selektion();

                if(print)Console.WriteLine("\nMutation nummer " + i);
                //erstePoblation();
                teilMutationSwap(posSel);
                //teilMutationSwapNueKind(posSel);
                //teilMutation(0);
                //aktuelFit = population[0].fitness;
                if (population.Count >= maxPopulation) population.RemoveAt(population.Count - 1);
                //recombination von 2 beste

                if (print) Console.WriteLine("\nRekombination nummer " + i);
                int[] positions = selektionRekombination();

                einfachRekombination(positions[0], positions[1]);
                aktuelFit = population[0].fitness;
                if (aktuelFit > besteFit) besteFit = aktuelFit;

                if (print) Console.WriteLine(population[0].sudToString());

                if (population.Count > maxPopulation) population.RemoveAt(population.Count - 1);
                //Console.WriteLine(fitn.fitnessArray());     
                i++;
            }
            if(!print)Console.WriteLine(population[0].fitness);
            Console.ReadLine();
        }

        public int rechnenFitnessSudoku(Sudoku sudFit)
        {
            int fitTotalChrom = 0;
            int fitTotSubMat = 0;


            for (int i = 0; i < sudFit.sudokuStr.Length; i++)
            {
                int fc = fitn.fitnessSaule(i,sudFit.sudokuStr);
                fitTotalChrom += fc;
                if (print) Console.Write(fc);
            }

            if (print) Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int fs = fitn.fitnessSubMat(sudFit.sudokuStr, i, j);
                    fitTotSubMat += fs;
                    if (print) Console.WriteLine("Fitness subMat " + i + "," + j + " : " + fs);
                }
            }

            int totalFitness = fitTotalChrom + fitTotalChrom;
            if (print) 
            {
                Console.WriteLine("Fitn tot chr : " + fitTotalChrom);
                Console.WriteLine("Fitn tot sub ma : " + fitTotSubMat);
                Console.WriteLine("Fitn tot sudoku : " + (totalFitness));
            }
            return totalFitness;

        }

        public void serGrundSudStr(String sud)
        {
            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            //es ist besser in natur nur fragen ob es nicht null ist, das ist weniger rechnung
            natur.matFest = array;
            grundSudoku = new Sudoku(array);

        }

        /*public void setGrundSudoku(String sud)
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
        }*/

        public void einfugenInviduum(Sudoku sud)
        {
            int i = 0;
            while (i < population.Count && sud.fitness < population[i].fitness)
                i++;

            population.Insert(i, sud);
        }

        //diese habe ich aun verandert, weil ich habe bemerkt, dass es sinnlos ist alle random machen,
        //wir wissen, dass es nur 9 nummer gibt, deshalb, die erste population musste nur das haben, und mutation
        //und recombination muestte nur fue die Reihenfolge sein
        public void erstePoblation(int size)
        {
            for(int i = 0; i < size; i++)
            {
                //String[] temp = new String[9];
                Sudoku temp = new Sudoku();

                for (int j = 0; j < grundSudoku.sudokuStr.Length; j++)
                    temp.setChromStr(j, natur.fuellenChromosomRand(grundSudoku.sudokuStr[j]));            

                temp.fitness = rechnenFitnessSudoku(temp);

                if (i == 0)
                    population.Add(temp);
                else
                    einfugenInviduum(temp);
            }
        }

        //i pos in population, welche sudoku will ich andern
        public void teilMutationSwap(int i)
        {
            int j = 0;
            foreach (String a in population[i].sudokuStr)
            {
                //population[i].setChromosom(j, 
                population[i].setChromStr(j,natur.mutationSwap(j, a));
                j++;
            }

            Sudoku temp = population[i];
            if(print)Console.WriteLine(temp.sudToString());
            temp.fitness = rechnenFitnessSudoku(temp); ;

            population.RemoveAt(i);
            einfugenInviduum(temp);
        }

        //Andere Strategie, die mutation gebt ein neues kind
        public void teilMutationSwapNueKind(int i)
        {
            Sudoku temp = new Sudoku();

            int j = 0;
            foreach (String a in population[i].sudokuStr)
            {
                //population[i].setChromosom(j, 
                temp.setChromStr(j, natur.mutationSwap(j, a));
                j++;
            }

            if (print) Console.WriteLine(temp.sudToString());
            temp.fitness = rechnenFitnessSudoku(temp); ;

            population.RemoveAt(population.Count - 1);
            einfugenInviduum(temp);
        }

        public void einfachRekombination(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination1(population[i], population[j]);
            kinder[0].fitness = rechnenFitnessSudoku(kinder[0]);
            kinder[1].fitness = rechnenFitnessSudoku(kinder[1]);

            einfugenInviduum(kinder[0]);
            einfugenInviduum(kinder[1]);
        }

        //gebt die Position von die beste sudoku
        public int selektion()
        {
            return 0;
        }

        public int[] selektionRekombination()
        {
            return new int[] {0,1};
        }

        /*public void erstePoblation()
        { 
            Sudoku temp = new Sudoku();

            for (int j = 0; j < grundSudoku.listSudoku.Count; j++)
                temp.listSudoku.Add(natur.mutationRandom(grundSudoku.listSudoku[j],j));

            Console.WriteLine(temp.sudToString());

            population.Add(temp);           
        }*/

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

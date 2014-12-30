using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modell
{
    public class Evolution
    {
        List<Sudoku> population;
        int maxPopulation;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;
        int populationSize = 7;
        int elite = 5;
        bool print = false;

        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            maxPopulation = 30;
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);            

            int aktuelFit = 0;
            int besteFit = 0;

            erstePoblation(populationSize);

            int i = 1;
            while(aktuelFit < 157 && i<1000000) 
            {
               //mutation mit selektion von beste
                int posSel = selektion();

                if(print)Console.WriteLine("\nMutation nummer " + i);
                //erstePoblation();
                //teilMutationSwap(posSel);
                //teilMutationSwapNueKind(posSel);
                kleinerMutationSwap(posSel);
                //teilMutation(0);
                //aktuelFit = population[0].fitness;
                //if (population.Count >= maxPopulation) population.RemoveAt(population.Count - 1);
                //recombination von 2 beste

                if (print) Console.WriteLine("\nRekombination nummer " + i);
                int[] positions = selektionRekombination();

                einfachRekombination(positions[0], positions[1]);
                aktuelFit = population[0].fitness;
                if (aktuelFit > besteFit) besteFit = aktuelFit;

                if (print) Console.WriteLine(population[0].sudToString());

                while (population.Count > maxPopulation) population.RemoveAt(natur.randomPosLoeschenElite(elite, population.Count));
                //Console.WriteLine(fitn.fitnessArray());     
                i++;
            }
            if(!print)Console.WriteLine(population[0].fitness);
            printPopulation();
            Console.ReadLine();
        }

        public void printPopulation()
        {
            int i = 0;

            foreach(Sudoku s in population)
            {
                Console.WriteLine((i++) + "\n" + s.sudToString() + "\n");
                schauFitness(s);
                if (i > 15) break;
            }
        }
        public void schauFitness(Sudoku sud)
        {
           // if (print) Console.Write(fc);
            //if (print) Console.WriteLine("Fitness subMat " + i + "," + j + " : " + fs);

            Console.Write("Fitn tot chr : ");
            for (int i = 0; i < sud.fitnessChrom.Length; i++)
                Console.Write(sud.fitnessChrom[i]);

                Console.WriteLine("\nFitn tot sub ma : ");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        Console.Write(sud.fitnessSubMat[i, j]);
                    Console.WriteLine();
                }

            Console.WriteLine("\nFitn tot sudoku : " + (sud.fitness));
        }

        public void rechnenFitnessSudoku(Sudoku sudFit)
        {
            int fitTotalChrom = 0;
            int fitTotSubMat = 0;


            for (int i = 0; i < sudFit.sudokuStr.Length; i++)
            {
                int fc = fitn.fitnessSaule(i,sudFit.sudokuStr);
                fitTotalChrom += fc;
                sudFit.fitnessChrom[i] = fc;
            }

            if (print) Console.WriteLine();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int fs = fitn.fitnessSubMat(sudFit.sudokuStr, i, j);
                    fitTotSubMat += fs;
                    sudFit.fitnessSubMat[i,j] = fs;
                }
            }

            sudFit.fitTotChr = fitTotalChrom;
            sudFit.fitTotSub = fitTotalChrom;
            sudFit.fitness = fitTotalChrom + fitTotalChrom;

            if (print) schauFitness(sudFit);
        }

        public void serGrundSudStr(String sud)
        {
            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            //es ist besser in natur nur fragen ob es nicht null ist, das ist weniger rechnung
            natur.matFest = array;
            grundSudoku = new Sudoku(array);

        }

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

                rechnenFitnessSudoku(temp);

                if (i == 0)
                    population.Add(temp);
                else
                    einfugenInviduum(temp);
            }
        }

        //i pos in population, welche sudoku will ich andern
        public void kleinerMutationSwap(int i)//vielleicht andern alle chromosom ist sehr viel, nur eins könnte besser sein
        {
            int j = natur.randomPosLoeschenElite(0,9);

            population[i].setChromStr(j, natur.mutationSwap(j, population[i].sudokuStr[j]));

            Sudoku temp = population[i];
            if (print) Console.WriteLine(temp.sudToString());
            rechnenFitnessSudoku(temp); ;

            population.RemoveAt(i);
            einfugenInviduum(temp);
        }

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
            rechnenFitnessSudoku(temp); ;

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
            rechnenFitnessSudoku(temp); ;

            //population.RemoveAt(population.Count - 1);
            einfugenInviduum(temp);
        }

        public void einfachRekombination(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination1(population[i], population[j]);
            rechnenFitnessSudoku(kinder[0]);
            rechnenFitnessSudoku(kinder[1]);

            einfugenInviduum(kinder[0]);
            einfugenInviduum(kinder[1]);
        }

        //gebt die Position von die beste sudoku
        public int selektion()
        {
            return natur.randomPos(population.Count);
        }

        public int[] selektionRekombination()
        {
            //return new int[] {natur.randomPos(population.Count),0};
            return new int[] { 0, natur.RouletteSelektion(population)};
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

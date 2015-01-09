using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modell
{
    public class Evolution
    {
        List<Sudoku> population;
        List<Sudoku> elites;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;
        int populationSize = 8;
        int elite = 5;
        int maxGenerations = 1000000;
        int maxPopulation = 100;
        int zielFitness = 162;
        bool print = false;
        int generationIndex = 0;

        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            elites = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);            

            int aktuelFit = 0;
            int besteFit = 0;

            erstePoblation(populationSize);

            int generationenOhneVerbesserung = 0;
            generationIndex = 1;
            while (aktuelFit < zielFitness && generationIndex < maxGenerations) 
            {
               //mutation mit selektion
                int posSel = selektion();
                int[] positions = selektionRekombination();

                if(print)Console.WriteLine("\nMutation nummer " + generationIndex);
                if (aktuelFit < zielFitness)
                {
                    //erstePoblation();
                    //teilMutationSwap(posSel);
                    teilMutationSwapNueKind(posSel);
                    //kleinerMutationSwapNeuKindMitEinschrankung(posSel);
                    kleinerMutationSwapNeuKind(posSel);
                    kleinerMutationSwap(posSel);
                    //teilMutation(0);
                    //aktuelFit = population[0].fitness;
                    //if (population.Count >= maxPopulation) population.RemoveAt(population.Count - 1);

                    //recombination von 2 beste

                    if (print) Console.WriteLine("\nRekombination nummer " + generationIndex);

                    einfachRekombination(positions[0], positions[1]);
                    rekombinationVieleOrte(positions[0], positions[1]);
                }
                else 
                {
                    posSel = natur.randomPos(elite);

                    //kleinerMutationSwapNeuKindMitEinschrankung(posSel);
                    //mutationSwapOhneNeunFitness(posSel);
                    einfachRekombination(positions[0], positions[1]);
                    rekombinationVieleOrte(positions[0], positions[1]);
                }

                aktuelFit = population[0].fitness;
                if (aktuelFit > besteFit) { besteFit = aktuelFit; generationenOhneVerbesserung = 0; }
                else generationenOhneVerbesserung++;

                if (generationenOhneVerbesserung > 50000)
                {
                    restart();
                    //aufwiedersehenBeste();
                     //superMutation(); 
                    //besteFit = population[0].fitness; 
                    generationenOhneVerbesserung = 0;
                }

                if (print) Console.WriteLine(population[0].sudToString());

                while (population.Count > maxPopulation) population.RemoveAt(natur.randomPosLoeschenElite(elite, population.Count));
                //Console.WriteLine(fitn.fitnessArray());     
                generationIndex++;
            }

            if(!print)Console.WriteLine(population[0].fitness);
            printPopulation();

            Console.WriteLine(generationIndex);
            
            Console.ReadLine();
        }

        public void printPopulation()
        {
            int i = 0;

            foreach(Sudoku s in population.Reverse<Sudoku>())
            {
                Console.WriteLine((i++) + "\n" + s.sudToString() + "\n");
                schauFitness(s);
            }
        }
        public void schauFitness(Sudoku sud)
        {
           // if (print) Console.Write(fc);
            //if (print) Console.WriteLine("Fitness subMat " + i + "," + j + " : " + fs);

            Console.WriteLine("Fitn tot chr : " + sud.fitTotChr);
            for (int i = 0; i < sud.fitnessChrom.Length; i++)
                Console.Write(sud.fitnessChrom[i]);

                Console.WriteLine("\nFitn tot sub ma : " + sud.fitTotSub);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        Console.Write(sud.fitnessSubMat[i, j]);
                    Console.WriteLine();
                }

            Console.WriteLine("\nFitn tot sudoku : " + (sud.fitness));
        }

        public void superMutation()
        {
            for(int i = 0; i < population.Count; i++)
                kleinerMutationSwap(0);
        }

        public void restart()
        {
            elites.Add(population[0]);
            population.Clear();

            if (elites.Count >= populationSize)
            {
                foreach (Sudoku s in elites)
                {
                    Sudoku n = new Sudoku(s.sudokuStr);
                    rechnenFitnessSudoku(n);
                    einfugenInviduum(n);
                }
                //elites.Clear();
            }
            else
                erstePoblation(populationSize);



           /* foreach (Sudoku s in elites)
            {
                Sudoku n = new Sudoku(s.sudokuStr);
                rechnenFitnessSudoku(n);
                einfugenInviduum(n);
            }*/
        }
        public void aufwiedersehenBeste()
        {
            int fit = population[0].fitness;
            
            /*while (population[1].fitness == fit)
            {
                population.RemoveAt(0);
            }*/
            int i = 0;
            
            while (i < population.Count - 1)
            {
                fit = population[i].fitness;
                while (i + 1 < population.Count && population[i + 1].fitness == fit)
                {
                    population.RemoveAt(i);
                }
                i++;
            }
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
            sudFit.fitTotSub = fitTotSubMat;
            sudFit.fitness = fitTotalChrom + fitTotSubMat;

            if (print) schauFitness(sudFit);
        }

        public void serGrundSudStr(String sud)
        {
            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            //es ist besser in natur nur fragen ob es nicht null ist, das ist weniger rechnung
            natur.matFest = array;
            grundSudoku = new Sudoku(array);

        }

        public void einfugenInviduum(Sudoku sud)//ich benutze auch um die generation index zu stellen
        {
            sud.generation = generationIndex;
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
                temp.generation = 0;

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

        public void kleinerMutationSwapNeuKind(int i)//vielleicht andern alle chromosom ist sehr viel, nur eins könnte besser sein
        {
            Sudoku temp = new Sudoku();

            int j = 0;
            int posMut = natur.randomPosLoeschenElite(0, 9);

            foreach (String a in population[i].sudokuStr)
            {
                //population[i].setChromosom(j, 
                if (j == posMut) temp.setChromStr(j, natur.mutationSwap(j, a));
                else temp.setChromStr(j, a);
                j++;
            }

            if (print) Console.WriteLine(temp.sudToString());
            rechnenFitnessSudoku(temp); ;

            //population.RemoveAt(population.Count - 1);
            einfugenInviduum(temp);
        }

        public void kleinerMutationSwapNeuKindMitEinschrankung(int i)
        {
            Sudoku temp = new Sudoku();

            int j = 0;
            int posMut = natur.randomPosLoeschenElite(0, 9);

            foreach (String a in population[i].sudokuStr)
            {
                //population[i].setChromosom(j, 
                if (j == posMut) temp.setChromStr(j, natur.mutationSwapMitEinschrankung(j, a, population[i].fitnessChrom));
                else temp.setChromStr(j, a);
                j++;
            }

            if (print) Console.WriteLine(temp.sudToString());
            rechnenFitnessSudoku(temp); ;

            //population.RemoveAt(population.Count - 1);
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

        public void mutationSwapOhneNeunFitness(int i)//mach swap zwischen 2 saule mit weniger als 9 fitness
         {
             Sudoku temp = new Sudoku();
             Sudoku su = population[i];

             //2 Saule ohne 9 fitness
             List<int> saulePos = new List<int>();
             for (int j = 0; j < 9; j++)
                 if (su.fitnessChrom[j] < 9)
                     saulePos.Add(j);

             //ein chromosom wenn die beide saule sind nicht fest
             int chromPos = 0;
             while (natur.matFest[chromPos][saulePos[0]] != '0' && natur.matFest[chromPos][saulePos[1]] != '0')// || fitnessSaule[pos] == 9)
                 chromPos = natur.nachstePos(chromPos);

             int k = 0;
             foreach (String a in su.sudokuStr)
             {
                 if (k == chromPos) temp.setChromStr(chromPos, natur.mutationSwapOhneNeunFitness(a, saulePos[0], saulePos[1]));
                 else temp.setChromStr(k, a);
                 k++;
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

        public void rekombinationVieleOrte(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination2(population[i], population[j]);
            rechnenFitnessSudoku(kinder[0]);
            rechnenFitnessSudoku(kinder[1]);

            einfugenInviduum(kinder[0]);
            einfugenInviduum(kinder[1]);
        }

        //gebt die Position von die beste sudoku
        public int selektion()
        {
            return natur.randomPosLoeschenElite(elite - 1, population.Count - 1);
        }

        public int[] selektionRekombination()
        {
            //return new int[] {natur.randomPos(population.Count),0};
            return new int[] { natur.randomPos(elite), natur.RouletteSelektion(population) };
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

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
        List<Sudoku> eltern;
        Sudoku grundSudoku;
        Fitness fitn;
        Natur natur;
        int populationSize = 3000;
        int elite = 150;
        int maxGenerations = 500;
        int maxPopulation = 3000;
        int zielFitness = 162;
        int mutationChance = 5;//%
        int crossoverChance = 50;
        bool print = false;
        int generationIndex = 0;

        int mutationMethode;
        int mutationRadius;
        int crossoverMethode;

        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            elites = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);

            run();           
        }

        public Evolution(String sud, int popSize, int elit, int maxGen, int maxPop, int mutChanc, int crossovChanc, int mutMet, int mutRad, int crossMet)
        {
            population = new List<Sudoku>();
            elites = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);

            populationSize = popSize;
            elite = elit;
            maxGenerations = maxGen;
            maxPopulation = maxPop;
            mutationChance = mutChanc;//%
            crossoverChance = crossovChanc;

            mutationMethode = mutMet;
            mutationRadius = mutRad;
            crossoverMethode = crossMet;

            erstePoblation(populationSize);
            einfugenInviduum(population[0], elites);
        }

        public void mutationInterface(int methode, Sudoku s)
        {
            switch (methode)
            {
                case 0:
                    mutationSwap(s);
                    break;
                case 1:
                    MutationSwapMitEinschrankung(s);
                    break;
                case 2:
                    mutationSwapOhneNeunFitness(s);
                    break;
                default:
                    mutationSwap(s);
                    break;;
            }

        }

        public Sudoku[] crossoverInterface(int methode, int i, int j)
        {
            switch (methode)
            {
                case 0:
                    return einfachRekombination(i, j);
                case 1:
                    return rekombinationVieleOrte(i, j);
                default:
                    return rekombinationVieleOrte(i, j);

            }
        }



        public String run()
        {
            int aktuelFit = 0;
            int besteFit = 0;

            int generationenOhneVerbesserung = 0;
            generationIndex = 1;
            while (aktuelFit < zielFitness && generationIndex < maxGenerations)
            {
                //elites.Add(population[0]);
                List<Sudoku> tempPopulation = new List<Sudoku>();
                while (tempPopulation.Count < maxPopulation)
                {
                    int[] positions = selektionRekombination();

                    if (natur.randomZahl(0, 100) < crossoverChance)
                    {
                        Sudoku[] kinder = crossoverInterface(crossoverMethode, positions[0], positions[1]);
                        //Sudoku[] kinder = rekombinationVieleOrte(positions[0], positions[1]);

                        if (natur.randomZahl(0, 100) < mutationChance)
                            mutationInterface(mutationMethode, kinder[natur.randomZahl(0, 2)]);
                        //teilMutationSwap(kinder[natur.randomZahl(0, 2)]);

                        einfugenInviduum(kinder[0], tempPopulation);
                        einfugenInviduum(kinder[1], tempPopulation);
                    }
                    else 
                    {
                        einfugenInviduum(population[positions[0]], tempPopulation);
                        einfugenInviduum(population[positions[1]], tempPopulation);
                    }

                }

                population.Clear();
                population = tempPopulation;
                
                /*mutation mit selektion
                int posSel = selektion();


                if (print) Console.WriteLine("\nMutation nummer " + generationIndex);
                if (print) Console.WriteLine("\nRekombination nummer " + generationIndex);*/

                aktuelFit = population[0].fitness;
                if (aktuelFit > besteFit) { besteFit = aktuelFit; generationenOhneVerbesserung = 0; }
                else generationenOhneVerbesserung++;

                if (generationenOhneVerbesserung > 15)
                {
                    //break;
                    //superMutation();
                    restart(1); besteFit = 0;
                    //foreach(Sudoku s in elites)
                      //  einfugenInviduum(s,population);
                    Console.WriteLine(":'(");
                    generationenOhneVerbesserung = 0;
                }
                generationIndex++;
            }

            //printPopulation();
            Console.WriteLine(generationIndex);
            //Console.ReadLine();

            Sudoku retSud = population[0].fitness > elites[0].fitness ? population[0] : elites[0];


            return (retSud.sudToString() + schauFitness(retSud) + "\nGeneration Nummer: " + generationIndex);
        }

        public String printPopulation()
        {
            String a = "";
            int i = 0;

            foreach(Sudoku s in elites)//population.GetRange(0,15).Reverse<Sudoku>())
            {
                a += ("\n" + (i++) + "\n" + s.sudToString() + "\n");
                a += (schauFitness(s));
            }
            return a;
        }
        public String schauFitness(Sudoku sud)
        {
            String ret = "";
           // if (print) Console.Write(fc);
            //if (print) Console.WriteLine("Fitness subMat " + i + "," + j + " : " + fs);

            ret  += ("\nFitn tot chr : " + sud.fitTotChr + "\n");
            for (int i = 0; i < sud.fitnessChrom.Length; i++)
                ret  += (sud.fitnessChrom[i]);

            ret += ("\n\nFitn tot sub ma : " + sud.fitTotSub + "\n");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                        ret += (sud.fitnessSubMat[i, j]);
                    ret  += "\n";
                }

            ret  += ("\n\nFitn tot sudoku : " + (sud.fitness));

            return ret;
        }

        public void superMutation()
        {
            for(int i = 1; i < population.Count; i++)
                if(population[i].fitness == population[i-1].fitness)
                //if (natur.randomZahl(0, 100) < 100-mutationChance)
                kleinerMutationSwap(population[i]);
        }

        public void restart(int fall)
        {
            //if (elites.Count > 1 && elites[0].fitness == elites[1].fitness)
                //kleinerMutationSwap(0, elites);


            if (fall == 0)
            {
                foreach (Sudoku s in elites)
                {
                    population.Clear();
                    Sudoku n = new Sudoku(s.sudokuStr);
                    rechnenFitnessSudoku(n);
                    einfugenInviduum(n,population);
                }
                populationSize = population.Count;
            }
            else
            {
                einfugenInviduum(population[0], elites);
                population.Clear();
                erstePoblation(populationSize);
            }

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

        public void einfugenInviduum(Sudoku sud, List<Sudoku> population)//ich benutze auch um die generation index zu stellen
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
                    einfugenInviduum(temp, population);
            }
        }

        public void mutationSwap(Sudoku s)
        {
            for (int i = 0; i < mutationRadius; i++)
            {
                int j = natur.randomPosLoeschenElite(0, 9);

                s.setChromStr(j, natur.mutationSwap(j, s.sudokuStr[j]));
            }
            rechnenFitnessSudoku(s);
        }

        //Andere Strategie, die mutation gebt ein neues kind

        public void MutationSwapMitEinschrankung(Sudoku s)
        {
          
            for (int i = 0; i < mutationRadius; i++)
            {
                int j = natur.randomPosLoeschenElite(0, 9);
                s.setChromStr(j, natur.mutationSwapMitEinschrankung(j, s.sudokuStr[j], s.fitnessChrom));
            }
            rechnenFitnessSudoku(s);
        }

        public void mutationSwapOhneNeunFitness(Sudoku su)//mach swap zwischen 2 saule mit weniger als 9 fitness
         {
             //2 Saule ohne 9 fitness
             List<int> saulePos = new List<int>();
             for (int j = 0; j < 9; j++)
                 if (su.fitnessChrom[j] < 9)
                     saulePos.Add(j);

             //ein chromosom wenn die beide saule sind nicht fest
             int chromPos = 0;
             while (natur.matFest[chromPos][saulePos[0]] != '0' && natur.matFest[chromPos][saulePos[1]] != '0')// || fitnessSaule[pos] == 9)
                 chromPos = natur.nachstePos(chromPos);

             su.setChromStr(chromPos, natur.mutationSwapOhneNeunFitness(su.sudokuStr[chromPos], saulePos[0], saulePos[1]));
             rechnenFitnessSudoku(su);
        }

        public Sudoku[] einfachRekombination(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination1(population[i], population[j]);
            rechnenFitnessSudoku(kinder[0]);
            rechnenFitnessSudoku(kinder[1]);

            //einfugenInviduum(kinder[0], population);
            //einfugenInviduum(kinder[1], population);

            return kinder;
        }

        public Sudoku[] rekombinationVieleOrte(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination2(population[i], population[j]);
            rechnenFitnessSudoku(kinder[0]);
            rechnenFitnessSudoku(kinder[1]);

            //einfugenInviduum(kinder[0], population);
            //einfugenInviduum(kinder[1], population);

            return kinder;
        }

        //gebt die Position von die beste sudoku
        public int selektion()
        {
            return natur.randomPosLoeschenElite(elite - 1, population.Count - 1);
        }

        public int[] selektionRekombination()
        {
            //return new int[] {natur.randomPos(population.Count),0};
            //return new int[] { natur.randomPosPopulation(elite), natur.RouletteSelektion(population) };
            //return new int[] { natur.RouletteSelektion(population), natur.RouletteSelektion(population) };
            return new int[] { natur.randomPosPopulation(population.Count), natur.turnierSelektion(10,population) };//turnier
        }














        //------------------------------------------------------------------------------------------
        //i pos in population, welche sudoku will ich andern
        public void kleinerMutationSwap(Sudoku s)//vielleicht andern alle chromosom ist sehr viel, nur eins könnte besser sein
        {
            int j = natur.randomPosLoeschenElite(0, 9);

            s.setChromStr(j, natur.mutationSwap(j, s.sudokuStr[j]));

            Sudoku temp = s;
            if (print) Console.WriteLine(temp.sudToString());
            rechnenFitnessSudoku(temp); ;

            //population.RemoveAt(i);
            //einfugenInviduum(temp, population);
        }

        public void teilMutationSwap(Sudoku s)



        {
            int j = 0;
            foreach (String a in s.sudokuStr)
            {
                //population[i].setChromosom(j, 
                s.setChromStr(j, natur.mutationSwap(j, a));
                j++;
            }

            Sudoku temp = s;
            if (print) Console.WriteLine(temp.sudToString());
            rechnenFitnessSudoku(temp);
        }
        /*diese methoden waren eine schlechte architektur, mutation muss nur ein sudoku verandern, es muss
        void sein, ich muss wenn es call entscheiden ob es + oder coma estrategie ist*/

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
            einfugenInviduum(temp, population);
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
            einfugenInviduum(temp, population);
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

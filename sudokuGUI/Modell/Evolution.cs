using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modell
{
    /// <summary>
    /// Haupt class hier haben wir die Definitionen fÜr den ganzen Program, wie die Population sich entwickeln
    /// und ändern
    /// </summary>
    public class Evolution
    {
        List<Sudoku> population;
        List<Sudoku> elites;
        //List<Sudoku> eltern;
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

        int selektionMethode;
        int turnierTeilnhemer;

        int restartMethode;
        int restartTolleranz;
        
        /// <summary>
        /// Constructor des class, es initialisiert die verschidene Liste, die wir brauchen
        /// </summary>
        /// <param name="sud">String </param>
        public Evolution(String sud)
        {
            population = new List<Sudoku>();
            elites = new List<Sudoku>();
            fitn = new Fitness();
            natur = new Natur();
            serGrundSudStr(sud);
        }

        /// <summary>
        /// Mit diese Funktion kann die Benutzerschnittstelle alle Parameters des Evolutionäre Algorithmien
        /// aktualisieren (in laufzeit, was uns ein Dynamische entwicklung erlaubt)
        /// </summary>
        /// <param name="popSize">Gross der erste Population</param>
        /// <param name="elit">Anzahl Elites</param>
        /// <param name="maxGen">Maximal Generationen</param>
        /// <param name="maxPop">Maximal Anzahl Individuen in Population</param>
        /// <param name="mutChanc">Mutationwahrscheinlichkeit, wenn wir ein neues Kinder haben,
        /// kann es mutiert wird oder nein, es hängt von diesem Parameter</param>
        /// <param name="crossovChanc">Nach wir 2 Eltern von dem Populationhewählt haben, könenn wir Sie in
        /// neue Generation einfügen oder ein Crossover zu machen und Ihre Kinder einzufügen, es hängt von diesem Parameter </param>
        /// <param name="mutMet">0 -> Random swap
        /// 1 -> Random Swap mit einschränkung
        /// 2 -> Swap swischen Spalte mit Fitness kleiner als 9</param>
        /// <param name="mutRad">Wie viele Male machen wir ein Mutation</param>
        /// <param name="crossMet">0 -> 1-Punkt Crossover
        /// 1 -> Uniform Crossover</param>
        public void updateParameters(int popSize, int elit, int maxGen, int maxPop, int mutChanc, int crossovChanc, int mutMet, int mutRad, int crossMet)
        {
            populationSize = popSize;
            elite = elit;
            maxGenerations = maxGen;
            maxPopulation = maxPop;
            mutationChance = mutChanc;//%
            crossoverChance = crossovChanc;

            mutationMethode = mutMet;
            mutationRadius = mutRad;
            crossoverMethode = crossMet;
        }

        /// <summary>
        /// aktulisieren Parameters für restart
        /// </summary>
        /// <param name="met">0 ->Restart
        /// 1 -> Nichts
        /// 2 -> Mutation</param>
        /// <param name="tolleranz">Wie Viele Generationen ohne verbesserung es kann geben</param>
        public void updateRestart(int met, int tolleranz)
        {
            restartMethode = met;
            restartTolleranz = tolleranz;
        }

        /// <summary>
        /// abhängig restart Methode, mach die entsprechende Funktion
        /// </summary>
        public void restartInterface()
        {
            switch (restartMethode)
            {
                case 0:
                    restart(1);
                    break;
                case 1:
                    //nichts
                    break;
                case 2:
                    superMutation();
                    break;
                default:
                    restart(1);
                    break;
            }
        }

        /// <summary>
        /// abhängig des Mutation Methode, mach die entsprechende Funktion
        /// </summary>
        /// <param name="methode">0 -> Random swap
        /// 1 -> Random Swap mit einschränkung
        /// 2 -> Swap swischen Spalte mit Fitness kleiner als 9</param>
        /// <param name="s">Sudoku, das mutiert werden wird</param>
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
                    break;
            }

        }

        /// <summary>
        /// abhängig des Crossover Methode, mach die entsprechende Funktion
        /// </summary>
        /// <param name="methode">0 -> 1-Punkt Crossover
        /// 1 -> Uniform Crossover</param>
        /// <param name="i">Index Eltern 1 in Population Liste</param>
        /// <param name="j">Index Eltern 2 in Population Liste</param>
        /// <returns></returns>
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

        /// <summary>
        /// Fitness des besten Individuums in aktueller Generation
        /// </summary>
        public int aktuelFit = 0;
        /// <summary>
        /// Fitness des besten Individuums in aller Generation
        /// </summary>
        public int besteFit = 0;

        /// <summary>
        /// Wie Viele Generationen ohne verbesserung es geben kann
        /// </summary>
        public int generationenOhneVerbesserung = 0;

        /// <summary>
        /// Hier die erste Population erschafft wird und die Control Parameters initialisiert werden
        /// </summary>
        public void start()
        {
            generationIndex = 0;
            erstePoblation(populationSize);
            einfugenInviduum(population[0], elites);

            aktuelFit = population[0].fitness;
            fitnesGeneration.Add(aktuelFit);
            besteFit = 0;

            generationenOhneVerbesserung = 0;
        }

        /// <summary>
        /// Mit diese Funktion kann die Benutzerschnittstelle machen, dass das Program bis ende weitergehen
        /// </summary>
        /// <returns>Beste Individuum, Fitness und Generaion Information in String Format</returns>
        public String weiterGehenBisEnde()
        {
            while (aktuelFit < zielFitness && generationIndex < maxGenerations)
            {
                shrittEvol();
            }

            //printPopulation();
            Console.WriteLine(generationIndex);
            //Console.ReadLine();

            return getBesteSudPop();
        }
       
        /// <summary>
        /// Mit diese Funktion kann die Benutzerschnittstelle machen, dass die Population "shritte" Male sich 
        /// entwickeln
        /// </summary>
        /// <param name="shritte">Generationen um weiterzugehen</param>
        /// <returns>Beste Individuum, Fitness und Generaion Information in String Format</returns>
        public String weiterGehenNSchritte(int shritte)
        {
            int i = 0;
            while (aktuelFit < zielFitness && i++ < shritte)
            {
                shrittEvol();                
            }

            //printPopulation();
            Console.WriteLine(generationIndex);
            //Console.ReadLine();

            return getBesteSudPop();
        }

        /// <summary>
        /// das beste individuum kann in Population oder in Elites Liste sein, diese Funktion sucht, welche
        /// die Beste Fitness hat
        /// </summary>
        /// <returns>Beste Individuum, Fitness und Generaion Information in String Format</returns>
        public string getBesteSudPop()
        {
            Sudoku retSud = population[0].fitness > elites[0].fitness ? population[0] : elites[0];
            return (retSud.sudToString() + schauFitness(retSud) + "\nGeneration Nummer: " + generationIndex);
        }

        /// <summary>
        /// 1 neue Generation entwickeln (hier ist das haupt Evolutionäre Methode,selektion, operatoren und fitness)
        /// </summary>
        public void shrittEvol()
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

            aktuelFit = population[0].fitness;
            if (aktuelFit > besteFit) { besteFit = aktuelFit; generationenOhneVerbesserung = 0; }
            else generationenOhneVerbesserung++;

            if (generationenOhneVerbesserung > restartTolleranz)
            {
                //break;
                restartInterface();
                //foreach(Sudoku s in elites)
                //  einfugenInviduum(s,population);
                Console.WriteLine(":'(");
                generationenOhneVerbesserung = 0;
            }
            fitnesGeneration.Add(aktuelFit);
            generationIndex++;
        }

        /// <summary>
        /// Macht ein String mit die Sudokus in Fitness Array, diese sind die beste von jeder Versuch
        /// </summary>
        /// <returns>String representation die alle Elites</returns>
        public String printElites()
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

        /// <summary>
        /// Macht ein String mit dem Fitness von jedem Individuum in Population
        /// </summary>
        /// <returns></returns>
        public String printFitnesPop()
        {
            String ind = "";
            int i = 0;

            foreach (Sudoku s in population)//population.GetRange(0,15).Reverse<Sudoku>())
            {
                ind += ("Ind " + (i++) + " " + s.fitness + "\n");
                //fit += (s.fitness + " ");
            }
            return ind + "\n";
        }

        /// <summary>
        /// Liste mit beste Fitness jeder Generation
        /// </summary>
        public List<int> fitnesGeneration = new List<int>();

        /// <summary>
        /// Macht ein String mit dem Fitness von jedem besten Individuum jeder Generation
        /// </summary>
        /// <returns></returns>
        public String printFitnessGenerationen()
        {
            String ind = "";
            int i = 0;
            foreach (int s in fitnesGeneration)//population.GetRange(0,15).Reverse<Sudoku>())
            {
                ind += ("Gen " + (i++) + " " + s + "\n");
                //fit += (s.fitness + " ");
            }
            return ind + "\n";
        }

        /// <summary>
        /// Macht ein String mit dem total Fitness, total chromosm Fitness, total sub matrix Fitness, fitness
        /// jeder Zeile unf fitness jedes Sub Matrix
        /// </summary>
        /// <param name="sud">Sudoku, dessen Fitness wir sehen möchten</param>
        /// <returns></returns>
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

        /// <summary>
        /// Mutation viele individuen in Population (für lokales Maximum)
        /// </summary>
        public void superMutation()
        {
            int j = 0;
            for (int i = 1; i < population.Count; i++)
                if (population[i].fitness == population[j].fitness)
                    //if (natur.randomZahl(0, 100) < 100-mutationChance)
                    mutationSwap(population[i]);
                else j=i;
        }

        /// <summary>
        /// abhängig fall erschafft es eine neue population oder benutzt die beste 
        /// individuen von andere Generationen
        /// </summary>
        /// <param name="fall">wie das restart machen</param>
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
        
        /// <summary>
        /// es rechnet die Fitness für ein Sudoku
        /// </summary>
        /// <param name="sudFit">Ein sudoku, um Fitness zu rechnen</param>
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

        /// <summary>
        /// es erschafft ein erste Sudoku mit der Eingabe von GUI
        /// </summary>
        /// <param name="sud">Sudoku wie ein String un 0s in Leere Positionen</param>
        public void serGrundSudStr(String sud)
        {
            string[] array = sud.Replace("\r\n", "\n").Split('\n');
            //es ist besser in natur nur fragen ob es nicht null ist, das ist weniger rechnung
            natur.matFest = array;
            grundSudoku = new Sudoku(array);

        }

        /// <summary>
        /// ein neues Sudoku in ein Liste einfügen, abhängig Fitness
        /// </summary>
        /// <param name="sud">ein Sudoku</param>
        /// <param name="population">in Welcher Liste</param>
        public void einfugenInviduum(Sudoku sud, List<Sudoku> population)//ich benutze auch um die generation index zu stellen
        {
            sud.generation = generationIndex;
            int i = 0;
            while (i < population.Count && sud.fitness < population[i].fitness)
                i++;

            population.Insert(i, sud);
        }


        /// <summary>
        ///diese habe ich aun verandert, weil ich habe bemerkt, dass es sinnlos ist alle random machen,
        ///wir wissen, dass es nur 9 nummer gibt, deshalb, die erste population musste nur das haben, und mutation
        ///und recombination muestte nur fue die Reihenfolge sein
        /// </summary>
        /// <param name="size">Gróss erste Population</param>
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

        /// <summary>
        /// sucht ein Random position zwischen 0 und 8, dann in
        /// diese Zeiele swap 2 nicht Feste Werte, und macht das nochmals, "mutation Radius" Male
        /// </summary>
        /// <param name="s">Sudokus, das mutiert wird</param>
        public void mutationSwap(Sudoku s)
        {
            for (int i = 0; i < mutationRadius; i++)
            {
                int j = natur.randomPosLoeschenElite(0, 9);

                s.setChromStr(j, natur.mutationSwap(j, s.sudokuStr[j]));
            }
            rechnenFitnessSudoku(s);
        }

        /// <summary>
        /// sucht ein Random position zwischen 0 und 8, dann in
        /// diese Zeile swap 2 nicht Feste Werte, aber in den nuen Positionen, die Spalte 
        /// muss nicht diese wert als Feste haben, und macht das nochmals, "mutation Radius" Male
        /// </summary>
        /// <param name="s">Sudokus, das mutiert wird</param>
        public void MutationSwapMitEinschrankung(Sudoku s)
        {
          
            for (int i = 0; i < mutationRadius; i++)
            {
                int j = natur.randomPosLoeschenElite(0, 9);
                s.setChromStr(j, natur.mutationSwapMitEinschrankung(j, s.sudokuStr[j], s.fitnessChrom));
            }
            rechnenFitnessSudoku(s);
        }

        /// <summary>
        /// es macht swap zwischen 2 saule mit weniger als 9 fitness
        /// </summary>
        /// <param name="su">Sudokus, das mutiert wird</param>
        public void mutationSwapOhneNeunFitness(Sudoku su)
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

        /// <summary>
        /// 1-Punkt Crossover
        /// </summary>
        /// <param name="i">Index Eltern 1</param>
        /// <param name="j">Index Eltern 2</param>
        /// <returns>Liste mit 2 Neue Sudokus (Kinder)</returns>
        public Sudoku[] einfachRekombination(int i, int j)
        {
            Sudoku[] kinder = natur.rekombination1(population[i], population[j]);
            rechnenFitnessSudoku(kinder[0]);
            rechnenFitnessSudoku(kinder[1]);

            //einfugenInviduum(kinder[0], population);
            //einfugenInviduum(kinder[1], population);

            return kinder;
        }

        /// <summary>
        /// Uniform Crossover
        /// </summary>
        /// <param name="i">Index Eltern 1</param>
        /// <param name="j">Index Eltern 2</param>
        /// <returns>Liste mit 2 Neue Sudokus (Kinder)</returns>
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
        /*public int selektion()
        {
            return natur.randomPosLoeschenElite(elite - 1, population.Count - 1);
        }*/

        /// <summary>
        /// /// aktulisieren Parameters für Selektion
        /// </summary>
        /// <param name="selM">0 ->Turnierauswahl
        /// 1 -> Glücksradauswahl</param>
        /// <param name="turnTeil">Teilnehmer in Turnier</param>
        public void selektionUpdate(int selM, int turnTeil)
        {
            selektionMethode = selM;
            turnierTeilnhemer = turnTeil;
        }

        /// <summary>
        /// abhängig Selektion Methode, mach die entsprechende Funktion
        /// </summary>
        /// <returns></returns>
        public int selektionInterface()
        {
            switch (selektionMethode)
            {
                case 0:
                    return natur.turnierSelektion(turnierTeilnhemer, population);
                case 1:
                    return natur.RouletteSelektion(population);
                default:
                    return natur.turnierSelektion(turnierTeilnhemer, population);
            }
        }

        /// <summary>
        /// es wähle 2 Eltern von Population, die erste ist ganz Random, die Zweite hängt von
        /// Selektion Methode
        /// </summary>
        /// <returns>Array mit die positionen von die Eltern in Population Liste</returns>
        public int[] selektionRekombination()
        {

            return new int[] { natur.randomPosPopulation(population.Count), selektionInterface() };//turnier
        }














        //------------------------------------------------------------------------------------------
        //i pos in population, welche sudoku will ich andern
       /*
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

      /*  public void teilMutationSwapNueKind(int i)
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
        */
    }
}

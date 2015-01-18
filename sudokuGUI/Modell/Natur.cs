using System;
using System.Collections.Generic;

namespace Modell
{
    /// <summary>
    /// Class mit Haupt Methoden für Mutation, Crossover und Selektion
    /// </summary>
    class Natur
    {
        private const int GROESS = 9;

        /// <summary>
        /// Matrix mit der Eingabe, es benutzt wird, um zu wissen, welche werte feste sind
        /// </summary>
        public String[] matFest;
        Random rand;
        /// <summary>
        /// Fitness total der Population, für Glückradswahl Selektion
        /// </summary>
        public int populationTotalFitnes;

        public Natur()
        {
            rand = new Random();
            matFest = new String[GROESS];
        }


        /// <summary>
        /// Es rechnet die Total Fitnes eine Population
        /// </summary>
        /// <param name="population">Liste von sudokus</param>
        public void populationTotalFitnessRechnen(List<Sudoku> population)
        { 
            populationTotalFitnes = 0;
            foreach (Sudoku su in population)
                populationTotalFitnes += su.fitness;
        }

        /// <summary>
        /// Für jedes Sudoku in eine Liste rechnet es den Sektor Gröss
        /// </summary>
        /// <param name="population">Liste von sudoku</param>
        public void gluckRadSektorGrossRechnen(List<Sudoku> population)
        {
            population[0].gluckRadSektorGross = (double)population[0].fitness / populationTotalFitnes;
             

            for (int i = 1; i < population.Count; i++)
                population[i].gluckRadSektorGross = ((double)population[i].fitness / populationTotalFitnes) + population[i - 1].gluckRadSektorGross;

            population[population.Count - 1].gluckRadSektorGross = 1; //besser wegen float can sein 0,999999999 statt 1, und rand can 1 sein
        }

        /// <summary>
        /// Es wählt ein Individuum mit der Glückradswahl Methode
        /// </summary>
        /// <param name="population">Liste von sudokus</param>
        /// <returns>Index in Liste</returns>
        public int RouletteSelektion(List<Sudoku> population)
        {
            populationTotalFitnessRechnen(population);
            gluckRadSektorGrossRechnen(population);

            float r = (float)rand.NextDouble();

            int i = 0;
            while (population[i].gluckRadSektorGross < r) i++;

            return i;
        }

        //deterministic, wenn ich will probabilistic, replace mit <
        /// <summary>
        /// Deterministische turnier Selektion
        /// </summary>
        /// <param name="nummerTeilnehmer">Anzahl Teilnehmer in Turnier</param>
        /// <param name="population">Liste von sudokus</param>
        /// <returns>Index in Liste</returns>
        public int turnierSelektion(int nummerTeilnehmer, List<Sudoku> population)
        {                
            int beste = randomPosPopulation(population.Count);
            int i = 1;
            while(i < nummerTeilnehmer)
            {
                int neu = randomPosPopulation(population.Count);
                if (population[neu].fitness > population[beste].fitness)
                    beste = neu;

                i++;
            }

            return beste;
        }

        /// <summary>
        /// Gebt ein random Position in eine population, zwischen ein Rang
        /// </summary>
        /// <param name="elite">Untere Grenze</param>
        /// <param name="grossPopulation">Gross Liste sudokus</param>
        /// <returns>Random Index</returns>
        public int randomPosLoeschenElite(int elite, int grossPopulation)
        {
            return rand.Next(elite, grossPopulation - 1);
        }

        /// <summary>
        /// Gebt ein random Position in Eine Population
        /// </summary>
        /// <param name="grossPopulation">Gross Liste sudokus</param>
        /// <returns></returns>
        public int randomPosPopulation(int grossPopulation)
        {
            return rand.Next(0, grossPopulation - 1);
        }

        /// <summary>
        /// Gebt ein Random Wert
        /// </summary>
        /// <param name="gering">Untere Grenze</param>
        /// <param name="hoch">Obere Grenze</param>
        /// <returns>Random Zahl</returns>
        public int randomZahl(int gering, int hoch)
        {
            return rand.Next(gering, hoch);
        }

        
        /// <summary>
        /// Round robin für die Positionen in den Chromosomen
        /// </summary>
        /// <param name="p">Aktuelle Position</param>
        /// <returns></returns>
        public int nachstePos(int p)
        {
            if (p == 8)
                return 0;
            else
                return ++p;//ich hatte einen Fehler, es muss ++p sein, p++ erst gebt das Resultat und dann erhoht p
        }


        /// <summary>
        /// Es fuellt ein chromosom nach dem Zufallsprinzip mit alle die andere Zahlen, damit es alle Zahle 
        /// von 1 bis 9 hat
        /// </summary>
        /// <param name="cr">Zeile eines Sudokus mit Leere Positionen in 0</param>
        /// <returns>Neue Zeile mit den 9 Werte</returns>
        public String fuellenChromosomRand(String cr)
        {
            int[] booleans = new int[9];
            char[] temp = cr.ToCharArray();
            //bool in position von zahl, die wir schon haben
            for (int i = 0; i < cr.Length; i++)
            {
                if (cr[i] != '0')
                    booleans[(cr[i]-48) - 1] = 1;
            }


            for (int i = 0; i < booleans.Length; i++)
            {
                if (booleans[i] != 1)//wenn wir diese nummer noch nicht haben
                {
                    int pos = rand.Next(0,8);//geben sie mir ein rand position

                    while (temp[pos] != '0')
                        pos = nachstePos(pos);

                    temp[pos] = (char)(i + 1 + 48);
                    booleans[i] = 1;
                }
            }
            return new String(temp);
        }

        //es muss mindestens 2 lehre Plátze geben, sonst müsste Evolution diesen Vorgang nicht benutzen
        /// <summary>
        /// swap 2 Random nicht Feste Werte
        /// </summary>
        /// <param name="i">Position Zeile (um in Feste Matrix zu sehen)</param>
        /// <param name="cr">Aktuelle Zeile</param>
        /// <returns>Neue Zeile</returns>
        public String mutationSwap(int i, String cr)
        {
            char[] temp = cr.ToCharArray();

            int pos = rand.Next(0, 8);//geben sie mir ein rand position
            int pos2 = rand.Next(0, 8);

            while (matFest[i][pos] != '0' || pos2 == pos)
                pos = nachstePos(pos);
            while (matFest[i][pos2] != '0' || pos2 == pos)
                pos2 = nachstePos(pos2);

            char swap = temp[pos];
            temp[pos] = temp[pos2];
            temp[pos2] = swap;
            

            return new String(temp);
        }

        /// <summary>
        /// sucht ob ein Spalte hat ein Wert als Feste
        /// </summary>
        /// <param name="sau">Index Spalte in Sudoku</param>
        /// <param name="nummer">Werte</param>
        /// <returns>False wenn es schon ist, True wenn es ist</returns>
        public Boolean istSchonInSaule(int sau, char nummer)
        {
            for (int i = 0; i < 9; i++)
                if (matFest[i][sau] == nummer) return true;

                return false;
        }

        /// <summary>
        /// swap 2 nicht Feste Werte, aber in den nuen Positionen, die Spalte 
        /// muss nicht diese wert als Feste haben (istSchonInSaule = false)
        /// </summary>
        /// <param name="i">Index Spalte</param>
        /// <param name="cr">Aktuelle Zeile</param>
        /// <param name="fitnessSaule">Fitness Spalte</param>
        /// <returns>Neue Zeile</returns>
        public String mutationSwapMitEinschrankung(int i, String cr, int[] fitnessSaule)//mach kein swap, wenn in Ziel schon diese Nummer ist
        {
            char[] temp = cr.ToCharArray();

            int pos = rand.Next(0, 8);//geben sie mir ein rand position
            int pos2 = rand.Next(0, 8);

            while (matFest[i][pos] != '0' || pos2 == pos)// || fitnessSaule[pos] == 9)
                pos = nachstePos(pos);

            int flag = 0;
            while (matFest[i][pos2] != '0' || pos2 == pos || istSchonInSaule(pos2, temp[pos]))
            {
                if (flag >= 9) return cr;

                if (istSchonInSaule(pos2, temp[pos])) 
                    Console.WriteLine();
                pos2 = nachstePos(pos2);
                flag++;
            }

            char swap = temp[pos];
            temp[pos] = temp[pos2];
            temp[pos2] = swap;


            return new String(temp);
        }

        /// <summary>
        /// macht swap zwischen 2 Spalte mit weniger als 9 fitness
        /// </summary>
        /// <param name="cr">Aktuelle Zeile</param>
        /// <param name="pos">Index 1 wo Spalte fitness kleiner als 9</param>
        /// <param name="pos2">Index 2 wo Spalte fitness kleiner als 9</param>
        /// <returns>Neue Zeile</returns>
        public String mutationSwapOhneNeunFitness(String cr, int pos, int pos2)
        {
            
            char[] temp = cr.ToCharArray();

            char swap = temp[pos];
            temp[pos] = temp[pos2];
            temp[pos2] = swap;


            return new String(temp);
        }

        /// <summary>
        /// uniform Crossover
        /// </summary>
        /// <param name="a">Eltern 1</param>
        /// <param name="b">Eltern 2</param>
        /// <returns>Neue Sudokus, kinder</returns>
        public Sudoku[] rekombination2(Sudoku a, Sudoku b)
        {
            Sudoku kindA = new Sudoku(), kindB = new Sudoku();
            int[] punkts = new int[9];

            for (int i = 0; i < 9; i++)
                punkts[i] = (int)(rand.Next(2));

            for (int i = 0; i < 9; i++)
            {
                if (punkts[i] == 0)
                {
                    kindA.setChromStr(i, a.sudokuStr[i]);
                    kindB.setChromStr(i, b.sudokuStr[i]);
                }
                else
                {
                    kindA.setChromStr(i, b.sudokuStr[i]);
                    kindB.setChromStr(i, a.sudokuStr[i]);
                }
            }

            return new Sudoku[] { kindA, kindB };

        }

        /// <summary>
        /// 1-Punkt Crossover
        /// </summary>
        /// <param name="a">Eltern 1</param>
        /// <param name="b">Eltern 2</param>
        /// <returns>Neue Sudokus, kinder</returns>
        public Sudoku[] rekombination1(Sudoku a, Sudoku b)
        {
            Sudoku kindA = new Sudoku(), kindB = new Sudoku();

            int punkt = rand.Next(1,7);//ich will kein 0 oder 8, dass wäre nutzlos

            for (int i = 0; i < punkt; i++)
            {
                kindA.setChromStr(i, a.sudokuStr[i]);
                kindB.setChromStr(i, b.sudokuStr[i]);
            }
            for (int i = punkt; i < GROESS; i++)
            {
                kindA.setChromStr(i, b.sudokuStr[i]);
                kindB.setChromStr(i, a.sudokuStr[i]);
            }

           /* Console.WriteLine(a.sudToString());
            Console.WriteLine(b.sudToString());
            Console.WriteLine(kindA.sudToString());
            Console.WriteLine(kindB.sudToString());*/

            return new Sudoku[] { kindA, kindB };

        }


        //---------------------------------------------------------------------------------------
        //alle diese vorgange waren für die Stratagie mit Liste von array, ausgeschlossen!!!
        /*public int[] randomVariationVector()
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
                if(matFest[j][i] == 0)
                    a[i] = rand.Next(1,9);
            }
            return a;
        }

        public void mutationRandom2(int[] a, int j)
        {
            int pos = rand.Next(0, 8);

            if (matFest[j][pos] == 0)
                a[pos] = rand.Next(1, 9);
        }

        public int[] mutation(int[] a, int[] b)
        {
            for (int i = 0; i < 9; i++)
            {
                a[i] += b[i];
            }
            return a;
        }*/
    }
}

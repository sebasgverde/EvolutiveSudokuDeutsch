using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudokuGUI
{
    class Natur
    {
        private const int GROESS = 9;

        public String[] matFest;
        Random rand;

        public Natur()
        {
            rand = new Random();
            matFest = new String[GROESS];
        }

        //Round robin für die Positionen in den Chromosomen
        public int nachstePos(int p)
        {
            if (p == 8)
                return 0;
            else
                return ++p;//ich hatte einen Fehler, es muss ++p sein, p++ erst gebt das Resultat und dann erhoht p
        }

        /*es fuellt ein chromosom nach dem Zufallsprinzip mit alle die andere Zahlen, damit es alle Zhale 
         * von 1 bis 9 hat*/
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

        //es muss mindestens 2 lehre Plátze geben, sonst müstte Evolution diesen Vorgang nicht benutzen
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



        //---------------------------------------------------------------------------------------
        //alle diese vorgange waren für die Stratagie mit Liste von array, ausgeschlossen!!!
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
        }
    }
}

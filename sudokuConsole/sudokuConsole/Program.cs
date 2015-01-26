using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modell;

namespace sudokuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Sudoku sud = new Sudoku();
            sud.test();*/

            String sud = "080301004\r\n530674800\r\n006080700\r\n190832400\r\n003067095\r\n067000300\r\n008013040\r\n300506900\r\n674098031";
            Modell.Evolution evo = new Evolution(sud);

            evo.start();
            Console.Write(evo.getBesteSudPop().Replace("\n", "\r\n"));            
            Console.ReadLine();
            Console.Write(evo.weiterGehenBisEnde().Replace("\n", "\r\n"));
            Console.ReadLine();
        }
    }
}

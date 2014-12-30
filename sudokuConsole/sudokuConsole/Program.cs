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

            String sud = "701002600\r\n200000795\r\n050004201\r\n045013000\r\n900408003\r\n000270460\r\n409800010\r\n173000008\r\n002300906";
            Modell.Evolution evo = new Evolution(sud);
        }
    }
}

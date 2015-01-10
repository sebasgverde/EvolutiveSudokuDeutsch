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

            String sud = "000007040\r\n086450700\r\n370800152\r\n807190230\r\n509082670\r\n003746500\r\n052900008\r\n700600305\r\n430028060";
            Modell.Evolution evo = new Evolution(sud);
        }
    }
}

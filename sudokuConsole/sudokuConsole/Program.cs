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

            String sud = "200406500\r\n003108700\r\n600009438\r\n500040300\r\n000371000\r\n008090004\r\n931200007\r\n004307200\r\n002905003";
            Modell.Evolution evo = new Evolution(sud);
        }
    }
}

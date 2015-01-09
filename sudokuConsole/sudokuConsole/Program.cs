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

            String sud = "030000000\r\n000195000\r\n008000060\r\n800060000\r\n400800001\r\n000020000\r\n060000280\r\n000419005\r\n000000070";
            Modell.Evolution evo = new Evolution(sud);
        }
    }
}

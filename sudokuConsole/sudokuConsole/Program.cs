using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sudokuGUI;

namespace sudokuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Sudoku sud = new Sudoku();
            sud.test();*/

            String sud = "100007000\r\n001000000\r\n000000300\r\n000000000\r\n000400000\r\n000000000\r\n000000000\r\n000000000\r\n007000000";
            sudokuGUI.Evolution evo = new Evolution(sud);
        }
    }
}

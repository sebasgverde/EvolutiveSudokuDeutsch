using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Modell;

namespace sudokuGUI
{
    public partial class Form1 : Form
    {
        public Evolution evo;
        public Form1()
        {
            InitializeComponent();
        }

        private void RechnenBtn_Click(object sender, EventArgs e)
        {
            String sud = sudtxt.Text;
            evo = new Evolution(sud, Convert.ToInt32(popSizTxt.Text), Convert.ToInt32(eliteTxt.Text), Convert.ToInt32(maxGenTxt.Text), Convert.ToInt32(maxPopTxt.Text), Convert.ToInt32(mutChanTxt.Text), Convert.ToInt32(crroChanTxt.Text),mutMethodCB.SelectedIndex, Convert.ToInt32(mutRadTxt.Text), crossMetCB.SelectedIndex);
            resultTxt.Text = evo.run().Replace("\n", "\r\n");
            //evo.run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* evo.restart(0);
            resultTxt.Text = evo.run().Replace("\n", "\r\n");*/
            textBox1.Text=evo.printPopulation().Replace("\n", "\r\n");
        }
    }
}

using System;
using GameOfLife.Grids;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    class Program {
        static void Main(string[] args) {
            




            GUI gui = new GUI(Glider.MakeGrid());
            while (true) {
                gui.ShowStep();
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

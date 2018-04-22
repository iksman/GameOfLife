using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    class GUI {
        Logic logic;
        int generation;
        public GUI(Grid grid) {
            logic = new Logic(grid);
            generation = 0;
        }
        public void ShowStep() {
            Grid grid = logic.runStep();
            Console.WriteLine("+---------Generation: " + generation.ToString());
            foreach (KeyValuePair<int, Dictionary<int,Node>> row in grid.getNodes()) {
                
                foreach (KeyValuePair<int, Node> point in row.Value) {
                    Node node = point.Value;
                    if (node.dead == true) {
                        Console.Write(". ");
                    } else {
                        Console.Write("XX");
                    }
                }
                Console.Write("\n");
            }
            generation++;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    class Logic {
        Grid grid;
        bool initialStep = true;
        public Logic(Grid grid) {
            this.grid = grid;
        }

        public Grid runStep() {
            if (initialStep == false) {
                List<Tuple<int, int, bool>> results = new List<Tuple<int, int, bool>>();
                for (int y = 0; y < grid.dimensions.Item2; y++) {
                    
                    for (int x = 0; x < grid.dimensions.Item1; x++) {

                        bool result = getAlive(x, y);
                        results.Add(new Tuple<int,int,bool>(x,y,result));
                    }
                    
                }
                foreach (Tuple<int, int, bool> result in results) {
                    grid.setStatus(result.Item1, result.Item2, result.Item3);
                }
            } else {
                initialStep = false;
            }
            return this.grid;
        }

        public Grid getCurrentGrid() {
            return this.grid;
        }

        public bool getAlive(int x, int y) {
            int neighborCount = 0;
            List<Node> nodes = grid.fold();
            bool isDead = true;
            foreach (Node node in nodes) {
                if (node.dead == false) { 
                    if (node.x == x && node.y == y) {
                        isDead = false;
                    }
                    else if (node.x >= (x -1) && node.x <= (x + 1)) {
                        if (node.y >= (y - 1) && node.y <= (y + 1)) {
                            neighborCount++;
                        }
                    }
                }
            }

            if (isDead) {
                if (neighborCount == 3) {
                    return false;
                }
            } else {
                if (neighborCount == 2 || neighborCount == 3) {
                    return false;
                }
            }
            return true;            
        }
    }
}

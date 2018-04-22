using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    class Grid {
        private Dictionary<int,Dictionary<int,Node>> nodes;
        public Tuple<int,int> dimensions { get; private set;}

        public Grid(Tuple<int,int> dimensions) {
            nodes = new Dictionary<int, Dictionary<int, Node>>();
            this.dimensions = dimensions;
        }
        public void generateGrid() {
            for (int y = 0; y < dimensions.Item2; y++) {
                Dictionary<int, Node> row = new Dictionary<int, Node>();
                for (int x = 0; x < dimensions.Item1; x++) {
                    row.Add(x, new Node(x,y,true));
                }
                nodes.Add(y,row);
            }
        }
        public Dictionary<int,Dictionary<int,Node>> getNodes() {
            return nodes;
        }
        public void setStatus(int x, int y, bool dead=false) {
            try {
                nodes[y][x].dead = dead;
            } catch {
                throw new IndexOutOfRangeException();
            }
        }
        public bool getStatus(int x, int y, bool dead) {
            try {
                return nodes[y][x].dead;
            } catch {
                return true;
            }
        }
        public List<Node> fold() {
            List<Node> result = new List<Node>();
            foreach (KeyValuePair<int, Dictionary<int, Node>> row in this.nodes) {
                foreach (KeyValuePair<int, Node> point in row.Value) {
                    result.Add(point.Value);
                }
            }
            return result;
        }
    }

    class Node { 
        public int x {get; private set; }
        public int y { get; private set; }
        public bool dead {get; set; }
        public Node(int x, int y, bool dead) {
            this.x = x;
            this.y = y;
            this.dead = dead;
        }    
    }
}

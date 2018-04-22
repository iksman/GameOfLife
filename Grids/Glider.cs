using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Grids {
    class Glider{
        public static Grid MakeGrid() {
            Grid grid = new Grid(new Tuple<int, int>(40,25));
            grid.generateGrid();

            grid.setStatus(6, 0);
            grid.setStatus(7, 1);
            grid.setStatus(5, 2);
            grid.setStatus(6, 2);
            grid.setStatus(7, 2);

            grid.setStatus(19, 13);
            grid.setStatus(19, 14);
            grid.setStatus(19, 15);
            grid.setStatus(20, 13);
            grid.setStatus(21, 14);

            return grid;
        }
    }
}

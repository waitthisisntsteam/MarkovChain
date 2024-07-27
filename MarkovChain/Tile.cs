using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovChain
{
    public class Tile
    {
        public Point Location;
        public string TileType;

        public Tile(Point location, string tileType) 
        {
            Location = location;
            TileType = tileType;
        }
    }
}

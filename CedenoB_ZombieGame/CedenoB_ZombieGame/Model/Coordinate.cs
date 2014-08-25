using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate()
        {

        }
    }
}

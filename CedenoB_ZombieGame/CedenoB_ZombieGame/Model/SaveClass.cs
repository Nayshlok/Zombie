using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
    public class SaveClass
    {
        public SaveableSquare[,] GameGrid { get; set; }

        public SaveClass() {}
        public SaveClass(SaveableSquare[,] grid)
        {
            this.GameGrid = grid;
        }

    }
}

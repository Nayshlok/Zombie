using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class HealthPot
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public HealthPot()
        {

        }
    }
}

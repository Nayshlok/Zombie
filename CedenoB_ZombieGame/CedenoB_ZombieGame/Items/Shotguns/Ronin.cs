using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    class Ronin : RangedWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Ronin()
        {
            this.Multiplier = 2;
            this.Bursts = 3;
            base.baseDamage = new Dice(4, 6);
            this.Name = "Ronin";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

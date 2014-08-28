using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Special : RangedWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Special()
        {
            this.Multiplier = 2;
            this.Bursts = 3;
            base.baseDamage = new Dice(5, 6);
            this.Name = "Special";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

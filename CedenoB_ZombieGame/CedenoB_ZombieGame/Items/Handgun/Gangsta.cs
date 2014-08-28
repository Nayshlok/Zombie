using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Gangsta : RangedWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Gangsta()
        {
            this.Multiplier = 2;
            this.Bursts = 3;
            weaponType = RangedType.Handgun;
            base.baseDamage = new Dice(3, 6);
            this.Name = "Gangsta";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

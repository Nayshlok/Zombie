using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Farmer : RangedWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Farmer()
        {
            this.Name = "Farmer";
            base.baseDamage = new Dice(4, 6);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

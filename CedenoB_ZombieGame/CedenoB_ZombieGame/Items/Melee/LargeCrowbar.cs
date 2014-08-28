using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class LargeCrowbar : MeleeWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public LargeCrowbar()
        {
            this.Name = "Large Crowbar";
            base.baseDamage = new Dice(2, 8);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

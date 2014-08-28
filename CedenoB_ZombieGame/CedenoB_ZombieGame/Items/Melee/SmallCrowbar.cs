using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace zombieApocalypse.Model.Melee
{
    [Serializable()]
    class SmallCrowbar : MeleeWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public SmallCrowbar()
        {
            this.Name = "Small Crowbar";
            base.baseDamage = new Dice(2, 6);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

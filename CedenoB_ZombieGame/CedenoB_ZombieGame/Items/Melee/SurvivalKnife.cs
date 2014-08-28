using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace zombieApocalypse.Model.Melee
{
    [Serializable()]
    class SurvivalKnife : MeleeWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public SurvivalKnife()
        {
            base.baseDamage = new Dice(1, 6);
            this.Name = "Survial Knife";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

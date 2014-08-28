using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Sport : RangedWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Sport()
        {
            weaponType = RangedType.Handgun;
            base.baseDamage = new Dice(2, 4);
            this.Name = "Sport";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

using CedenoB_ZombieGame.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Sniper : Rifle
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Sniper()
        {
            this.BonusDamage = 10;
            this.Bursts = 4;
            base.baseDamage = new Dice(6, 6);
            weaponType = RangedType.Rifle;
            ignoreAR = true;
            this.Name = "Sniper";

        }
        public override string ToString()
        {
            return Name;
        }
    }
}

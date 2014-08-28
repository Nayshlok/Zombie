using CedenoB_ZombieGame.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Desert : Rifle
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public Desert()
        {
            this.Multiplier = 2;
            this.Bursts = 3;
            base.baseDamage = new Dice(4, 6);
            this.Name = "Desert";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

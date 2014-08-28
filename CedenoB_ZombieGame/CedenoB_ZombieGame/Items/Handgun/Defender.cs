using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Item
{
    [Serializable()]
    public class Defender : MeleeWeapon
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }
        public Defender()
        {
            this.Name = "Defender";
            base.baseDamage = new Dice(4, 6);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

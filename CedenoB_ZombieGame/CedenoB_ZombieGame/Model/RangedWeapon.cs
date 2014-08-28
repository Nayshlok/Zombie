using CedenoB_ZombieGame.Item.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    public enum RangedType
    {
        Handgun, Rifle, Shotgun
    }

    [Serializable()]
    public class RangedWeapon : Weapon
    {
        public RangedType weaponType { get; set; }

        //
        public AmmoType Ammo { get; set; }
        public int Multiplier { get; set; }
        public int Bursts { get; set; }
        //
        public RangedWeapon()
        {
            Multiplier = 1;
            Bursts = 1;
        }

    }
}

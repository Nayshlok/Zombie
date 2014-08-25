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
    }
}

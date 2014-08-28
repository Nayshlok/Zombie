using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace CedenoB_ZombieGame.Items.Ammo
{
    public abstract class Handgun : RangedWeapon
    {
        public Handgun()
        {
            this.Ammo = CedenoB_ZombieGame.Item.Ammo.AmmoType.Handgun;
            this.Name = "Handgun";
        }
        public override string ToString()
        {
            return Name;
        }
    }

}

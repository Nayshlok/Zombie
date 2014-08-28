using CedenoB_ZombieGame.Item.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Item.Item.Model
{

    public class HandgunAmmo : GunAmmo
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public HandgunAmmo()
        {
            this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Handgun;
            this.Name = "Handgun Ammo";
        }
        public override string ToString()
        {
            return Name;
        }

    }
}

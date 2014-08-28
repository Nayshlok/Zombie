using CedenoB_ZombieGame.Item.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Item.Model
{
    public class ShotgunAmmo : GunAmmo
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public ShotgunAmmo()
        {
            this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Shotgun;
            this.Name = "Shotgun Ammo";
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

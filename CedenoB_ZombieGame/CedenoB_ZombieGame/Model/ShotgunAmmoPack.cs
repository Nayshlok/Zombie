using CedenoB_ZombieGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedenoB_ZombieGame.Model
{
    public class ShotgunAmmoPack : AmmoPack
    {

        public ShotgunAmmoPack()
        {
            this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Shotgun;
            this.Name = "Shotgun Ammo Pack";
        }

        public ShotgunAmmoPack(int amount)
        {
            this.Qty = amount;
        }
    }
}

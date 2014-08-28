using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Items.Rifles
{
    public class RifleAmmoPack : AmmoPack
    {
        public RifleAmmoPack()
        {
            this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Rifle;
            this.Name = "Rifle Ammo Pack";
        }

        public RifleAmmoPack(int amount)
        {
            this.Qty = amount;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
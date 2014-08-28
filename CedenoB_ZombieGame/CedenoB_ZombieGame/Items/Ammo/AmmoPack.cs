using CedenoB_ZombieGame.Item.Items.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Items
{
    public abstract class AmmoPack : GunAmmo
    {
        public AmmoPack()
        {
            Random rand = new Random();
            this.Qty = (rand.Next(12, 50));
            this.Name = "AmmoPack";
        }

        public AmmoPack(int qty)
        {
            this.Qty = qty;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Items.Handguns
{
    public class HandgunAmmoPack : AmmoPack
    {

        public HandgunAmmoPack()
        {
            this.Name = "Handgun Ammo Pack";
            this.Type = CedenoB_ZombieGame.Item.Ammo.AmmoType.Handgun;
        }

        public HandgunAmmoPack(int amount)
        {
            this.Qty = amount;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

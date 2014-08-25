using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    [Serializable()]
    class SmallCrowbar : MeleeWeapon
    {
        public SmallCrowbar()
        {
            base.baseDamage = new Dice(2, 6);
        }
    }
}

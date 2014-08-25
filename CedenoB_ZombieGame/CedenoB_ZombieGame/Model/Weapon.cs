using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Model
{
    [Serializable()]
    public class Weapon
    {
        public Dice baseDamage { get; set; }
        public int BonusDamage { get; set; }
        public bool ignoreAR { get; set; }
    }
}

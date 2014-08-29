using CedenoB_ZombieGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CedenoB_ZombieGame.Items.Others
{
    class Shield : Defensive
    {
        public int bonusToAR { get; set; }

        public Shield()
        {
            this.bonusToAR = 4;

        }
    }
}

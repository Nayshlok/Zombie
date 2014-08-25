using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zombieApocalypse.Combat
{
    class CombatResults
    {
        public int AttackRoll { get; set; }
        public Defense DefenseType { get; set; }
        public int DefendRoll { get; set; }
        public int Damage { get; set; }
        public string Message { get; set; }
        public bool Allies { get; set; }
        public bool AttackCrit { get; set; }
        public bool AttackFail { get; set; }
        public bool DefendCrit { get; set; }
        public bool DefendFail { get; set; }
        public bool AttackHit { get; set; }

        public CombatResults()
        {
            DefenseType = Defense.None;
        }
    }
}

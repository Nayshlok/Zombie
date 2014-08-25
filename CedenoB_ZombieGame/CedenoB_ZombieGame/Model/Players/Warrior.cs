using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    class Warrior:Player
    {
        public Warrior(string name):base(name)
        {
            PlayerClass = ClassPlayer.Warrior;
            AR += 2;
            Parry += 2;
        }
    }
}

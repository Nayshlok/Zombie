using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Survivalist:Player
    {
         public Survivalist(string name):base(name)
        {
            PlayerClass = ClassPlayer.Survivalist;
            Dodge += 2;
        }
    }
}

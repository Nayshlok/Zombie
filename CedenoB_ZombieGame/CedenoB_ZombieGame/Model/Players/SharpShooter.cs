using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class SharpShooter:Player
    {
         public SharpShooter(string name):base(name)
        {
            PlayerClass = ClassPlayer.Sharp_Shooter;
            AR -= 2;
        }
    }
}

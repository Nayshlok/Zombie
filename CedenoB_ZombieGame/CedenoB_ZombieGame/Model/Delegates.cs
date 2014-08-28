using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator;
using ZombieApocalypseSimulator.Model;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
    public class Delegates
    {
        public delegate void SelectCharacter(Character character, int firstX, int firstY);
    }
}

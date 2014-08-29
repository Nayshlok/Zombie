using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    class Warrior:Player
    {
        public Warrior(string name):base(name, new BitmapImage(new Uri("Images/War.png", UriKind.Relative)))
        {
            PlayerClass = ClassPlayer.Warrior;
            AR += 2;
            Parry += 2;
        }
    }
}

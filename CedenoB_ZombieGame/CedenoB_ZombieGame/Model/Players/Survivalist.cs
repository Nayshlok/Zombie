using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Survivalist:Player
    {
         public Survivalist(string name):base(name, new BitmapImage(new Uri("Images/Survivalist.jpg", UriKind.Relative)))
        {
            PlayerClass = ClassPlayer.Survivalist;
            Dodge += 2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class SharpShooter:Player
    {
         public SharpShooter(string name):base(name, new BitmapImage(new Uri("Images/SharpShooter.png", UriKind.Relative)))
        {
            PlayerClass = ClassPlayer.Sharp_Shooter;
            AR -= 2;
        }
    }
}

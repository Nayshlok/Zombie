using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using zombieApocalypse.Model;


namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Tank:Zed
    {
        public Tank(string name)
            : base(name, new BitmapImage(new Uri("Images/Tank.png", UriKind.Relative)))
        {
            ZedClass = ClassZed.Tank;
            Strike += 2;
            Parry += 2;
            Dodge += 1;
            PS = DummyDice(45, min: 30);
            PP = DummyDice(7, min: 2);
            PE = DummyDice(21, min: 16);
            SPD = DummyDice(10, min: 7);
            BaseDamage = new Dice(3, 6);
            SDC = DummyDice(80, min: 60);
            HP = DummyDice(50, min: 35);
            MoneyValue = DummyDice(20, min: 10);

            getItem();
        }
    }
}

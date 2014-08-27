using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Spitter:Zed
    {
        public Spitter(string name):base(name)
        {
            ZedClass = ClassZed.Spitter;
            Strike += 3;
            Parry -= 1;
            Dodge -= 1;
            PS = DummyDice(8, min: 5);
            PP = DummyDice(29, min: 19);
            PE = DummyDice(11, min: 7);
            SPD = DummyDice(8, min: 4);
            BaseDamage = new Dice(4, 6); ;
            SCD = DummyDice(15, min: 10);
            HP = DummyDice(20, min: 15);
            MoneyValue = DummyDice(15, min: 5);

            getItem();
        }
    }
}

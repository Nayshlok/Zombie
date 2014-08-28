using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class FastAttack:Zed
    {
        public FastAttack(string name):base(name)
        {
            ZedClass = ClassZed.Fast_Attack;
            Strike += 2;
            Parry += 2;
            Dodge += 2;
            PS = DummyDice(24, min: 19);
            PP = DummyDice(13, min: 8);
            PE = DummyDice(21, min: 16);
            SPD = DummyDice(23, min: 17);
            BaseDamage = new Dice(1, 6);
            BonusDamage = 3;
            SDC = DummyDice(48, min: 33);
            HP = DummyDice(21, min: 16);
            MoneyValue = DummyDice(15, min: 5);

            getItem()
        }
    }
}

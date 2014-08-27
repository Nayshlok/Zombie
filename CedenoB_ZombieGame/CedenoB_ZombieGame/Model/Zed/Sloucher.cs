using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Sloucher:Zed
    {
        public Sloucher(string name):
            base(name)
        {
            base.ZedClass = ClassZed.Sloucher;
            base.Strike += 2;
            base.PS = base.DummyDice(30, min: 20);
            base.PP = base.DummyDice(7, min: 2);
            base.PE = base.DummyDice(21, min: 16);
            base.SPD = base.DummyDice(10, min: 7);
            base.BaseDamage = new Dice(1, 6);
            base.SDC = base.DummyDice(48, min: 33);
            base.HP = base.DummyDice(21, min: 16);
            base.MoneyValue = base.DummyDice(10, min: 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    public enum ClassZed
    {
        Sloucher,
        Fast_Attack,
        Tank,
        Shank,
        Spitter
    }

    [Serializable()]
    public class Zed:Character
    {
        private Random rand= new Random();

        private ClassZed _ZedClass;
        public ClassZed ZedClass
        {
            get { return _ZedClass; }
            set { _ZedClass = value; }
        }

        private Dice _BaseDamage;
        public Dice BaseDamage
        {
            get { return _BaseDamage; }
            set { _BaseDamage = value; }
        }

        private int _BonusDamage;
        public int BonusDamage
        {
            get { return _BonusDamage; }
            set { _BonusDamage = value; }
        }

        private Item _DropItem;
        public Item DropItem
        {
            get { return _DropItem; }
            set { _DropItem = value; }
        }

        private int _MoneyValue;
        public int MoneyValue
        {
            get { return _MoneyValue; }
            set { _MoneyValue = value; }
        }
        
        public Zed(string name):base(name)
        {
            base.IQ = 0;
            base.MA = 0;
            base.ME = 0;
        }
    }
}

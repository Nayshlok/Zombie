using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using zombieApocalypse.Model;
using ZombieApocalypseSimulator.Model;

namespace ZombieApocalypseSimulator
{
    public enum ClassPlayer
    {
        Warrior,
        Sharp_Shooter,
        Survivalist
    }

    [Serializable()]
    public class Player:Character
    {
        private ClassPlayer _PlayerClass;
        public ClassPlayer PlayerClass
        {
            get { return _PlayerClass; }
            set { _PlayerClass = value; }
        }

        //private Inventory _Inventory;
        //public Inventory Inventory
        //{
        //    get { return _Inventory; }
        //    set { _Inventory = value; }
        //}
        private int _ZombifyChance;
        public int ZombifyChance
        {
            get { return _ZombifyChance; }
            set { _ZombifyChance = value; }
        }

        private int _Money;
        public int Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        public Player(string name, BitmapImage image):base(name, image)
        {
            this.Inventory = new Inventory();
            this.Inventory.equippedWeapon = new SmallCrowbar();
        }

        public int bonusToHit()
        {
            int bonus = 0;

            if (this is Warrior && Inventory.equippedWeapon is MeleeWeapon)
            {
                bonus = 1;
            }
            if (this is Warrior && Inventory.equippedWeapon is RangedWeapon)
            {
                bonus = -3;
            }
            if (this is SharpShooter)
            {
                if (Inventory.equippedWeapon is RangedWeapon)
                {
                    if (((RangedWeapon)Inventory.equippedWeapon).weaponType == RangedType.Rifle)
                    {
                        bonus = 2;
                    }
                    else if (((RangedWeapon)Inventory.equippedWeapon).weaponType == RangedType.Handgun)
                    {
                        bonus = 1;
                    }
                }
                else
                {
                    bonus = -3;
                }
            }
            if (this is Survivalist)
            {
                if (Inventory.equippedWeapon is SurvivalKnife || Inventory.equippedWeapon is SmallCrowbar)
                {
                    bonus = 2;
                }
                else if (Inventory.equippedWeapon is RangedWeapon)
                {
                    RangedWeapon tempWeapon = (RangedWeapon)Inventory.equippedWeapon;
                    if (tempWeapon.weaponType == RangedType.Shotgun)
                    {
                        bonus = 2;
                    }
                }
            }

            return bonus;
        }

        private PlayerItem _ItemAt;
        public PlayerItem ItemAt
        {
            get
            {
                return _ItemAt;
            }
            set
            {
                _ItemAt = value;
            }
        }

        public void setItemAt(int i)
        {
            ItemAt = Inventory.itemList.ElementAt(i);
        }

        public void killItemAt(int i)
        {
            Inventory.itemList.RemoveAt(i);
        }
    }
}

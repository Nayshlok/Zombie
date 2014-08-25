using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

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

        private Inventory _Inventory;
        public Inventory inventory
        {
            get { return _Inventory; }
            set { _Inventory = value; }
        }
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

        public Player(string name):base(name)
        {
            inventory = new Inventory();
            inventory.equippedWeapon = new SmallCrowbar();
        }

        public int bonusToHit()
        {
            int bonus = 0;

            if (this is Warrior && inventory.equippedWeapon is MeleeWeapon)
            {
                bonus = 1;
            }
            if (this is Warrior && inventory.equippedWeapon is RangedWeapon)
            {
                bonus = -3;
            }
            if (this is SharpShooter)
            {
                if (inventory.equippedWeapon is RangedWeapon)
                {
                    if (((RangedWeapon)inventory.equippedWeapon).weaponType == RangedType.Rifle)
                    {
                        bonus = 2;
                    }
                    else if (((RangedWeapon)inventory.equippedWeapon).weaponType == RangedType.Handgun)
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
                if (inventory.equippedWeapon is SurvivalKnife || inventory.equippedWeapon is SmallCrowbar)
                {
                    bonus = 2;
                }
                else if (inventory.equippedWeapon is RangedWeapon)
                {
                    RangedWeapon tempWeapon = (RangedWeapon)inventory.equippedWeapon;
                    if (tempWeapon.weaponType == RangedType.Shotgun)
                    {
                        bonus = 2;
                    }
                }
            }

            return bonus;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CedenoB_ZombieGame.Items.Others;
using zombieApocalypse.Model;
using zombieApocalypse.Model.Melee;
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
        //BRYAN CODE START
        public Random rand = new Random();
        private int turnsDead { get; set; }
        public int baseAR { get; set; }
        public void addToInventory(PlayerItem item)
        {
            Inventory.addToInv(item);
        }
        public void removeFromInventory(PlayerItem item)
        {
            Inventory.remove(item);
        }

        public bool isZombie { get; set; }
        public Zed Zombify()
        {


            if (this.IsLiving == false)
            {
                this.ZombifyChance = 5 * turnsDead; //Original 5*turnsDead;
                int random = rand.Next(0, 100);
                //Chance to become Zombie
                if (random <= this.ZombifyChance)
                {
                    Zed returned;
                    this.isZombie = true;
                    random = rand.Next(0, 102);
                    //Zombie Type radomness
                    if (random >= 0 && random <= 39)
                    {
                        returned = new Sloucher(this.Name);
                    }
                    else if (random >= 40 && random <= 59)
                    {
                        returned = new FastAttack(this.Name);
                    }
                    else if (random >= 60 && random <= 79)
                    {
                        returned = new Spitter(this.Name);
                    }
                    else if (random >= 80 && random <= 89)
                    {
                        returned = new Shank(this.Name);
                    }
                    else if (random >= 90 && random <= 99)
                    {
                        returned = new Tank(this.Name);
                    }
                    //This else is here to handle any randomization that my go wrong.
                    else
                    {
                        returned = new Sloucher(this.Name);
                    }
                    return returned;
                }
            }
            else
            {
                return null;
            }
            this.turnsDead = this.turnsDead + 1;
            return null;
        }

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

        public void bonusToAR()
        {
                       
            if (this is Player && Inventory.equippedWeaponDefensive is Shield)
            {
                this.baseAR = this.AR;
                this.AR = this.AR + 4;
            }
            else
            {

                this.AR = baseAR;
            }

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

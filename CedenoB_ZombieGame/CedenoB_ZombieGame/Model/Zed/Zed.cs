using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using CedenoB_ZombieGame.Item;
using CedenoB_ZombieGame.Item.Item.Model;
using CedenoB_ZombieGame.Item.Model;
using CedenoB_ZombieGame.Model;
using zombieApocalypse.Model;
using zombieApocalypse.Model.Melee;
using ZombieApocalypseSimulator.Model;

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

        private int _MoneyValue;
        public int MoneyValue
        {
            get { return _MoneyValue; }
            set { _MoneyValue = value; }
        }
        
        public Zed(string name, BitmapImage image):base(name, image)
        {
            base.IQ = 0;
            base.MA = 0;
            base.ME = 0;
        }

        private PlayerItem _DropItem;
        public PlayerItem DropItem
        {
            get { return _DropItem; }
            set { _DropItem = value; }
        }

        protected void getItem()
        {
            int i = rand.Next(0, 2);

            if (i != 0)
            {
                genItem();
            }
            else
            {
                DropItem = null;
            }
        }

        protected void genItem()
        {
            int i = rand.Next(0, 36);

            switch (i)
            {
                case 1:
                    //DropItem = new BearTrap();
                    break;

                case 2:
                    DropItem = new Defender();
                    break;

                case 3:
                    DropItem = new Desert();
                    break;
                
                case 4:
                    DropItem = new Farmer();
                    break;

                case 5:
                    DropItem = new Gangsta();
                    break;

                case 6:
                    DropItem = new HandgunAmmo();
                    break;
                    
                case 7:
                    //DropItem = new HealthPack();
                    break;
                    
                case 8:
                    //DropItem = new HealthPot();
                    break;

                case 9:
                    DropItem = new Hunter();
                    break;

                case 11:
                    DropItem = new Israli();
                    break;

                case 12:
                    DropItem = new LargeCrowbar();
                    break;

                case 13:
                    DropItem = new Machete();
                    break;

                case 14:
                    DropItem = new Milita();
                    break;

                case 15:
                    DropItem = new RifleAmmo();
                    break;

                case 16:
                    DropItem = new Rouge();
                    break;

                case 17:
                    DropItem = new ShotgunAmmo();
                    break;

                case 18:
                    DropItem = new SludgeHammer();
                    break;

                case 19:
                    DropItem = new Slugger();
                    break;

                case 20:
                    DropItem = new SmallCrowbar();
                    break;

                case 21:
                    DropItem = new Sniper();
                    break;

                case 22:
                    DropItem = new Special();
                    break;

                case 23:
                    DropItem = new Sport();
                    break;

                case 24:
                    DropItem = new SurvivalKnife();
                    break;

                case 25:
                    //DropItem = new Turret();
                    break;

                default:
                    DropItem = null;
                    break;
            }
        }
    }
}

using CedenoB_ZombieGame.Model;
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
        private static Random rand= new Random();

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
        
        public Zed(string name):base(name)
        {
            base.IQ = 0;
            base.MA = 0;
            base.ME = 0;
        }

        private CedenoB_ZombieGame.Item _DropItem;
        public CedenoB_ZombieGame.Item DropItem
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
                    DropItem = new CedenoB_ZombieGame.Model.BearTrap();
                    break;

                case 2:
                    DropItem = new CedenoB_ZombieGame.Model.Defender();
                    break;

                case 3:
                    DropItem = new CedenoB_ZombieGame.Model.Desert();
                    break;
                
                case 4:
                    DropItem = new CedenoB_ZombieGame.Model.Farmer();
                    break;

                case 5:
                    DropItem = new CedenoB_ZombieGame.Model.Gangsta();
                    break;

                case 6:
                    DropItem = new CedenoB_ZombieGame.Model.HandgunAmmo();
                    break;
                    
                case 7:
                    DropItem = new CedenoB_ZombieGame.Model.HealthPack();
                    break;
                    
                case 8:
                    DropItem = new CedenoB_ZombieGame.Model.HealthPot();
                    break;

                case 9:
                    DropItem = new CedenoB_ZombieGame.Model.Hunter();
                    break;

                case 11:
                    DropItem = new CedenoB_ZombieGame.Model.Israli();
                    break;

                case 12:
                    DropItem = new CedenoB_ZombieGame.Model.LargeCrowbar();
                    break;

                case 13:
                    DropItem = new CedenoB_ZombieGame.Model.Machete();
                    break;

                case 14:
                    DropItem = new CedenoB_ZombieGame.Model.Milita();
                    break;

                case 15:
                    DropItem = new CedenoB_ZombieGame.Model.RifleAmmo();
                    break;

                case 16:
                    DropItem = new CedenoB_ZombieGame.Model.Rouge();
                    break;

                case 17:
                    DropItem = new CedenoB_ZombieGame.Model.ShotgunAmmo();
                    break;

                case 18:
                    DropItem = new CedenoB_ZombieGame.Model.SludgeHammer();
                    break;

                case 19:
                    DropItem = new CedenoB_ZombieGame.Model.Slugger();
                    break;

                case 20:
                    DropItem = new CedenoB_ZombieGame.Model.SmallCrowbar();
                    break;

                case 21:
                    DropItem = new CedenoB_ZombieGame.Model.Sniper();
                    break;

                case 22:
                    DropItem = new CedenoB_ZombieGame.Model.Special();
                    break;

                case 23:
                    DropItem = new CedenoB_ZombieGame.Model.Sport();
                    break;

                case 24:
                    DropItem = new CedenoB_ZombieGame.Model.SurvivalKnife();
                    break;

                case 25:
                    DropItem = new CedenoB_ZombieGame.Model.Turret();
                    break;

                default:
                    DropItem = null;
                    break;
            }
        }
    }
}

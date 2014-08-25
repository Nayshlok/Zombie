using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
  public class GameImages
    {
      //Classes
        public static BitmapImage WarriorSource = new BitmapImage(new Uri("Images/Warrior.png", UriKind.Relative));
        public static BitmapImage SurvivalistSource = new BitmapImage(new Uri("Images/Survivalist.jpg", UriKind.Relative));
        public static BitmapImage SharpShooterSource = new BitmapImage(new Uri("Images/SharpSooter.png", UriKind.Relative));

      //Zed 
        public static BitmapImage FastAcctackSource = new BitmapImage(new Uri("Images/FastAttack.png", UriKind.Relative));
        public static BitmapImage ShankSource = new BitmapImage(new Uri("Images/Shank.png", UriKind.Relative));
        public static BitmapImage SloucherSource = new BitmapImage(new Uri("Images/Sloucher.png", UriKind.Relative));
        public static BitmapImage SpitterSource = new BitmapImage(new Uri("Images/Spitter.png", UriKind.Relative));
        public static BitmapImage TankSource = new BitmapImage(new Uri("Images/Tank.png", UriKind.Relative));


      //Weapons
        public static BitmapImage BearTrapSource = new BitmapImage(new Uri("Images/BearTrap.png", UriKind.Relative));
        public static BitmapImage HandgunSource = new BitmapImage(new Uri("Images/Handgun.jpg", UriKind.Relative));
        public static BitmapImage LargeCrowBarSource = new BitmapImage(new Uri("Images/LargeCrowBar.png", UriKind.Relative));
        public static BitmapImage MacheteSource = new BitmapImage(new Uri("Images/Machete.png", UriKind.Relative));
        public static BitmapImage ShootgunSource = new BitmapImage(new Uri("Images/Shotgun.png", UriKind.Relative));
        public static BitmapImage SludgeHammerSource = new BitmapImage(new Uri("Images/Sludgehammer.png", UriKind.Relative));
        public static BitmapImage SmallCrowbarSource = new BitmapImage(new Uri("Images/SmallCrowbar.png", UriKind.Relative));
        public static BitmapImage RifleSource = new BitmapImage(new Uri("Images/Rifle.png", UriKind.Relative));
  

    }
}

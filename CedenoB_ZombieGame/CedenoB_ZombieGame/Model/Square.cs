using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CedenoB_ZombieGame.Model;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZombieApocalypseSimulator;
using System.Windows;

namespace CedenoB_ZombieGame
{
    [Serializable()]
	public class Square : Canvas
	{
		private List<Item> _Items = new List<Item>();
        public List<Item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public Character Token { get; set; }
		bool isOpen = false;
        public Delegates.SelectCharacter PassCharacter { get; set; }
        public string imagePath { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

		public bool IsOpen
		{
			get
			{
				if (Token == null)
				{
					isOpen = true;
				}
				else
				{
					isOpen = false;
				}

				return isOpen;
			}
			set
			{
				isOpen = value;
			}
		}

		public Square()
		{
			this.MouseRightButtonDown += r_GMContextMenu;
		}

        public Square(Delegates.SelectCharacter characterPass, int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            PassCharacter += characterPass;
            this.MouseLeftButtonDown += selectCharacter;
            this.MouseRightButtonDown += r_GMContextMenu;
        }

        private void selectCharacter(object sender, MouseButtonEventArgs e)
        {
            PassCharacter(Token, X, Y);
        }

        public void RedrawImage()
        {
            if (imagePath != null)
            {
                Label l = new Label();
                l.Width = 50;
                l.Height = 45;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                l.Background = brush;
                this.Children.Add(l);
            }
        }

		private void r_GMContextMenu(object sender, MouseButtonEventArgs e)
		{
			//A Context menu and menu items for everything
			//the GM and add on the gameboard
			ContextMenu conMenu = new ContextMenu();
			MenuItem addPlayer = new MenuItem();
			MenuItem addZed = new MenuItem();
			MenuItem addMeleeWeapon = new MenuItem();
			MenuItem addAmmo = new MenuItem();
			MenuItem addHealth = new MenuItem();
			MenuItem addWarrior = new MenuItem();
			MenuItem addSharpShooter = new MenuItem();
			MenuItem addSurvivalist = new MenuItem();
			MenuItem addSloucher = new MenuItem();
			MenuItem addFastAttack = new MenuItem();
			MenuItem addTank = new MenuItem();
			MenuItem addShank = new MenuItem();
			MenuItem addSpitter = new MenuItem();
			MenuItem addSurvivalKnife = new MenuItem();
			MenuItem addSmallCrowbar = new MenuItem();
			MenuItem addLargeCrowbar = new MenuItem();
			MenuItem addMachete = new MenuItem();
			MenuItem addSludgeHammer = new MenuItem();
			MenuItem addTurret = new MenuItem();
			MenuItem addBearTraps = new MenuItem();
			MenuItem addSport = new MenuItem();
			MenuItem addRouge = new MenuItem();
			MenuItem addGangsta = new MenuItem();
			MenuItem addDefender = new MenuItem();
			MenuItem addIsraeli = new MenuItem();
			MenuItem addMilita = new MenuItem();
			MenuItem addDesert = new MenuItem();
			MenuItem addHunter = new MenuItem();
			MenuItem addSniper = new MenuItem();
			MenuItem addFarmer = new MenuItem();
			MenuItem addRonin = new MenuItem();
			MenuItem addSlugger = new MenuItem();
			MenuItem addSpecial = new MenuItem();
			MenuItem addHandGunAmmo = new MenuItem();
			MenuItem addRifleAmmo = new MenuItem();
			MenuItem addShotgunAmmo = new MenuItem();
			MenuItem addHealthPack = new MenuItem();
			MenuItem addHealthPots = new MenuItem();
			MenuItem addHandgun = new MenuItem();
			MenuItem addShotgun = new MenuItem();
			MenuItem addRifle = new MenuItem();
			//Item headers
			addPlayer.Header = "Add Player";
			addZed.Header = "Add Zed";
			addMeleeWeapon.Header = "Add Melee Weapon";
			addAmmo.Header = "Add Ammo";
			addHealth.Header = "Add Health";
			addWarrior.Header = "Warrior";
			addSharpShooter.Header = "Sharpshooter";
			addSurvivalist.Header = "Survivalist";
			addSloucher.Header = "Sloucher";
			addFastAttack.Header = "Fast Attack";
			addTank.Header = "Add Tank";
			addShank.Header = "Shank";
			addSpitter.Header = "Spitter";
			addSurvivalKnife.Header = "Survial Knife";
			addSmallCrowbar.Header = "Small Crowbar";
			addLargeCrowbar.Header = "Large Crowbar";
			addMachete.Header = "Machete";
			addSludgeHammer.Header = "Sludgehammer";
			addTurret.Header = "Turret";
			addBearTraps.Header = "Bear Trap";
			addSport.Header = "22 Sportgun";
			addRouge.Header = "9mm Rouge";
			addGangsta.Header = "9mm Gangsta";
			addDefender.Header = ".45 Defender";
			addIsraeli.Header = ".50 Israeli";
			addMilita.Header = ".223 Milita";
			addDesert.Header = ".556 Desert";
			addHunter.Header = ".762 Hunter";
			addSniper.Header = ".50 Sniper";
			addFarmer.Header = "12-gauge Farmer";
			addRonin.Header = "12-guage Ronin";
			addSlugger.Header = "12-gauge Slugger";
			addSpecial.Header = "Swat-a-be Special";
			addHandGunAmmo.Header = "Handgun Ammo";
			addRifleAmmo.Header = "Rifle Ammo";
			addShotgunAmmo.Header = "Shotgun Ammo";
			addHealthPack.Header = "Health Pack";
			addHealthPots.Header = "Health Pot";
			addHandgun.Header = "Add Handguns";
			addShotgun.Header = "Add Shootguns";
			addRifle.Header = "Add Rifle";
			//Item Names
			addPlayer.Name = "AddPlayer";
			addZed.Name = "AddZed";
			addMeleeWeapon.Name = "AddWeapon";
			addAmmo.Name = "AddAmmo";
			addHealth.Name = "AddHealth";
			addWarrior.Name = "Warrior";
			addSharpShooter.Name = "SharpShooter";
			addSurvivalist.Name = "Survivalist";
			addSloucher.Name = "Sloucher";
			addFastAttack.Name = "FastAttack";
			addTank.Name = "Tank";
			addShank.Name = "Shank";
			addSpitter.Name = "Spitter";
			addSurvivalKnife.Name = "SurvialKnife";
			addSmallCrowbar.Name = "SmallCrowbar";
			addLargeCrowbar.Name = "LargeCrowbar";
			addMachete.Name = "Machete";
			addSludgeHammer.Name = "Sludgehammer";
			addTurret.Name = "Turret";
			addBearTraps.Name = "BearTrap";
			addSport.Name = "Sportgun";
			addRouge.Name = "Rouge";
			addGangsta.Name = "Gangsta";
			addDefender.Name = "Defender";
			addIsraeli.Name = "Israeli";
			addMilita.Name = "Milita";
			addDesert.Name = "Desert";
			addHunter.Name = "Hunter";
			addSniper.Name = "Sniper";
			addFarmer.Name = "Farmer";
			addRonin.Name = "Ronin";
			addSlugger.Name = "Slugger";
			addSpecial.Name = "Special";
			addHandGunAmmo.Name = "HandgunAmmo";
			addRifleAmmo.Name = "RifleAmmo";
			addShotgunAmmo.Name = "ShotgunAmmo";
			addHealthPack.Name = "HealthPack";
			addHealthPots.Name = "HealthPot";
			addHandgun.Name = "Handguns";
			addShotgun.Name = "Shootguns";
			addRifle.Name = "Rifle";
			//Events for all items in menu 
			addPlayer.Click += this.right_Clicked;
			addZed.Click += this.right_Clicked;
			addMeleeWeapon.Click += this.right_Clicked;
			addAmmo.Click += this.right_Clicked;
			addHealth.Click += this.right_Clicked;
			addWarrior.Click += this.right_Clicked;
			addSharpShooter.Click += this.right_Clicked;
			addSurvivalist.Click += this.right_Clicked;
			addSloucher.Click += this.right_Clicked;
			addFastAttack.Click += this.right_Clicked;
			addTank.Click += this.right_Clicked;
			addShank.Click += this.right_Clicked;
			addSpitter.Click += this.right_Clicked;
			addSurvivalKnife.Click += this.right_Clicked;
			addSmallCrowbar.Click += this.right_Clicked;
			addLargeCrowbar.Click += this.right_Clicked;
			addMachete.Click += this.right_Clicked;
			addSludgeHammer.Click += this.right_Clicked;
			addTurret.Click += this.right_Clicked;
			addBearTraps.Click += this.right_Clicked;
			addSport.Click += this.right_Clicked;
			addRouge.Click += this.right_Clicked;
			addGangsta.Click += this.right_Clicked;
			addDefender.Click += this.right_Clicked;
			addIsraeli.Click += this.right_Clicked;
			addMilita.Click += this.right_Clicked;
			addDesert.Click += this.right_Clicked;
			addHunter.Click += this.right_Clicked;
			addSniper.Click += this.right_Clicked;
			addFarmer.Click += this.right_Clicked;
			addRonin.Click += this.right_Clicked;
			addSlugger.Click += this.right_Clicked;
			addSpecial.Click += this.right_Clicked;
			addHandGunAmmo.Click += this.right_Clicked;
			addRifleAmmo.Click += this.right_Clicked;
			addShotgunAmmo.Click += this.right_Clicked;
			addHealthPack.Click += this.right_Clicked;
			addHealthPots.Click += this.right_Clicked;
			addHandgun.Click += this.right_Clicked;
			addShotgun.Click += this.right_Clicked;
			addRifle.Click += this.right_Clicked;
			//Player menu and submenu 
			addPlayer.Items.Add(addWarrior);
			addPlayer.Items.Add(addSharpShooter);
			addPlayer.Items.Add(addSurvivalist);
			conMenu.Items.Add(addPlayer);
			//Zed menu and submenu
			addZed.Items.Add(addSloucher);
			addZed.Items.Add(addFastAttack);
			addZed.Items.Add(addTank);
			addZed.Items.Add(addShank);
			addZed.Items.Add(addSpitter);
			conMenu.Items.Add(addZed);
			//Melee weapon menu and sub menu
			addMeleeWeapon.Items.Add(addSurvivalKnife);
			addMeleeWeapon.Items.Add(addSmallCrowbar);
			addMeleeWeapon.Items.Add(addLargeCrowbar);
			addMeleeWeapon.Items.Add(addMachete);
			addMeleeWeapon.Items.Add(addSludgeHammer);
			addMeleeWeapon.Items.Add(addBearTraps);
			addMeleeWeapon.Items.Add(addTurret);
			conMenu.Items.Add(addMeleeWeapon);
			//Handgun menu and submenu
			addHandgun.Items.Add(addSport);
			addHandgun.Items.Add(addRouge);
			addHandgun.Items.Add(addGangsta);
			addHandgun.Items.Add(addDefender);
			addHandgun.Items.Add(addIsraeli);
			conMenu.Items.Add(addHandgun);
			//Rifle menu and submenu 
			addRifle.Items.Add(addMilita);
			addRifle.Items.Add(addDesert);
			addRifle.Items.Add(addHunter);
			addRifle.Items.Add(addSniper);
			conMenu.Items.Add(addRifle);
			//Shotgun menu and submenu 
			addShotgun.Items.Add(addFarmer);
			addShotgun.Items.Add(addRonin);
			addShotgun.Items.Add(addSlugger);
			addShotgun.Items.Add(addSpecial);
			conMenu.Items.Add(addShotgun);
			//Ammo menu and submenu
			addAmmo.Items.Add(addHandGunAmmo);
			addAmmo.Items.Add(addRifleAmmo);
			addAmmo.Items.Add(addShotgunAmmo);
			conMenu.Items.Add(addAmmo);
			//Health menu and submenu
			addHealth.Items.Add(addHealthPack);
			addHealth.Items.Add(addHealthPots);
			conMenu.Items.Add(addHealth);

			this.ContextMenu = conMenu;
		}



		private void right_Clicked(object sender, System.Windows.RoutedEventArgs e)
		{
			MenuItem gmMenu;
			gmMenu = (MenuItem)sender;

			if (gmMenu.Name == "Warrior")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new Warrior("Warrior");
					l.Width = 50;
					l.Height = 45;
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/War.png";
					brush.ImageSource = new BitmapImage(new Uri("Images/War.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}
			else if (gmMenu.Name == "SharpShooter")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new SharpShooter("SharpShooter");
					l.Width = 50;
					l.Height = 50;
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/SharpShooter.png";
					brush.ImageSource = new BitmapImage(new Uri("Images/SharpShooter.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}
			else if (gmMenu.Name == "Survivalist")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new Survivalist("Surviver");
					l.Width = 48;
					l.Height = 45;
					
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/Sur.png";

					brush.ImageSource = new BitmapImage(new Uri("Images/Sur.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}
			else if (gmMenu.Name == "Sloucher")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new Sloucher("Sloucher");
					l.Width = 40;
					l.Height = 40;
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/Sloucher.png";

					brush.ImageSource = new BitmapImage(new Uri("Images/Sloucher.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}
			else if (gmMenu.Name == "FastAttack")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new FastAttack("FastAttack");
					l.Width = 40;
					l.Height = 40;
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/FastAttack.png";

					brush.ImageSource = new BitmapImage(new Uri("Images/FastAttack.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}
			else if (gmMenu.Name == "Tank")
			{
				if (IsOpen)
				{
					Label l = new Label();
					Token = new Tank("Tank");
					l.Width = 40;
					l.Height = 40;
					ImageBrush brush = new ImageBrush();
                    imagePath = "Images/Tank.png";

					brush.ImageSource = new BitmapImage(new Uri("Images/Tank.png", UriKind.Relative));
					l.Background = brush;
					IsOpen = false;
					this.Children.Add(l);
				}
			}

			else if (gmMenu.Name == "Shank")
			{
				Label l = new Label();
				Token = new Shank("Shank");
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Shank.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Shank.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = false;
				this.Children.Add(l);
			}

			else if (gmMenu.Name == "Spitter")
			{
				Label l = new Label();
				Token = new Spitter("Spitter");
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Spitter.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Spitter.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = false;
				this.Children.Add(l);
			}

			else if (gmMenu.Name == "SurvialKnife")
			{
				//create new survival knife
				//add to grid
				//add to list
				Label l = new Label();
				//Items = new SurvivalKnife();
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/SurvivalKnife.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/SurvivalKnife.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);

			}
			else if (gmMenu.Name == "SmallCrowbar")
			{
				Label l = new Label();
				//Items = new SmallCrowbar();
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/SmallCrowBar.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/SmallCrowBar.jpg", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "LargeCrowbar")
			{
				Label l = new Label();
				//	Items = new LargeCrowbar();
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/LargeCrowBar.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/LargeCrowBar.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Machete")
			{
				Label l = new Label();
				//Items = new Machete();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Machete.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Machete.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Sludgehammer")
			{
				Label l = new Label();
				//Items = new SludgeHammer();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/SludgeHammer.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/SludgeHammer.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Turret")
			{
				Label l = new Label();
				//Items = new Turret();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Turret.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Turret.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "BearTrap")
			{
				Label l = new Label();
				//Items = new BearTrap();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/BearTrap.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/BearTrap.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Sportgun")
			{
				Label l = new Label();
				//Items = new Sport();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Sport.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Sport.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Rouge")
			{
				Label l = new Label();
				//Items = new Rouge();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Rouge.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Rouge.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Gangsta")
			{
				Label l = new Label();
			//	Items = new Gangsta();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Gangsta.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Gangsta.jpg", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Defender")
			{
				Label l = new Label();
				//Items = new Defender();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Defender.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Defender.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Israeli")
			{
				Label l = new Label();
				//Items = new Israli();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Israeli.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Israeli.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Milita")
			{
				Label l = new Label();
				//Items = new Milita();
				l.Width = 55;
				l.Height = 55;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Milita.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Milita.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Desert")
			{
				Label l = new Label();
				//Items = new Desert();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Desert.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Desert.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Hunter")
			{
				Label l = new Label();
				//Items = new Hunter();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Hunter.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Hunter.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Sniper")
			{
				Label l = new Label();
				//Items = new Sniper();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Sniper.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Sniper.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Farmer")
			{
				Label l = new Label();
			//	Items = new Farmer();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Farmer.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Farmer.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Ronin")
			{
				Label l = new Label();
			//	Items = new Ronin();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Ronin.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Ronin.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Slugger")
			{
				Label l = new Label();
				//Items = new Slugger();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Slugger.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Slugger.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "Special")
			{
				Label l = new Label();
				//Items = new Special();
				l.Width = 50;
				l.Height = 50;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/Special.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/Special.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "HandgunAmmo")
			{
				Label l = new Label();
				//Items = new HandgunAmmo();
				l.Width = 50;
				l.Height = 43;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/HandgunAmmo.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/HandgunAmmo.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "RifleAmmo")
			{
				Label l = new Label();
				//Items = new RifleAmmo();
				l.Width = 50;
				l.Height = 43;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/RifleAmmo.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/RifleAmmo.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "ShotgunAmmo")
			{
				Label l = new Label();
				//Items = new ShotgunAmmo();
				l.Width = 50;
				l.Height = 45;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/ShotgunAmmo.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/ShotgunAmmo.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "HealthPack")
			{
				Label l = new Label();
			//	Items = new HealthPack();
				l.Width = 50;
				l.Height = 45;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/HealthKit.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/HealthKit.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
			else if (gmMenu.Name == "HealthPot")
			{
				Label l = new Label();
				//Items = new HealthPot();
				l.Width = 40;
				l.Height = 40;
				ImageBrush brush = new ImageBrush();
                imagePath = "Images/HealthPot.png";

				brush.ImageSource = new BitmapImage(new Uri("Images/HealthPot.png", UriKind.Relative));
				l.Background = brush;
				IsOpen = true;
				this.Children.Add(l);
			}
		}

        public override string ToString()
        {
            return Token.ToString();
        }

	}
}

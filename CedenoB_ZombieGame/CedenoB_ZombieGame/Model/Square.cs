using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CedenoB_ZombieGame.Item;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZombieApocalypseSimulator;
using ZombieApocalypseSimulator.Model;
using CedenoB_ZombieGame.Items;
using CedenoB_ZombieGame.Model;
using zombieApocalypse.Model.Melee;
using CedenoB_ZombieGame.Item.Item.Model;
using CedenoB_ZombieGame.Item.Model;
using CedenoB_ZombieGame.View;
using System.Collections.ObjectModel;
using System.Windows;

namespace CedenoB_ZombieGame
{
    [Serializable()]





    public class Square : Canvas
    {
        AddCharacterWindow addCharacter = new AddCharacterWindow();
        AddZedCreateWindow ZedCreate = new AddZedCreateWindow();
        public Character Token { get; set; }
		bool isOpen = false;
        public Delegates.SelectCharacter PassCharacter { get; set; }
        public string imagePath { get; set; }
        public bool onFire { get; set; }
        public bool hasOil { get; set; }
		public  List<PlayerItem> Items = new List<PlayerItem>();
        public ObservableCollection<PlayerItem> Item = new ObservableCollection<PlayerItem>();

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
            //if(Token != null)
                //MessageBox.Show(Token.Name + ": HP: " + Token.HP + ", SDC: " + Token.SDC);
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
            MenuItem CurrentCharacterStatus = new MenuItem();
            MenuItem CurrentZedStatus = new MenuItem();
            MenuItem EditCharacter = new MenuItem();
            MenuItem EditZed = new MenuItem();

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
            CurrentCharacterStatus.Header = "Edit Player";
            CurrentZedStatus.Header = "Edit Zed";
            EditCharacter.Header = "Current Staus / Edit";
            EditZed.Header = "Current Staus / Edit";
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
            CurrentCharacterStatus.Name = "CurrentStatus";
            CurrentZedStatus.Name = "ZedStatus";
            EditCharacter.Name = "EditCharacter";
            EditZed.Name = "EditZed";

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
            CurrentCharacterStatus.Click += this.right_Clicked;
            CurrentZedStatus.Click += this.right_Clicked;
            EditCharacter.Click += this.right_Clicked;
            EditZed.Click += this.right_Clicked;

            //Player menu and submenu 
            addPlayer.Items.Add(addWarrior);
            addPlayer.Items.Add(addSharpShooter);
            addPlayer.Items.Add(addSurvivalist);
            conMenu.Items.Add(addPlayer);
            //Edit CharacterMenu and submenu
            CurrentCharacterStatus.Items.Add(EditCharacter);
            conMenu.Items.Add(CurrentCharacterStatus);
            //Zed menu and submenu
            addZed.Items.Add(addSloucher);
            addZed.Items.Add(addFastAttack);
            addZed.Items.Add(addTank);
            addZed.Items.Add(addShank);
            addZed.Items.Add(addSpitter);
            conMenu.Items.Add(addZed);
            //Edit ZedMenu and submenu
            CurrentZedStatus.Items.Add(EditZed);
            conMenu.Items.Add(CurrentZedStatus);
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


            //CurrentStatus.Items;

            this.ContextMenu = conMenu;
        }

        void onFire_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsOpen == true && this.onFire == false)
            {
                this.onFire = true;
                Label l = new Label();
                l.Width = 50;
                l.Height = 45;
                ImageBrush brush = new ImageBrush();
                imagePath = "Images/Fire.png";
                brush.ImageSource = new BitmapImage(new Uri("Images/Fire.png", UriKind.Relative));
                l.Background = brush;
                this.Children.Add(l);
            }
        }



        private void right_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            MenuItem gmMenu;
            gmMenu = (MenuItem)sender;


            if (!IsOpen)
            {
                if (gmMenu.Name == "CurrentStatus")
                {

                    if (Token is Player)
                    {
                        addCharacter = new AddCharacterWindow();
                        addCharacter.SquarePointer = this;
                        addCharacter.DataContext = Token;
                        addCharacter.inventoryDataGrid.ItemsSource = Token.Inventory.itemList;
                        addCharacter.Show();
                    }

                }
                else if (gmMenu.Name == "ZedStatus")
                {
                    if (Token is Zed)
                    {

                        ZedCreate = new AddZedCreateWindow();
                        ZedCreate.SquarePointer = this;
                        ZedCreate.DataContext = Token;
                        ZedCreate.Show();
                    }
                }

            }

            if (gmMenu.Name == "Warrior")
            {
                if (IsOpen)
                {

                    Token = new Warrior("Warrior");
                    addCharacter.DataContext = Token;
                    addCharacter.SquarePointer = this;
                    addCharacter.inventoryDataGrid.ItemsSource = Token.Inventory.itemList;
                    addCharacter.Image = GameImages.WarriorSource;
                    addCharacter.Show();

                    //  addCharacter.IQBox.DataContext = Token.IQ;

                }
            }
            else if (gmMenu.Name == "SharpShooter")
            {
                if (IsOpen)
                {
                    Token = new SharpShooter("SharpShooter");
                    addCharacter.DataContext = Token;
                    addCharacter.SquarePointer = this;
                    addCharacter.inventoryDataGrid.ItemsSource = Token.Inventory.itemList;
                    addCharacter.Image = GameImages.SharpShooterSource;
                    addCharacter.Show();


                    //Label l = new Label();
                    //Token = new SharpShooter("SharpShooter");
                    //l.Width = 50;
                    //l.Height = 50;
                    //ImageBrush brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("Images/SharpShooter.png", UriKind.Relative));
                    //l.Background = brush;
                    //IsOpen = false;
                    //this.Children.Add(l);
                }
            }
            else if (gmMenu.Name == "Survivalist")
            {
                if (IsOpen)
                {

                    Token = new Survivalist("Survivalist");
                    addCharacter.DataContext = Token;
                    addCharacter.SquarePointer = this;
                    addCharacter.inventoryDataGrid.ItemsSource = Token.Inventory.itemList;
                    addCharacter.Image = GameImages.SurvivalistSource;
                    addCharacter.Show();

                    //Label l = new Label();
                    //Token = new Survivalist("Surviver");
                    //l.Width = 48;
                    //l.Height = 45;

                    //ImageBrush brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("Images/Sur.png", UriKind.Relative));
                    //l.Background = brush;
                    //IsOpen = false;
                    //this.Children.Add(l);
                }
            }
            else if (gmMenu.Name == "Sloucher")
            {
                if (IsOpen)
                {

                    Token = new Sloucher("Sloucher");
                    ZedCreate.DataContext = Token;
                    ZedCreate.SquarePointer = this;
                    ZedCreate.Image = GameImages.SloucherSource;
                    ZedCreate.Show();

                    //Label l = new Label();
                    //Token = new Sloucher("Sloucher");
                    //l.Width = 40;
                    //l.Height = 40;
                    //ImageBrush brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("Images/Sloucher.png", UriKind.Relative));
                    //l.Background = brush;
                    //IsOpen = false;
                    //this.Children.Add(l);
                }
            }
            else if (gmMenu.Name == "FastAttack")
            {
                if (IsOpen)
                {

                    Token = new FastAttack("FastAttack");
                    ZedCreate.DataContext = Token;
                    ZedCreate.SquarePointer = this;
                    ZedCreate.Image = GameImages.FastAcctackSource;
                    ZedCreate.Show();

                    //Label l = new Label();
                    //Token = new FastAttack("FastAttack");
                    //l.Width = 40;
                    //l.Height = 40;
                    //ImageBrush brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("Images/FastAttack.png", UriKind.Relative));
                    //l.Background = brush;
                    //IsOpen = false;
                    //this.Children.Add(l);
                }
            }
            else if (gmMenu.Name == "Tank")
            {
                if (IsOpen)
                {
                    Token = new Tank("Tank");
                    ZedCreate.DataContext = Token;
                    ZedCreate.SquarePointer = this;
                    ZedCreate.Image = GameImages.TankSource;
                    ZedCreate.Show();
                    //Label l = new Label();
                    //Token = new Tank("Tank");
                    //l.Width = 40;
                    //l.Height = 40;
                    //ImageBrush brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("Images/Tank.png", UriKind.Relative));
                    //l.Background = brush;
                    //IsOpen = false;
                    //this.Children.Add(l);
                }
            }

            else if (gmMenu.Name == "Shank")
            {

                Token = new Shank("Shank");
                ZedCreate.DataContext = Token;
                ZedCreate.SquarePointer = this;
                ZedCreate.Image = GameImages.ShankSource;
                ZedCreate.Show();

                //Label l = new Label();
                //Token = new Shank("Shank");
                //l.Width = 40;
                //l.Height = 40;
                //ImageBrush brush = new ImageBrush();
                //brush.ImageSource = new BitmapImage(new Uri("Images/Shank.png", UriKind.Relative));
                //l.Background = brush;
                //IsOpen = false;
                //this.Children.Add(l);
            }

            else if (gmMenu.Name == "Spitter")
            {


                Token = new Spitter("Spitter");
                ZedCreate.DataContext = Token;
                ZedCreate.SquarePointer = this;
                ZedCreate.Image = GameImages.SpitterSource;
                ZedCreate.Show();

            }

            else if (gmMenu.Name == "SurvialKnife")
            {

                Label l = new Label();
                Items.Add(new SurvivalKnife());
                l.Width = 40;
                l.Height = 40;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/SurvivalKnife.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);

            }
            else if (gmMenu.Name == "SmallCrowbar")
            {
                Label l = new Label();
                Items.Add(new SmallCrowbar());
                l.Width = 40;
                l.Height = 40;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/SmallCrowBar.jpg", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "LargeCrowbar")
            {
                Label l = new Label();
                Items.Add(new LargeCrowbar());
                l.Width = 40;
                l.Height = 40;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/LargeCrowBar.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Machete")
            {
                Label l = new Label();
                Items.Add(new Machete());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Machete.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Sludgehammer")
            {
                Label l = new Label();
                Items.Add(new SludgeHammer());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/SludgeHammer.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Turret")
            {
                Label l = new Label();
                //Items.Add(new Turret());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Turret.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "BearTrap")
            {
                Label l = new Label();
                //Items.Add(new BearTrap());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/BearTrap.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Sportgun")
            {
                Label l = new Label();
                Items.Add(new Sport());
                // Token.Inventory.AddItem(new Sport());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Sport.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Rouge")
            {
                Label l = new Label();
                Items.Add(new Rouge());
                //Token.Inventory.AddItem(new Rouge());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Rouge.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Gangsta")
            {
                Label l = new Label();
                Items.Add(new Gangsta());
                // Token.Inventory.AddItem(new Gangsta());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Gangsta.jpg", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Defender")
            {
                Label l = new Label();
                Items.Add(new Defender());
                //Token.Inventory.AddItem(new Defender());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Defender.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Israeli")
            {
                Label l = new Label();
                Items.Add(new Israli());
                //Token.Inventory.AddItem(new Israli());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Israeli.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Milita")
            {
                Label l = new Label();
                Items.Add(new Milita());
                //Token.Inventory.AddItem(new Milita());
                l.Width = 55;
                l.Height = 55;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Milita.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Desert")
            {
                Label l = new Label();
                Items.Add(new Desert());
                //  Token.Inventory.AddItem(new Desert());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Desert.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Hunter")
            {
                Label l = new Label();
                Items.Add(new Hunter());
                //Token.Inventory.AddItem(new Hunter());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Hunter.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Sniper")
            {
                Label l = new Label();
                Items.Add(new Sniper());
                //Token.Inventory.AddItem(new Sniper());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Sniper.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Farmer")
            {
                Label l = new Label();
                Items.Add(new Farmer());
                //Token.Inventory.AddItem(new Farmer());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Farmer.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Ronin")
            {
                Label l = new Label();
                Items.Add(new Ronin());
                //Token.Inventory.AddItem(new Ronin());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Ronin.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Slugger")
            {
                Label l = new Label();
                Items.Add(new Slugger());
                //Token.Inventory.AddItem(new Slugger());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Slugger.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "Special")
            {
                Label l = new Label();
                Items.Add(new Special());
                //Token.Inventory.AddItem(new Special());
                l.Width = 50;
                l.Height = 50;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/Special.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "HandgunAmmo")
            {
                Label l = new Label();
                Items.Add(new HandgunAmmo());
                //Token.Inventory.AddItem(new HandgunAmmo());
                l.Width = 50;
                l.Height = 43;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/HandgunAmmo.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "RifleAmmo")
            {
                Label l = new Label();
                Items.Add(new RifleAmmo());
                //Token.Inventory.AddItem(new RifleAmmo());
                l.Width = 50;
                l.Height = 43;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/RifleAmmo.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "ShotgunAmmo")
            {
                Label l = new Label();
                Items.Add(new ShotgunAmmo());
                //Token.Inventory.AddItem(new ShotgunAmmo());
                l.Width = 50;
                l.Height = 45;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/ShotgunAmmo.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "HealthPack")
            {
                Label l = new Label();
                //Items.Add(new HealthPack());
                l.Width = 50;
                l.Height = 45;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/HealthKit.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
            else if (gmMenu.Name == "HealthPot")
            {
                Label l = new Label();
                //Items.Add(new HealthPot());
                l.Width = 40;
                l.Height = 40;
                ImageBrush brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Images/HealthPot.png", UriKind.Relative));
                l.Background = brush;
                IsOpen = true;
                this.Children.Add(l);
            }
        }

        public void PlacingImage(BitmapImage PicturePath)
        {
            Label l = new Label();
            l.Width = 50;
            l.Height = 45;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = PicturePath;
            //new BitmapImage(new Uri(PicturePath , UriKind.Relative));
            l.Background = brush;
            IsOpen = false;
            this.Children.Add(l);
        }

        public override string ToString()
        {
            return Token.ToString();
        }

	}
}

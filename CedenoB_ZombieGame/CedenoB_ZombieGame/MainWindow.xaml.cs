using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ZombieApocalypseSimulator;
using zombieApocalypse.Combat;
using CedenoB_ZombieGame.Model;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ZombieApocalypseSimulator.Model;
using zombieApocalypse.Model.Melee;
using CedenoB_ZombieGame.Items.Others;


namespace CedenoB_ZombieGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public partial class MainWindow : Window
	{
		Square[,] GameBoard;

        public int stageHeight { get; set; }
        public int stageWidth { get; set; }
        private Character attacker;
        private Character defender;
        public int FirstX { get; set; }
        public int FirstY { get; set; }
        public int SecondX { get; set; }
        public int SecondY { get; set; }
        private double CellWidth { get; set; }
        private double CellHeight { get; set; }
        private Grid battleView;
        private CombatManager combatManager;
        private SaveControl saveControl = new SaveControl();
        public UnitMovement.Movement move = new UnitMovement.Movement();

		public MainWindow()
		{
            combatManager = new CombatManager();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.SourceInitialized += (s, a) => this.WindowState = WindowState.Maximized;
            this.DataContext = this;
			SetupEntityGrid();

            ScrollViewer playerScroll = new ScrollViewer();
            playerScroll.Content = Player_Area;
            ScrollViewer zedScroll = new ScrollViewer();
            zedScroll.Content = Zed_Area;

            Warrior test = new Warrior("TEST");
            Console.WriteLine("\n" + test.Inventory.equippedWeapon.Name + "\n");

            player1.DataContext = new Warrior("WARRIOR TEST");
            player2.DataContext = new SharpShooter("SHARPSHOOTER TEST");
            player3.DataContext = new Survivalist("SURVIVALIST TEST");
            player4.DataContext = new Warrior("WARRIOR 2 TEST");
            player5.DataContext = new SharpShooter("SHARPSHOOTER 2 TEST");

            zed1.DataContext = new Sloucher("SLOUCHER TEST 1");
            zed2.DataContext = new FastAttack("FAST ATTACK TEST 1");
            zed3.DataContext = new Shank("SHANK TEST 1");
            zed4.DataContext = new Tank("TANK TEST 1");
            zed5.DataContext = new Spitter("SPITTER TEST 1");

            this.Closed += MainWindowClosed;

		}


        void MainWindowClosed(object sender, EventArgs e)
        {
            App.Current.Shutdown();

        }



		private void SetupEntityGrid()
		{
			GameUniformGrid.Children.Clear();
			GameBoard = new Square[25, 25];

			for (int x = 0; x < 25; x++)
			{
				for (int y = 0; y < 25; y++)
				{
                    Square r = new Square(AddCharacter, x, y);
                    r.Background = new SolidColorBrush(Color.FromArgb(255, 225, 225, 255));
                    GameBoard[x, y] = r;
					GameBoard[x, y].Margin = new Thickness(1);
				}
			}
            createGridDisplay();
		}

        public void createGridDisplay()
        {
            GameUniformGrid.Children.Clear();
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    GameUniformGrid.Children.Add(GameBoard[x, y]);

                }
            }
            Console.WriteLine();

            move.grid = GameBoard;
        }

        public Coordinate FindCharacter(Character character)
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (GameBoard[i, j].Token == character)
                    {
                        return new Coordinate(i, j);
                    }
                }
            }
            return null;
        }
        
        public void AddCharacter(Character character, int x, int y)
        {
            if (character != null)
            {
                if (attacker == null || (attacker != null && defender != null))
                {
                    FirstX = x;
                    FirstY = y;
                    attacker = character;
                    defender = null;
                }
                else if (attacker != null && defender == null)
                {
                    SecondX = x;
                    SecondY = y;
                    defender = character;
                }
            }
        }

        private void testButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (attacker != null && defender != null && combatManager != null)
            {
                BuildGrid(combatManager.startCombat(attacker, defender));
            }
            else
            {
                GameGrid.Children.Remove(battleView);
            }
        }

        #region CombatGUI
        private void BuildGrid(CombatResults results)
        {
            CellHeight = GameGrid.ActualHeight / 25;
            CellWidth = GameGrid.ActualWidth / 25;
            Grid combatView = new Grid();
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.RowDefinitions.Add(new RowDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.ColumnDefinitions.Add(new ColumnDefinition());
            combatView.Background = new SolidColorBrush(Colors.Wheat);
            //Attacker and Defender Labels
            Label AttackerLabel = new Label();
            AttackerLabel.Content = "Attacker";
            Grid.SetColumnSpan(AttackerLabel, 2);
            combatView.Children.Add(AttackerLabel);
            Label DefenderLabel = new Label();
            DefenderLabel.Content = "Defender";
            Grid.SetColumn(DefenderLabel, 2);
            Grid.SetColumnSpan(DefenderLabel, 2);
            combatView.Children.Add(DefenderLabel);
            //Name Labels
            Label AttackerName = new Label();
            AttackerName.Content = attacker.Name;
            Grid.SetColumnSpan(AttackerName, 2);
            Grid.SetRow(AttackerName, 1);
            combatView.Children.Add(AttackerName);
            Label DefenderName = new Label();
            DefenderName.Content = defender.Name;
            Grid.SetColumn(DefenderName, 2);
            Grid.SetColumnSpan(DefenderName, 2);
            Grid.SetRow(DefenderName, 1);
            combatView.Children.Add(DefenderName);
            //AttackRoll DefendRoll
            if (!results.Allies)
            {
                Label AttackRollLabel = new Label();
                AttackRollLabel.Content = "Attack Roll";
                Grid.SetRow(AttackRollLabel, 2);
                combatView.Children.Add(AttackRollLabel);
                Label AttackRoll = new Label();
                AttackRoll.Content = results.AttackRoll;
                if (results.AttackCrit)
                {
                    AttackRollLabel.Background = new SolidColorBrush(Colors.Green);
                    AttackRoll.Background = new SolidColorBrush(Colors.Green);
                }
                if (results.AttackFail)
                {
                    AttackRollLabel.Background = new SolidColorBrush(Colors.Red);
                    AttackRoll.Background = new SolidColorBrush(Colors.Red);
                }
                Grid.SetRow(AttackRoll, 2);
                Grid.SetColumn(AttackRoll, 1);
                combatView.Children.Add(AttackRoll);
                if (results.AttackHit)
                {
                    Label DefendRollLabel = new Label();
                    DefendRollLabel.Content = results.DefenseType;
                    Grid.SetColumn(DefendRollLabel, 2);
                    Grid.SetRow(DefendRollLabel, 2);
                    combatView.Children.Add(DefendRollLabel);
                    Label DefendRoll = new Label();
                    DefendRoll.Content = results.DefendRoll;
                    if (results.DefendCrit)
                    {
                        DefendRollLabel.Background = new SolidColorBrush(Colors.Green);
                        DefendRoll.Background = new SolidColorBrush(Colors.Green);
                    }
                    if (results.DefendFail)
                    {
                        DefendRollLabel.Background = new SolidColorBrush(Colors.Red);
                        DefendRoll.Background = new SolidColorBrush(Colors.Red);
                    }
                    Grid.SetColumn(DefendRoll, 3);
                    Grid.SetRow(DefendRoll, 2);
                    combatView.Children.Add(DefendRoll);
                    if (results.Damage != 0)
                    {
                        Label DamageDoneLabel = new Label();
                        DamageDoneLabel.Content = "Damage";
                        Grid.SetRow(DamageDoneLabel, 3);
                        combatView.Children.Add(DamageDoneLabel);
                        Label DamageDone = new Label();
                        DamageDone.Content = results.Damage;
                        Grid.SetColumn(DamageDone, 1);
                        Grid.SetRow(DamageDone, 3);
                        combatView.Children.Add(DamageDone);
                        Label AttackerHPLabel = new Label();
                        AttackerHPLabel.Content = "Health";
                        Grid.SetRow(AttackerHPLabel, 4);
                        combatView.Children.Add(AttackerHPLabel);
                        Label AttackerHP = new Label();
                        AttackerHP.Content = attacker.HP;
                        Grid.SetRow(AttackerHP, 4);
                        Grid.SetColumn(AttackerHP, 1);
                        combatView.Children.Add(AttackerHP);
                        Label DefenderHPLabel = new Label();
                        DefenderHPLabel.Content = "Health";
                        Grid.SetRow(DefenderHPLabel, 4);
                        Grid.SetColumn(DefenderHPLabel, 2);
                        combatView.Children.Add(DefenderHPLabel);
                        Label DefenderHP = new Label();
                        DefenderHP.Content = defender.HP;
                        Grid.SetRow(DefenderHP, 4);
                        Grid.SetColumn(DefenderHP, 3);
                        combatView.Children.Add(DefenderHP);

                        Label AttackerSDCLabel = new Label();
                        AttackerSDCLabel.Content = "SDC";
                        Grid.SetRow(AttackerSDCLabel, 5);
                        combatView.Children.Add(AttackerSDCLabel);
                        Label AttackerSDC = new Label();
                        AttackerSDC.Content = attacker.SDC;
                        Grid.SetRow(AttackerSDC, 5);
                        Grid.SetColumn(AttackerSDC, 1);
                        combatView.Children.Add(AttackerSDC);
                        Label DefenderSDCLabel = new Label();
                        DefenderSDCLabel.Content = "SDC";
                        Grid.SetRow(DefenderSDCLabel, 5);
                        Grid.SetColumn(DefenderSDCLabel, 2);
                        combatView.Children.Add(DefenderSDCLabel);
                        Label DefenderSDC = new Label();
                        DefenderSDC.Content = defender.SDC;
                        Grid.SetRow(DefenderSDC, 5);
                        Grid.SetColumn(DefenderSDC, 3);
                        combatView.Children.Add(DefenderSDC);
                    }
                    else
                    {
                        Label SuccessDefend = new Label();
                        SuccessDefend.Content = "Successfully Defended Attack";
                        Grid.SetRow(SuccessDefend, 3);
                        Grid.SetColumnSpan(SuccessDefend, 4);
                        combatView.Children.Add(SuccessDefend);
                    }
                }
                else
                {
                    Label AttackMiss = new Label();
                    AttackMiss.Content = attacker.Name + " missed";
                    Grid.SetRow(AttackMiss, 3);
                    Grid.SetColumnSpan(AttackMiss, 4);
                    combatView.Children.Add(AttackMiss);
                }
            }
            else
            {
                Label FriendlyMessage = new Label();
                FriendlyMessage.Content = results.Message;
                Grid.SetRow(FriendlyMessage, 2);
                Grid.SetColumnSpan(FriendlyMessage, 4);
                combatView.Children.Add(FriendlyMessage);
            }
            //Add grid to canvas at location, wait 3 seconds and close
            Canvas.SetTop(combatView, (CellHeight * (FirstX + 1)));
            Canvas.SetLeft(combatView, (CellWidth * (FirstY)));
            GameGrid.Children.Add(combatView);

            if(GameGrid.Children.Contains(battleView))
            {
                GameGrid.Children.Remove(battleView);
            }
            battleView = combatView;
        }
        #endregion

        public void endTurnCheck()
        {
            foreach (Square s in GameBoard)
            {
                if (s.onFire)
                {
                    fireDamage(s);
                }
            }
            attacker = new Warrior("Test");
            defender = new SharpShooter("Test2");
        }

        public void fireDamage(Square s)
        {
            if (s.Token != null)
            {
                s.Token.HP -= 4;
                s.Token.SDC -= 2;
            }
            if (GameBoard[s.X - 1, s.Y].Token != null)
            {
                GameBoard[s.X - 1, s.Y].Token.HP -= 2;
            }
            if (GameBoard[s.X + 1, s.Y].Token != null)
            {
                GameBoard[s.X + 1, s.Y].Token.HP -= 2;
            }
            if (GameBoard[s.X,s.Y - 1].Token != null)
            {
                GameBoard[s.X, s.Y - 1].Token.HP -= 2;
            }
            if (GameBoard[s.X, s.Y + 1].Token != null)
            {
                GameBoard[s.X, s.Y + 1].Token.HP -= 2;
            }
        }

        private void CommandBinding_CanExecute_1(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog();
            saveDialog.AddExtension = true;
            saveDialog.DefaultExt = ".zac";
            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Stream myStream = null;
                    if ((myStream = saveDialog.OpenFile()) != null)
                    {
                        saveControl.save(myStream, GameBoard);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadGame(SaveableSquare[,] savedCampaign)
        {
            foreach (SaveableSquare s in savedCampaign)
            {
                Square tempSquare = new Square(AddCharacter, s.X, s.Y);
                tempSquare.Background = new SolidColorBrush(Color.FromArgb(255, 225, 225, 255)); 
                tempSquare.IsOpen = s.IsOpen;
                tempSquare.Items = s.Items;
                tempSquare.Token = s.Token;
                tempSquare.imagePath = s.imagePath;
                tempSquare.Margin = new Thickness(1);
                tempSquare.RedrawImage();
                GameBoard[s.X, s.Y] = tempSquare;
            }
            createGridDisplay();
        }

        private void CommandBinding_CanExecute_2(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialogName = new System.Windows.Forms.OpenFileDialog();
            dialogName.Filter = "Program Files (*.zac)|*.zac";
            if (dialogName.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Stream myStream = null;
                    if ((myStream = dialogName.OpenFile()) != null)
                    {
                        LoadGame(saveControl.open(myStream).GameGrid);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }

        private void endTurn_Click_1(object sender, RoutedEventArgs e)
        {
            endTurnCheck();
        }

        private void openTrade_Click()
        {

            var window = new Shops.Shop((Player)attacker);
            window.Show();
        }
        //OPEN TRADE TEST
        private void OpenShop()
        {
            var window = new Shops.PlayerTrading((Player)attacker, (Player)defender);
            window.Show();
        }
        //ZOMBIFY
        private void Zombify_Click(object sender, RoutedEventArgs e)
        {
            Square zombieSquare;
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (GameBoard[i, j].Token is Player)
                    {
                        zombieSquare = GameBoard[i, j];
                        Player a = (Player)GameBoard[i, j].Token;
                        Zed newzed = a.Zombify();
                        if (newzed != null)
                        {
                            zombieSquare.IsOpen = true;
                            zombieSquare.Children.Clear();
                            GameGrid.Children.Remove(GameBoard[i, j]);
                            zombieSquare.placeZombie(newzed);
                        }
                    }
                }
            }
        }
        //END TESTING
        


    }
}



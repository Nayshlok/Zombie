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
using System.Windows.Shapes;
using ZombieApocalypseSimulator.Model;
using System.Collections.ObjectModel;
using CedenoB_ZombieGame.Model;
using zombieApocalypse.Model.Melee;
using System.Collections;
using CedenoB_ZombieGame.Item;
using CedenoB_ZombieGame.Item.Items.Ammo;
using CedenoB_ZombieGame.Item.Item.Model;
using CedenoB_ZombieGame.Item.Model;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame
{
    /// <summary>
    /// Interaction logic for AddCharacterWindow.xaml
    /// </summary>
    /// 

    public delegate void saveCharacterSpot(BitmapImage Picture);
    public partial class AddCharacterWindow : Window
    {
        ObservableCollection<PlayerItem> list = new ObservableCollection<PlayerItem>();
        public saveCharacterSpot saveSpot;
        public BitmapImage Image { get; set; }

        public AddCharacterWindow()
        {
            InitializeComponent();
            ItemComboBox.ItemsSource = list;

            list.Add(new SmallCrowbar());
            list.Add(new LargeCrowbar());
            list.Add(new SludgeHammer());
            list.Add(new SurvivalKnife());
            list.Add(new Machete());
            list.Add(new Desert());
            list.Add(new Hunter());
            list.Add(new Milita());
            list.Add(new Sniper());
            list.Add(new Farmer());
            list.Add(new Ronin());
            list.Add(new Slugger());
            list.Add(new Special());
            list.Add(new HandgunAmmo());
            list.Add(new RifleAmmo());
            list.Add(new ShotgunAmmo());
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

            if (ItemComboBox.SelectedIndex != -1)
            {
                SquarePointer.Token.Inventory.AddItem(list.ElementAt(ItemComboBox.SelectedIndex));
            }


        }
        private void Re_Roll_Click(object sender, RoutedEventArgs e)
        {
            Character currentCharacter = SquarePointer.Token;
            currentCharacter.IQ = currentCharacter.DummyDice(6, 3);
            currentCharacter.ME = currentCharacter.DummyDice(6, 3);
            currentCharacter.MA = currentCharacter.DummyDice(6, 3);
            currentCharacter.PS = currentCharacter.DummyDice(6, 3);
            currentCharacter.PE = currentCharacter.DummyDice(6, 3);
            currentCharacter.PP = currentCharacter.DummyDice(6, 3);
            currentCharacter.PB = currentCharacter.DummyDice(6, 3);
            currentCharacter.SPD = currentCharacter.DummyDice(6, 3);
            currentCharacter.HP = currentCharacter.DummyDice(6, 3);
            currentCharacter.SDC = currentCharacter.DummyDice(6, 3);
        }
        private void SaveClick(object sender, RoutedEventArgs e)
        {

            saveSpot -= SquarePointer.PlacingImage;
            saveSpot += SquarePointer.PlacingImage;
            saveSpot(Image);

            this.DataContext = SquarePointer.Token;
            inventoryDataGrid.ItemsSource = SquarePointer.Token.Inventory.itemList;
            this.Close();


        }
        public Square SquarePointer { get; set; }
    }
}

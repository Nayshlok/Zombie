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
using ZombieApocalypseSimulator;
using ZombieApocalypseSimulator.Model;

namespace CedenoB_ZombieGame.View
{
    /// <summary>
    /// Interaction logic for AddZedCreateWindow.xaml
    /// </summary>
    public partial class AddZedCreateWindow : Window
    {
        public saveCharacterSpot saveSpot;
        public BitmapImage Image { get; set; }

        public AddZedCreateWindow()
        {
            InitializeComponent();

        }
        private void Re_Roll_Click(object sender, RoutedEventArgs e)
        {
            Character currentCharacter = SquarePointer.Token;
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
            this.Close();

        }
        public Square SquarePointer { get; set; }
    }
}

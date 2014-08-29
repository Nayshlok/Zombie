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
using zombieApocalypse.Model;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame.Shops
{
    public partial class PlayerTrading : Window
    {
        #region Variables
        Player playerLeft, playerRight;
        PlayerItem item;
        string messageBoxText, caption;
        MessageBoxButton button;
        MessageBoxImage icon;
        MessageBoxResult result;
        List<PlayerItem> selectedItemIndexes;
        int initialval, invcheck;
        #endregion

        #region Main
        public PlayerTrading(Player passedInLeft, Player passedInRight)
        {
            InitializeComponent();
            playerLeft = passedInLeft;
            playerRight = passedInRight;
            playerNameLeft.DataContext = playerLeft;
            playerNameRight.DataContext = playerRight;
            playerItemsLeft.ItemsSource = playerLeft.Inventory.getInv();
            playerItemsRight.ItemsSource = playerRight.Inventory.getInv();

            GiveToLeftName.Content = "Give to " + passedInLeft.Name;
            GiveToRightName.Content = "Give to " + passedInRight.Name;
        }
        #endregion

        #region DoubleClickGiveLeft
        private void playerItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to give this item?";
            caption = "Give Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    GiveToLeftName_Click(sender, e);

                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
        #endregion

        #region DoubleClickGiveRight
        private void shopItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to give this item?";
            caption = "Buy Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    GiveToRightName_Click(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion

        #region GiveHandlers
        private void GiveToRightName_Click(object sender, RoutedEventArgs e)
        {

            selectedItemIndexes = new List<PlayerItem>();

            foreach (object o in playerItemsLeft.SelectedItems)
            {
                selectedItemIndexes.Add((PlayerItem)o);
            }
            initialval = playerItemsLeft.SelectedItems.Count;


            invcheck = 0;
            foreach (Weapon wep in playerRight.Inventory.getInv())
            {
                invcheck++;
            }
            foreach (Weapon wep in playerItemsLeft.SelectedItems)
            {
                invcheck++;
            }

                if (playerItemsLeft.SelectedItem == null)
                {
                    MessageBox.Show("Please select and item to give!");
                }
                else
                {
                    if (invcheck < 6)
                    {
                        for (int i = 0; i < initialval; i++)
                        {
                            item = (PlayerItem)playerItemsLeft.SelectedItems[0];
                            playerRight.addToInventory(item);
                            playerLeft.removeFromInventory(selectedItemIndexes[i]);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Cannot exceed 5 weapons!");
                    }
                }

        }

        private void GiveToLeftName_Click(object sender, RoutedEventArgs e)
        {
            selectedItemIndexes = new List<PlayerItem>();

            foreach (object o in playerItemsRight.SelectedItems)
            {
                selectedItemIndexes.Add((PlayerItem)o);
            }
            initialval = playerItemsLeft.SelectedItems.Count;


            invcheck = 0;
            foreach (Weapon wep in playerLeft.Inventory.getInv())
            {
                invcheck++;
            }
            foreach (Weapon wep in playerItemsRight.SelectedItems)
            {
                invcheck++;
            }

            if (playerItemsRight.SelectedItem == null)
            {
                MessageBox.Show("Please select and item to give!");
            }
            else
            {
                if (invcheck < 6)
                {
                    for (int i = 0; i < initialval; i++)
                    {
                        item = (PlayerItem)playerItemsRight.SelectedItems[0];
                        playerLeft.addToInventory(item);
                        playerRight.removeFromInventory(selectedItemIndexes[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot exceed 5 weapons!");
                }
            }
        }
        #endregion
    }
}


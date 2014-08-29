using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using zombieApocalypse.Model.Melee;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame.Shops
{
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : Window
    {
        #region Variables
        string shownBonus, sendbackgold, messageBoxText, caption;
        double bonus, currentgold, totalprice;
        Player currentplayer;
        ObservableCollection<PlayerItem> shopList;
        MessageBoxButton button;
        MessageBoxImage icon;
        MessageBoxResult result;
        int initialval, invcheck;
        List<PlayerItem> selectedItemIndexes;
        #endregion

        #region Main
        public Shop(Player passedIn)
        {
            InitializeComponent();
            currentplayer = passedIn;
            playerCurrency.DataContext = currentplayer;
            playerName.DataContext = currentplayer;
            playerItems.ItemsSource = currentplayer.Inventory.getInv();//THE PLAYERS INVENTORY
            playerPB.DataContext = currentplayer.PB;

            #region Bonus
            if (currentplayer.PB >= 10 && currentplayer.PB <= 16)
                shownBonus = "20%";
            else if (currentplayer.PB >= 17 && currentplayer.PB <= 25)
                shownBonus = "50%";
            else if (currentplayer.PB >= 26)
                shownBonus = "Full Price";
            else
                shownBonus = "None";
            #endregion

            saleBonus.DataContext = shownBonus;

            #region Items
            shopList = new ObservableCollection<PlayerItem>
            {

            //Remove
            //public int Price { get; set; }
            //public int sellPrice { get; set; }
            //from all the Items except PlayerItem Class


            //EVERY ITEM MUST INHERIT FROM THE ITEM CLASS
            //Melee

            //new SurvivalKnife { Weapon = "Survival Knife", Price = 15, sellPrice = (double)15/(double)2, description = "1d6" },
            

            //new SmallCrowbar { Weapon = "Small Crowbar", Price = 20, sellPrice = ((double)20/(double)2), description = "2d6" }
            
            };

            //LargeCrowbar lc = new LargeCrowbar { Name = "Large Crowbar", Price = 35, sellPrice = ((double)35/(double)2), Description = "2d8"};


            //new Item { Name = "Machete", Price = 45, sellPrice = ((double)45/(double)2), Description = "3d6" },
            //new Item { Name = "12-Pound Sludgehammer", Price = 75, sellPrice = ((double)75/(double)2), Description = "2d12" },
            ////Hand Guns
            //new Item { Name = ".22 Sport", Price = 35, sellPrice = ((double)35/(double)2), Description = "2d4" },
            //new Item { Name = "9mm Rogue", Price = 45, sellPrice = ((double)45/(double)2), Description = "3d6" },
            //new Item { Name = "9mm Gangsta", Price = 55, sellPrice = ((double)55/(double)2), Description = "3d6 x2" },
            //new Item { Name = ".45 Defender", Price = 65, sellPrice = ((double)65/(double)2), Description = "4d6" },
            //new Item { Name = ".50 Israeli", Price = 200, sellPrice = ((double)200/(double)2), Description = "5d6" },
            ////Rifles
            //new Item { Name = ".223 Militia", Price = 65, sellPrice = ((double)65/(double)2), Description = "4d6" },
            //new Item { Name = ".556 Desert", Price = 75, sellPrice = ((double)75/(double)2), Description = "4d6 x2" },
            //new Item { Name = ".762 Hunter", Price = 85, sellPrice = ((double)85/(double)2), Description = "5d6" },
            //new Item { Name = ".50 Sniper", Price = 400, sellPrice = ((double)400/(double)2), Description = "6d6 + 10 Damage" },
            ////Shotguns
            //new Item { Name = "12 Guage Farmer", Price = 65, sellPrice = ((double)65/(double)2), Description = "4d6" },
            //new Item { Name = "12 Guage Ronin", Price = 75, sellPrice = ((double)75/(double)2), Description = "4d6 x2" },
            //new Item { Name = "12 Guage Slugger", Price = 90, sellPrice = ((double)90/(double)2), Description = "4d6" },  
            //new Item { Name = "Swat-a-be Special", Price = 300, sellPrice = ((double)200/(double)2), Description = "5d6 x2" },
            ////Ammo
            //new Item { Name = "Pistol Bullet", Price = 2, sellPrice = ((double)2/(double)2), Description = "Bullet for pistol." },
            //new Item { Name = "Rifle Bullet", Price = 4, sellPrice = ((double)4/(double)2), Description = "Bullet for rifle." },
            //new Item { Name = "Shutgun Bullet", Price = 3, sellPrice = ((double)3/(double)2), Description = "Bullet for shutgun." },



            #endregion

            updatePrices();


            shopItems.ItemsSource = shopList;
        }
        #endregion

        #region BuyItemHandler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectedItemIndexes = new List<PlayerItem>();

            foreach (object o in shopItems.SelectedItems)
            {
                selectedItemIndexes.Add((PlayerItem)o);
            }

            invcheck = 0;
            foreach (object wep in currentplayer.Inventory.getInv())
            {
                if(wep is Weapon)
                invcheck++;
            }
            foreach (object wep in shopItems.SelectedItems)
            {
                if (wep is Weapon)
                invcheck++;
            }

            initialval = shopItems.SelectedItems.Count;

            totalprice = 0;
            foreach (object o in selectedItemIndexes)
            {
                totalprice = totalprice + ((PlayerItem)o).getPrice(); //GET ITEM PRICE
            }
            currentgold = currentplayer.Money;

            if (shopItems.SelectedItem == null)
            {
                MessageBox.Show("Please select something to buy!");
            }

            else
            {
                if (invcheck < 6)
                {
                    if (currentgold >= totalprice)
                    {
                        for (int i = 0; i < initialval; i++)
                        {

                            currentplayer.addToInventory(selectedItemIndexes[i]);//ADD TO INVENTORY
                        }
                        currentgold = currentgold - totalprice;

                        sendbackgold = currentgold.ToString();
                        currentplayer.Money = (int)currentgold;
                    }

                    else
                    {
                        MessageBox.Show("Sorry pal, you don't have enough money!");
                    }
                }
                else
                {
                    MessageBox.Show("Failed.. Make sure you do not exceed 5 weapons!");
                }
            }
        }

        #endregion

        #region SellItemHandler
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<PlayerItem> selectedItemIndexes = new List<PlayerItem>();

            foreach (object o in playerItems.SelectedItems)
            {
                selectedItemIndexes.Add((PlayerItem)o);
            }
            double totalprice = 0;
            foreach (object o in playerItems.SelectedItems)
            {
                totalprice = totalprice + ((PlayerItem)o).sellPrice;
            }
            initialval = playerItems.SelectedItems.Count;
            currentgold = currentplayer.Money;

            if (playerItems.SelectedItem == null)
            {
                MessageBox.Show("Please select something to sell!");
            }
            else
            {
                for (int i = 0; i < initialval; i++)
                {
                    currentplayer.removeFromInventory(selectedItemIndexes[i]);//REMOVES FROM INVENTORY

                }
                currentgold = currentgold + totalprice;

                sendbackgold = currentgold.ToString();
                currentplayer.Money = (int)currentgold;
            }
        }
        #endregion

        #region BonusInfo
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("This is the bonus you will get for selling items. You will recieve a " + shownBonus + " bonus on the original sell price on any items you sell. Physical Beauty matters here. Increase it to get higher bonuses!");
        }
        #endregion

        #region DoubleClickSell
        private void playerItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to sell this item?";
            caption = "Sell Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Button_Click_1(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }
        #endregion

        #region DoubleClickBuy
        private void shopItems_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            messageBoxText = "Are you sure you want to buy this item?";
            caption = "Buy Item";
            button = MessageBoxButton.YesNo;
            icon = MessageBoxImage.Warning;
            result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    Button_Click(sender, e);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        #endregion

        #region UpdatePrices
        public void updatePrices()
        {

            for (int i = 0; i < shopList.Count; i++)
            {

                if (currentplayer.PB >= 10 && currentplayer.PB <= 16)
                    bonus = shopList[i].sellPrice * .20;
                else if (currentplayer.PB >= 17 && currentplayer.PB <= 25)
                    bonus = shopList[i].sellPrice * .50;
                else if (currentplayer.PB >= 26 && currentplayer.PB <= 30)
                    bonus = shopList[i].sellPrice;
                else
                    bonus = 0;
                shopList[i].sellPrice = shopList[i].sellPrice + bonus;
            }
            for (int i = 0; i < currentplayer.Inventory.listSize(); i++)
            {

                if (currentplayer.PB >= 10 && currentplayer.PB <= 16)
                    bonus = currentplayer.Inventory.getItem(i).sellPrice * .20;
                else if (currentplayer.PB >= 17 && currentplayer.PB <= 25)
                    bonus = currentplayer.Inventory.getItem(i).sellPrice * .50;
                else if (currentplayer.PB >= 26 && currentplayer.PB <= 30)
                    bonus = currentplayer.Inventory.getItem(i).Price;
                else
                    bonus = 0;
                currentplayer.Inventory.getItem(i).sellPrice = currentplayer.Inventory.getItem(i).sellPrice + bonus;
            }
        }
        #endregion
    }
}
using CedenoB_ZombieGame.Item.Ammo;
using CedenoB_ZombieGame.Item.Item.Model;
using CedenoB_ZombieGame.Item.Model;
using CedenoB_ZombieGame.Items;
using CedenoB_ZombieGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator.Model
{
    [Serializable()]
    public class Inventory
    {
        public Inventory()
        {
            itemList = new ObservableCollection<PlayerItem>();
        }

        public ObservableCollection<PlayerItem> itemList { get; set; }

        public Weapon equippedWeapon { get; set; }
        public List<Weapon> weapons = new List<Weapon>();
        public RifleAmmo RifleAmmo = new RifleAmmo();
        public HandgunAmmo HandgunAmmo = new HandgunAmmo();
        public ShotgunAmmo ShotgunAmmo = new ShotgunAmmo();
        protected int MaxAmmoAmount = 100;

        public void RemoveRifleAmmo(int amount)
        {
            RifleAmmo.Qty -= amount;
        }

        public void RemoveShotgunAmmo(int amount)
        {
            ShotgunAmmo.Qty -= amount;
        }

        public void RemoveHandgunAmmo(int amount)
        {
            HandgunAmmo.Qty -= amount;
        }

        public int GetRifleAmmo()
        {
            return RifleAmmo.Qty;
        }

        public int GetHandgunAmmo()
        {
            return HandgunAmmo.Qty;
        }

        public int GetShotgunAmmo()
        {
            return ShotgunAmmo.Qty;
        }

        public virtual void AddItem(PlayerItem Item)
        {
            if (Item is Weapon)
            {
                Weapon Weapon = (Weapon)Item;
                if (weapons.Count == 5)
                {
                    MessageBox.Show("You cannot exceed 5 weapons!");
                }
                else
                {
                    weapons.Add(Weapon);
                    itemList.Add(Weapon);
                }
            }
            else if (Item is AmmoPack)
            {
                AmmoPack pack = (AmmoPack)Item;
                DetermineAmmoPackType(pack);
                itemList.Add(pack);
            }
        }

        protected void DetermineAmmoPackType(AmmoPack pack)
        {
            if (pack.Type == AmmoType.Handgun)
            {
                if (HandgunAmmo.Qty + pack.Qty > MaxAmmoAmount)
                    HandgunAmmo.Qty = MaxAmmoAmount;
                else
                    HandgunAmmo.Qty += pack.Qty;
            }
            else if (pack.Type == AmmoType.Rifle)
            {
                if (RifleAmmo.Qty + pack.Qty > MaxAmmoAmount)
                    RifleAmmo.Qty = MaxAmmoAmount;
                else
                    RifleAmmo.Qty += pack.Qty;
            }
            else
            {
                if (ShotgunAmmo.Qty + pack.Qty > MaxAmmoAmount)
                    ShotgunAmmo.Qty = MaxAmmoAmount;
                else
                    ShotgunAmmo.Qty += pack.Qty;
            }
        }





    }
}

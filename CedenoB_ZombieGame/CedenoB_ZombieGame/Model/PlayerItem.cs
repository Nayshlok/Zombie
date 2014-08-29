using CedenoB_ZombieGame;
using CedenoB_ZombieGame.Item.Ammo;
using CedenoB_ZombieGame.Item.Items.Ammo;
using CedenoB_ZombieGame.Items.Handguns;
using CedenoB_ZombieGame.Items.Rifles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator.Model;
using CedenoB_ZombieGame.Model;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class PlayerItem : Entity
    {

        //Bryan ADDED CODE
        public string Weapon { get; set; }
        public double Price { get; set; }
        public double sellPrice { get; set; }
        public string description { get; set; }
        public double getPrice()
        {
            return this.Price;
        }
        //Bryan ADDED CODE
        private GunAmmo DetermineAmmoPackType(GunAmmo ammo, int amount, Character character)
        {
            if (ammo.Type == AmmoType.Handgun)
            {
                if (character.Inventory.GetHandgunAmmo() >= amount)
                {
                    character.Inventory.RemoveHandgunAmmo(amount);
                    return new HandgunAmmoPack(amount);
                }
            }
            else if (ammo.Type == AmmoType.Rifle)
            {
                if (character.Inventory.GetRifleAmmo() >= amount)
                {
                    character.Inventory.RemoveRifleAmmo(amount);
                    return new RifleAmmoPack(amount);
                }
            }
            else
            {
                if (character.Inventory.GetShotgunAmmo() >= amount)
                {
                    character.Inventory.RemoveShotgunAmmo(amount);
                    return new ShotgunAmmoPack(amount);
                }
            }

            return null;
        }
    }
}

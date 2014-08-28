using CedenoB_ZombieGame.Item.Ammo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame.Item.Items.Ammo
{
    public abstract class GunAmmo : PlayerItem
    {
        const int MAX_ROUNDS = 100;
        private int _qty;

        public int Qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                OnPropertyChanged("Qty");
            }

        }
        public AmmoType Type { get; protected set; }
    }
}
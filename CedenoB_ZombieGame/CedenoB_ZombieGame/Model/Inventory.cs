using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zombieApocalypse.Model;

namespace ZombieApocalypseSimulator
{
    [Serializable()]
    public class Inventory
    {
        public ObservableCollection<CedenoB_ZombieGame.Item> list = new ObservableCollection<CedenoB_ZombieGame.Item>();

        public Weapon equippedWeapon { get; set; }
    }
}

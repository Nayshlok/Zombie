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
        ObservableCollection<Item> list = new ObservableCollection<Item>();

        public Weapon equippedWeapon { get; set; }
    }
}

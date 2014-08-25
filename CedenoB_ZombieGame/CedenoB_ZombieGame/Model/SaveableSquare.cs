using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ZombieApocalypseSimulator;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
    public class SaveableSquare
    {
        private List<Item> _Items = new List<Item>();
        public List<Item> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }        
        public Character Token { get; set; }
        bool _isOpen = false;
        //public Delegates.SelectCharacter PassCharacter { get; set; }
        public string imagePath { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsOpen
        {
            get
            {
                if (Token == null)
                {
                    _isOpen = true;
                }
                else
                {
                    _isOpen = false;
                }

                return _isOpen;
            }
            set
            {
                _isOpen = value;
            }
        }

    }
}

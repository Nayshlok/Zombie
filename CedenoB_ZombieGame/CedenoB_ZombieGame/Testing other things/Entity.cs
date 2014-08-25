using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CedenoB_ZombieGame
{
    public abstract class Entity : INotifyPropertyChanged
    {
        private string _name;
        private ImageSource _profileImageSource;

        public Point Coordinate { get; set; }

        public ImageSource GameImageSource { get; set; }
        public ImageSource ProfileImageSource
        {
            get { return _profileImageSource; }
            set
            {
                _profileImageSource = value;
                OnPropertyChanged("ProfileImageSource");
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using CedenoB_ZombieGame.Model;
using ZombieApocalypseSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CedenoB_ZombieGame
{
   public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            BitmapImage returnImage = new BitmapImage();
            if (value is Character)
            {
                if (value is Warrior)
                {
                    returnImage = new BitmapImage(new Uri("Images/Warrior.png", UriKind.Relative));
                }
            }
            else if (value is PlayerItem)
            {

            }

            return returnImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ACS_Training.Classes
{
    class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return (object)null;
            if (value is string)
                return (object)new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));
            if (value is Uri)
                return (object)new BitmapImage((Uri)value);
            return (object)null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (object)null;
        }
    }
}

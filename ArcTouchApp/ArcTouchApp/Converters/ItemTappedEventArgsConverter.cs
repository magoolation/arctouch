using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArcTouchApp.Converters
{
    public class ItemTappedEventArgsConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var args = value as ItemTappedEventArgs;
            if(args != null)
            {
                return args.Item;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

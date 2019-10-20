using System;
using System.Globalization;
using Xamarin.Forms;

namespace Barbital.Converters
{
    internal class CarouselPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)parameter ? value : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
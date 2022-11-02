using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CarService.Converters
{
    public class IsVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType().Name == "NamedObject"
                ? Visibility.Hidden
                : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Globalization;
using System.Windows;

namespace DnDAssistant.Wpf
{
    public class InvertedBooleanToVisibilityConverter : BaseValueConverter<InvertedBooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value == true) ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

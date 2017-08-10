using System;
using System.Globalization;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class IconTypeToMarginConverter : BaseValueConverter<IconTypeToMarginConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IconType)value == IconType.None) ? new Thickness(0, 0, 0, 0) : new Thickness(0, 0, 5, 0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

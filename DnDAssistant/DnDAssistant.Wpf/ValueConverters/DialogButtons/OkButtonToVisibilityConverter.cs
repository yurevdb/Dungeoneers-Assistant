using System;
using System.Globalization;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class OkButtonToVisibilityConverter : BaseValueConverter<OkButtonToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((Buttons)value == Buttons.Ok) ? Visibility.Visible : Visibility.Collapsed;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

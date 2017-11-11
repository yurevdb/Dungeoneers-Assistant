using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Only use this for an <see cref="ObservableCollection{T}"/>
    /// </summary>
    public class CountToVisibilityConverter : BaseValueConverter<CountToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (((ObservableCollection<NavigationMenuItemViewModel>)value).Count <= 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

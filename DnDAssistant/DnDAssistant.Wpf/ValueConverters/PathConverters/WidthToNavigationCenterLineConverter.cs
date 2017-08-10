using System;
using System.Globalization;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Returns a center line of the <see cref="NavigationMenu"/>
    /// </summary>
    public class WidthToNavigationCenterLineConverter : BaseValueConverter<WidthToNavigationCenterLineConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the width and height of the navigationmenu
            var width = (value as NavigationMenu).ActualWidth;
            var height = (value as NavigationMenu).ActualHeight;
            
            // Return the design as the path data
            // -5 for the border thickness
            return $"M {(width / 2) - 3 -5},0 L{(width / 2) - 3 - 5},{height} L{(width / 2) + 3 - 5},{height} L{(width / 2) + 3 - 5},0";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

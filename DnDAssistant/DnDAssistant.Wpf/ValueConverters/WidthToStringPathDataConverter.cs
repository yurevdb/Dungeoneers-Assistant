using System;
using System.Globalization;
using System.Windows;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Returns the colored design in the title bar, depending on the width of the window
    /// </summary>
    public class WidthToStringPathDataConverter : BaseValueConverter<WidthToStringPathDataConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the width of the window in the current state
            var width = (double)value;

            // Get the state of the window (this is because the non-maximized window has a padded border)
            var windowState = Application.Current.MainWindow.WindowState;
            
            // Return the design as the path data
            // 93 and 100 are from the side designs
            return (windowState == WindowState.Maximized) ? $"M 93,0 L{width - 93},0 L{width - 100},7 L100,7 L93,0": $"M 93,0 L{width - 93 - 20},0 L{width - 100 - 20},7 L100,7 L93,0";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

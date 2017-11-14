using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DnDAssistant.Wpf
{
    public class BooleanToStrokeConverter : BaseValueConverter<BooleanToStrokeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value == true) ? Application.Current.Resources["BronzeBrush"] : new SolidColorBrush(new Color { A = 0 });
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

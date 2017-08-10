using System;
using System.Globalization;
using System.Windows.Media;

namespace DnDAssistant.Wpf
{
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new BrushConverter().ConvertFromString($"#{value as string}") as SolidColorBrush;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

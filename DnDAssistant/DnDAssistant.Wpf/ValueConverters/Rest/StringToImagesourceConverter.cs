using System;
using System.Globalization;

namespace DnDAssistant.Wpf
{
    public class StringToImagesourceConverter : BaseValueConverter<StringToImagesourceConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"pack://siteoforigin:,,,/Resources/{value as string}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

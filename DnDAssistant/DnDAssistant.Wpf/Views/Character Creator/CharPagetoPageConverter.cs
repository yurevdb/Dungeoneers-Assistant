using System;
using System.Globalization;

namespace DnDAssistant.Wpf
{
    public class CharPagetoPageConverter : BaseValueConverter<CharPagetoPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((CharPages)value)
            {
                case CharPages.Statspage:
                    return new CharPage();
                default:
                    return new CharPage();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

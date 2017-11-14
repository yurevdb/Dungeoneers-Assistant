using System;
using System.Globalization;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class ErrottypeToFontAwesomeFontConverter : BaseValueConverter<ErrottypeToFontAwesomeFontConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((ErrorType)value >= ErrorType.Warning) ? Application.Current.Resources["FontAwesomeWarningIcon"] : Application.Current.Resources["FontAwesomeEnvelopIcon"];
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

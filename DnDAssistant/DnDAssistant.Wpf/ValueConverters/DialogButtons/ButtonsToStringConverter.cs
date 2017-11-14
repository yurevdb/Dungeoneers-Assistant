using System;
using System.Globalization;

namespace DnDAssistant.Wpf
{
    public class ButtonsToStringConverter : BaseValueConverter<ButtonsToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (string)parameter;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

    }
}

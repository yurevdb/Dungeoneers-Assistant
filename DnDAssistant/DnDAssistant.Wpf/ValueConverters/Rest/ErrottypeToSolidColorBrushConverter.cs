using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class ErrottypeToSolidColorBrushConverter : BaseValueConverter<ErrottypeToSolidColorBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ErrorType type)
            {
                switch (type)
                {
                    case ErrorType.Message:
                        return new BrushConverter().ConvertFromString(Application.Current.Resources["BlueBrush"].ToString());
                    case ErrorType.Warning:
                        return new BrushConverter().ConvertFromString(Application.Current.Resources["BronzeBrush"].ToString());
                    case ErrorType.Error:
                        return new BrushConverter().ConvertFromString(Application.Current.Resources["LightRedBrush"].ToString());
                    default:
                        return new BrushConverter().ConvertFromString(Application.Current.Resources["BlueBrush"].ToString());
                }
            }

            // if it's not an errortype (should never happen) return black
            return new BrushConverter().ConvertFromString("000000");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

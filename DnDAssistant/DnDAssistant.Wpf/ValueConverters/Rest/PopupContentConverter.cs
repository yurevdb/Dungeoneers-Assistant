using System;
using System.Globalization;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ApplicationMenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup.Content };

            return null;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

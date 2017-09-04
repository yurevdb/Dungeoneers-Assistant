using System;
using System.Globalization;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class CharacterCreatorPageToPageConverter : BaseValueConverter<CharacterCreatorPageToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((CreatorPage)value)
            {
                case CreatorPage.BasicInfo:
                    return new CharacterCreatorPage();
                default:
                    return new CharacterCreatorPage();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

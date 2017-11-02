using System;
using System.Globalization;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class CampaignHostWindowsToPageConverter : BaseValueConverter<CampaignHostWindowsToPageConverter>
    {
        private int _Passes = 0;

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _Passes++;
            switch((CampaignHostWindows)value)
            {
                case CampaignHostWindows.Selector:
                    return (_Passes <= 1) ?  new Selector(): new Selector { PageLoadAnimation = Animation.SlideAndFadeInFromTop };
                case CampaignHostWindows.Creator:
                    return new Creator();
                default:
                    return new Selector();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

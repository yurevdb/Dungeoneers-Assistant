using System;
using System.Globalization;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class ApplicationPageToPageConverter : BaseValueConverter<ApplicationPageToPageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Test:
                    return new TestPage();
                case ApplicationPage.Startup:
                    return new StartupPage();
                case ApplicationPage.CharacterCreator:
                    return new CharacterCreatorPage();
                case ApplicationPage.DMTools:
                    return new DMToolsPage();
                case ApplicationPage.DiceRoller:
                    return new Dice_Roller();
                default:
                    return new TestPage();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Dice_Roller.xaml
    /// </summary>
    public partial class Dice_Roller : BasePage
    {
        public Dice_Roller()
        {
            InitializeComponent();
            DataContext = new WidgetViewModel
            {
                Image = "pack://siteoforigin:,,,/Resources/d20.png",
                Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel { Message = "It works.", Title = "Click test", Buttons = Buttons.Ok }))
            };
        }
    }
}

using System.Windows.Controls;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for ControlHub.xaml
    /// </summary>
    public partial class ControlHub : UserControl
    {
        public ControlHub()
        {
            InitializeComponent();
            DataContext = IoC.App.Campaign;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //IoC.UI.ShowMessage(new DialogViewModel { Message = "Hello", OkText = "Click Me", Title = "Ola" });
            IoC.App.CampaignMenuVisible ^= true;
        }
    }
}

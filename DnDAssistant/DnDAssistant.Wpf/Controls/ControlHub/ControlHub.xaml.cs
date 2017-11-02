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
            DataContext = new ControlHubViewModel { Campaign = IoC.App.Campaign };
        }
    }
}

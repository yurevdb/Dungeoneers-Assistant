using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// The page containing the basic information in the basic character generator
    /// </summary>
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
            DataContext = new BasicCreatorViewModel();
        }
    }
}

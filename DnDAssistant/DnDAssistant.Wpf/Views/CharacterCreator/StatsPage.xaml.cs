using System.Windows.Controls;

namespace DnDAssistant.Wpf.Views.CharacterCreator
{
    /// <summary>
    /// The page containing the basic information in the basic character generator
    /// </summary>
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
            DataContext = new ViewModels.BasicCreatorViewModel();
        }
    }
}

using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for StartupPage.xaml
    /// </summary>
    public partial class StartupPage : BasePage
    {
        public StartupPage()
        {
            InitializeComponent();
            DataContext = IoC.Widgets;
            if(IoC.Widgets.Widgets.Count <= 0)
                IoC.Widgets.Setup();
        }
    }
}

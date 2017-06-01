using System.Windows;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the datacontext of the window to the windowviewmodel
            DataContext = new WindowViewModel(this);
        }
    }
}

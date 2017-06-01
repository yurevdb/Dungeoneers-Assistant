using System.Windows;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom start up so we load our IoC before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let it do it's thang
            base.OnStartup(e);

            // Create the main window
            Current.MainWindow = new MainWindow();

            // Show the main window
            Current.MainWindow.Show();
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using DnDAssistant.Core;
using HtmlAgilityPack;

namespace DnDAssistant.Wpf
{
    internal delegate void Invoker();

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Splash Screen

        public App()
        {
            _ApplicationInitialize = _applicationInitialize;
        }

        public static new App Current => Application.Current as App;

        internal delegate void ApplicationInitializeDelegate(Splash splashWindow);
        internal ApplicationInitializeDelegate _ApplicationInitialize;

        private void _applicationInitialize(Splash splashWindow)
        {
            // Check the apllication version
            CheckVersion();

            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate
            {
                MainWindow = new CampaignHostWindow();
                MainWindow.Show();
            });
        } 

        #endregion

        /// <summary>
        /// Custom start up so we load our IoC before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let it do it's thang
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();

            // Create the main window
            Current.MainWindow = new Splash();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configure the application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            // Setup the binding of the solution wide accessible viewmodels
            IoC.Setup();

            // Check if the appdata folder is set up for the application
            SetupAppdata();

            // Bind the ui manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }

        /// <summary>
        /// Sets up the folder structure for the application data
        /// </summary>
        private void SetupAppdata()
        {
            // If the directory for the appdata does not exist...
            if (!Directory.Exists(IoC.App.BaseDataPath))
                // Create the directory
                Directory.CreateDirectory(IoC.App.BaseDataPath);

            // Add more directories if needed here
        }

        /// <summary>
        /// Checks if the current application is the latest version
        /// </summary>
        private void CheckVersion()
        {
            // Get the assembly Version of this application
            var currentVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

            // to get the latest release of the application https://github.com/yurevdb/Dungeoneers-Assistant/releases/latest
            // Get the latest assembly Version

            // The url to the latest release version of the application
            var source = "https://github.com/yurevdb/Dungeoneers-Assistant/releases/latest";

            // Create the necessary objects
            HtmlNode versionSpan = null;
            Version latestVersion = null;

            try
            {
                // Search the html for a span
                // Search for a span with the class of "css-truncate-target" (this is the span that shows the version number)
                // Get the first for easy access
                versionSpan = new HtmlWeb().Load(source).DocumentNode?.Descendants("span").Where(d => d.Attributes["class"]?.Value.Contains("css-truncate-target") == true).First();

                // Create the Version object of the latest version
                latestVersion = new Version(versionSpan?.InnerHtml);
            }
            catch
            {
                //TODO: Error Handling for no internet connection, oh so sad :(
            }

            if (latestVersion == null)
                return;

            // Do the checks
            if(currentVersion == latestVersion)
            {
                // TODO: let user know that the latest version is installed
            }
            else if(latestVersion > currentVersion)
            {
                // TODO: do what needs to be done to let the user know that the current version of the application is not the latest version
            }
        }
    }
}

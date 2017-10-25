using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        public Splash()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Splash_Loaded);
        }

        void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            IAsyncResult result = null;

            // This is an anonymous delegate that will be called when the initialization has COMPLETED
            AsyncCallback initCompleted = delegate (IAsyncResult ar)
            {
                App.Current._ApplicationInitialize.EndInvoke(result);

                // Ensure we call close on the UI Thread.
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate { Close(); });
            };

            // This starts the initialization process on the Application
            result = App.Current._ApplicationInitialize.BeginInvoke(this, initCompleted, null);
        }

        /// <summary>
        /// Sets the progress to the given value
        /// </summary>
        /// <param name="progress">The value of the progress</param>
        public void SetProgress(int progress)
        {
            Dispatcher.Invoke(() => { Prog.Value = progress; });
        }
    }
}

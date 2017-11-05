using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Splash()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Splash_Loaded);
            DataContext = IoC.Splash;
        }

        /// <summary>
        /// Loaded event for the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            IAsyncResult result = null;

            // This is an anonymous delegate that will be called when the initialization has COMPLETED
            AsyncCallback initCompleted = delegate (IAsyncResult ar)
            {
                App.Current._ApplicationInitialize.EndInvoke(result);

                // Ensure we call close on the UI Thread.
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate
                {
                    // Fade out the window
                    var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(1));
                    anim.Completed += (s, _) => Close();
                    BeginAnimation(OpacityProperty, anim);
                });
            };

            // This starts the initialization process on the Application
            result = App.Current._ApplicationInitialize.BeginInvoke(this, initCompleted, null);
        }
    }
}

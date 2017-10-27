using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for CampaignSelect.xaml
    /// </summary>
    public partial class CampaignSelect : Window
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CampaignSelect()
        {
            InitializeComponent();

            // Event to animate in the content of the window
            Loaded += CampaignSelect_LoadedAsync;
        }

        /// <summary>
        /// Event handler for the animating of the content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CampaignSelect_LoadedAsync(object sender, RoutedEventArgs e)
        {
            await Animations.FadeInAsync(tbInspirationText, 2.5f);
        }

        /// <summary>
        /// Creates the <see cref="MainWindow"/>, opens it and closes this window
        /// </summary>
        private void OpenMainWindow()
        {
            var w = new MainWindow();
            w.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenMainWindow();
        }

        /// <summary>
        /// Event handler to animate out this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Remove Window_Closing event to prevent endless loop
            Closing -= Window_Closing;

            // Cancel the closing of the window
            e.Cancel = true;

            // Make topmost so the window is visible during the animation
            Topmost = true;

            // Create the fade out animation
            var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(1));

            // When the animation is completed, close the window
            anim.Completed += (s, _) => Close();

            // Begin the animation
            BeginAnimation(OpacityProperty, anim);
        }
    }
}

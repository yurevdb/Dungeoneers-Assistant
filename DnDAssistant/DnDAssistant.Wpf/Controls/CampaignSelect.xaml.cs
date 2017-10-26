using System;
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
            await Animations.FadeInAsync(btn, 1f);
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
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(1));
            anim.Completed += (s, _) => Close();
            BeginAnimation(OpacityProperty, anim);
        }
    }
}

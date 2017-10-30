using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for CampaignCreator.xaml
    /// </summary>
    public partial class CampaignCreator : Window
    {
        private CampaignSelect _Parent;

        public CampaignCreator(Window parent)
        {
            InitializeComponent();
            _Parent = parent as CampaignSelect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Content == "X")
            {
                Close();
                return;
            }

            // Create a new Campaign with the given data
            var nc = new CampaignViewModel
            {
                Name = tbxName.Text,
                Description = tbxDescription.Text,
                Role = (bool)cbRole.IsChecked ? CampaingRole.DungeonMaster : CampaingRole.Player,
            };

            // Setup the campaign structure on the computer
            nc.Setup();

            // Set it as the Campaign of the Application
            IoC.App.SetCampaign(nc);

            // Open the Application, close the parent
            _Parent.OpenMainWindow();
            // Close this window
            Close();
        }

        #region Window Event Handlers
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(1, TimeSpan.FromMilliseconds(400));

            BeginAnimation(OpacityProperty, anim);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            // Remove Window_Closing event to prevent endless loop
            Closing -= Window_Closing;

            // Cancel the closing of the window
            e.Cancel = true;

            // Make topmost so the window is visible during the animation
            Topmost = true;

            // Create the fade out animation
            var anim = new DoubleAnimation(0, TimeSpan.FromMilliseconds(400));

            // When the animation is completed, close the window
            anim.Completed += (s, _) => Close();

            // Begin the animation
            BeginAnimation(OpacityProperty, anim);
        } 
        #endregion
    }
}

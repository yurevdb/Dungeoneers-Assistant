using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DnDAssistant.Core;

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
            // Fade in the text
            await Task.WhenAll(Animations.FadeInAsync(tbInspirationText, 2f), Task.Run(() => Dispatcher.Invoke(() =>GetCampaigns())));

            // Execute multiple Tasks in parallel
            // Fading in the listview and sliding the text
            await Task.WhenAll(Animations.SlideAsync(tbInspirationText, SlideDirection.Right, 400, 2f), Animations.FadeInAsync(lvCampaigns, 3f));
        }

        private void GetCampaigns()
        {
            // Add ListviewItems for every campaign saved on the computer
            foreach(var f in Directory.GetDirectories(IoC.App.BaseDataPath))
            {
                //TODO: get extra info from the config.xml file in the campaign directory (still needs to be added)
                var campaignVM = new XmlStream().Deserialize<CampaignViewModel>($"{f}\\config.xml");

                var lvi = new ListViewItem
                {
                    DataContext = campaignVM,
                };

                lvi.MouseDoubleClick += Lvi_MouseDoubleClick;

                lvCampaigns.Items.Add(lvi);
            }

            // Add the ListviewItem to add a new Campaign
            var newCampaignVM = new CampaignViewModel { Name = "New Campaign", Description = "Opens the window to create a new Campaign." };
            var nc = new ListViewItem { DataContext = newCampaignVM };
            nc.MouseDoubleClick += Lvi_MouseDoubleClick;
            lvCampaigns.Items.Add(nc);
        }

        private void Lvi_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the sender as a ListViewItem
            var lvi = (sender as ListViewItem).DataContext as CampaignViewModel;

            // If the ListViewItem is the New Campaign
            // Create a New Campaign
            if(lvi.Name == "New Campaign")
            {
                // Open the "Create New Campaign"view
                // And go to the MainWindow for that campaign

                var cc = new CampaignCreator(this)
                {
                    Owner = this
                };
                cc.Show();

                return;
            }
            
            // Setup the Campaign ViewModel
            IoC.App.SetCampaign(lvi);

            // Open the Window
            OpenMainWindow();
        }

        /// <summary>
        /// Creates the <see cref="MainWindow"/>, opens it and closes this window
        /// </summary>
        public void OpenMainWindow()
        {
            new MainWindow().Show();
            Close();
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

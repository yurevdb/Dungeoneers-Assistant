using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using DnDAssistant.Core;
using Microsoft.Win32;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for CampaignCreator.xaml
    /// </summary>
    public partial class CampaignCreator : Window
    {
        private CampaignSelect _Parent;
        private string _ImageName;
        private Bitmap _Image;

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

            if (!(_Image == null))
                nc.ImageURI = $"{IoC.App.BaseDataPath}\\{tbxName.Text}\\Resources\\{_ImageName}";

            // Setup the campaign structure on the computer
            nc.Setup();

            // Save the selected image, if one was selected
            if(!(_Image == null))
                _Image.Save($"{IoC.App.ResourcePath}\\{_ImageName}");

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

        /// <summary>
        /// Event handler for the add photo button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            // Create a OpenFileDialog to open a file, duh
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "Choose Image",
                Multiselect = false
            };

            // Open the ofd and if nothing was selected, do fuck all
            if (ofd.ShowDialog() == false) return;

            _Image = new Bitmap(ofd.FileName);
            _ImageName = ofd.FileName.Split('\\').Last();
        }
    }
}

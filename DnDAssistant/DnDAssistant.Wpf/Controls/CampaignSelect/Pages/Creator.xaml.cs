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
    /// Interaction logic for Creator.xaml
    /// </summary>
    public partial class Creator : BasePage
    {
        private string _ImageName;
        private Bitmap _Image;
        private Window _Window;

        public Creator()
        {
            InitializeComponent();

            PageLoadAnimation = Animation.SlideAndFadeInFromBottom;
            PageUnloadAnimation = Animation.SlideAndFadeOutToBottom;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)(sender as Button).Content == "X")
            {
                IoC.App.GoTo(CampaignHostWindows.Selector);
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
            if (!(_Image == null))
                _Image.Save($"{IoC.App.ResourcePath}\\{_ImageName}");

            // Set it as the Campaign of the Application
            IoC.App.SetCampaign(nc);

            OpenMainWindow();
        }

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

        /// <summary>
        /// Creates the <see cref="MainWindow"/>, opens it and closes this window
        /// </summary>
        public void OpenMainWindow()
        {
            _Window = Application.Current.MainWindow as Window;
            var mw = new MainWindow();
            Application.Current.MainWindow = mw;
            mw.Show();
            AnimateOut();
        }

        /// <summary>
        /// Animate out the window
        /// </summary>
        private void AnimateOut()
        {
            // Make topmost so the window is visible during the animation
            _Window.Topmost = true;

            _Window.ShowInTaskbar = false;

            // Create the fade out animation
            var anim = new DoubleAnimation(0, TimeSpan.FromSeconds(1));

            // When the animation is completed, close the window
            anim.Completed += (s, _) => _Window.Close();

            // Begin the animation
            _Window.BeginAnimation(OpacityProperty, anim);
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
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

        public ICommand Click { get; set; }

        public Creator()
        {
            InitializeComponent();

            // Page Animations
            PageLoadAnimation = Animation.SlideAndFadeInFromBottom;
            PageUnloadAnimation = Animation.SlideAndFadeOutToBottom;

            // CLick command
            Click = new RelayCommand(() => AddPhoto());
            DataContext = Click;
            
            // Image Source
            imgCampaign.ImageSource = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/dnd.jpg"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tbxName.Text == "" || IsInUse(tbxName.Text))
            {
                IoC.UI.ShowMessage(new DialogViewModel
                {
                    Title = "Error",
                    Buttons = Buttons.Ok,
                    Message = (tbxName.Text == "") ? "Please enter a name for your campaign." : "A campaign with that name already exists."
                });
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

            // Add the campaign to the list
            IoC.CampaignSelector.AddCampaign(new CampaignListItemViewModel
            {
                Name = nc.Name,
                Description = nc.Description,
                Role = nc.Role,
                ImageURI = nc.ImageURI,
                ShowDeleteButton = true
            });

            // Save the selected image, if one was selected
            if (!(_Image == null))
                _Image.Save($"{IoC.App.ResourcePath}\\{_ImageName}");

            // Set it as the Campaign of the Application
            IoC.App.SetCampaignAsync(nc);

            OpenMainWindow();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            IoC.App.GoToAsync(CampaignHostWindows.Selector);
            return;
        }

        /// <summary>
        /// Check wether the name is already been used for a campaign
        /// </summary>
        /// <param name="Name">The name to check</param>
        /// <returns><see cref="bool"/></returns>
        private bool IsInUse(string Name)
        {
            foreach(var file in Directory.GetDirectories(IoC.App.BaseDataPath))
            {
                if (Name == file.Split('\\').Last())
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Event handler for the add photo button
        /// </summary>
        private void AddPhoto()
        {
            // Create a OpenFileDialog to open a file, duh
            var ofd = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Title = "Choose Image",
                Multiselect = false,
                Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*"
            };

            // Open the ofd and if nothing was selected, do fuck all
            if (ofd.ShowDialog() == false) return;

            GetImage(ofd.FileName);
        }

        private void GetImage(string imagePath)
        {
            //Original image
            var preImage = new Bitmap(imagePath);
            //Scaling factor
            var dwdh = (double)preImage.Height / (double)preImage.Width;
            //Scaled image
            _Image = new Bitmap(preImage, 48, (int)(48 * dwdh));
            //Preview image
            imgCampaign.ImageSource = new BitmapImage(new Uri(imagePath));
            //Name to set in the viewmodel
            _ImageName = imagePath.Split('\\').Last();
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

        private void Ellipse_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                GetImage(files[0]);
            }
        }
    }
}

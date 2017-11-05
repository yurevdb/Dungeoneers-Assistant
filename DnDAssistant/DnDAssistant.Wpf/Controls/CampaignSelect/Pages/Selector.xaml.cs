using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : BasePage
    {
        private Window _Window;

        private bool _First = true;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Selector()
        {
            InitializeComponent();

            PageLoadAnimation = (_First) ?  Animation.None : Animation.SlideAndFadeInFromTop;
            PageUnloadAnimation = Animation.SlideAndFadeOutToTop;

            DataContext = IoC.CampaignSelector;

            // Event to animate in the content of the window
            Loaded += CampaignSelect_LoadedAsync;

            _First = false;

            
        }

        /// <summary>
        /// Event handler for the animating of the content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CampaignSelect_LoadedAsync(object sender, RoutedEventArgs e)
        {
            // Fade in the text
            //await Task.WhenAll(Animations.FadeInAsync(tbInspirationText, 2f), Task.Run(() => Dispatcher.Invoke(() => GetCampaigns())));
            await Animations.FadeInAsync(tbInspirationText, 2f);

            // Execute multiple Tasks in parallel
            // Fading in the listview and sliding the text
            await Task.WhenAll(Animations.SlideAsync(tbInspirationText, SlideDirection.Right, 400, 2f), Animations.FadeInAsync(lvCampaigns, 3f));
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}

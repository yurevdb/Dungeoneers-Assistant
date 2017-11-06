using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Selector.xaml
    /// </summary>
    public partial class Selector : BasePage
    {
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
            //await Animations.SlideAsync(tbInspirationText, SlideDirection.Right, 400, 2f);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}

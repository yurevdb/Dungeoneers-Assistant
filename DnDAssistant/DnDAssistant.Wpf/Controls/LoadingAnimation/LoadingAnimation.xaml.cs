using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for SplashAnimation.xaml
    /// </summary>
    public partial class LoadingAnimation : UserControl
    {
        
        public LoadingAnimation()
        {
            InitializeComponent();

            //Animate the things
            GroupAnimations.FadeAsync(8, rectTop, rectRight, rectBottom, rectLeft);
        }
    }
}

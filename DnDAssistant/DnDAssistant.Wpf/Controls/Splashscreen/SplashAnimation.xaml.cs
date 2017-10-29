using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for SplashAnimation.xaml
    /// </summary>
    public partial class SplashAnimation : UserControl
    {
        public SplashAnimation()
        {
            InitializeComponent();

            //Animate the things
            GroupAnimations.FadeAsync(8, rectTop, rectRight, rectBottom, rectLeft);
        }
    }
}

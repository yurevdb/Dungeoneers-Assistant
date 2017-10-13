namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for CharPage.xaml
    /// </summary>
    public partial class CharPage : BasePage
    {
        public CharPage()
        {
            InitializeComponent();

            // The page animation options
            PageLoadAnimation = Animation.None;
            PageUnloadAnimation = Animation.None;
            SlideSeconds = 0f;
        }
    }
}

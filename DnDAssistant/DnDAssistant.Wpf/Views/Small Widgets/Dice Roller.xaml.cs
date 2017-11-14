namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for Dice_Roller.xaml
    /// </summary>
    public partial class Dice_Roller : BasePage
    {
        public Dice_Roller()
        {
            InitializeComponent();
        }

        private async void BtnRoll_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            await Animations.SpinAnimationAsync(image, 45, 5);
        }
    }
}

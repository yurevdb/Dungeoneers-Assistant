using System.Threading.Tasks;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// The application implementation of the <see cref="IUIManager"/>
    /// </summary>
    public class UIManager : IUIManager
    {
        private Window _Window;

        /// <summary>
        /// Opens the given window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public void OpenWindow(Windows window)
        {
            switch (window)
            {
                case Windows.Main:
                    var mw = new MainWindow();
                    _Window = Application.Current.MainWindow;
                    Application.Current.MainWindow = mw;
                    mw.Show();
                    AnimateOutAsync(_Window);
                    break;
                case Windows.CampaignSelector:
                    var cs = new CampaignHostWindow();
                    _Window = Application.Current.MainWindow;
                    Application.Current.MainWindow = cs;
                    cs.Show();
                    AnimateOutAsync(_Window);
                    break;
                default:
                    Application.Current.MainWindow = new CampaignHostWindow();
                    break;
            }
        }

        /// <summary>
        /// Animate out the window
        /// </summary>
        private async void AnimateOutAsync(Window window)
        {
            // Make topmost so the window is visible during the animation
            window.Topmost = true;

            await window.FadeOutAsync(0.7f);

            window.Close();
        }

        /// <summary>
        /// Display a dialog window for the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(DialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);
        }

        /// <summary>
        /// Displays a dialog window for the user, options will give a response to the program
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public DialogResponse ShowResponseMessage(DialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowResponseDialog(viewModel).Result;
        }
    }
}

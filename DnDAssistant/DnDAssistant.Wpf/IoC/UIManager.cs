using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
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
        public void OpenWindow(WindowsViewModel viewModel)
        {
            switch (viewModel.Window)
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

            window.ShowInTaskbar = false;

            await window.FadeOutAsync(1);

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
    }
}

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

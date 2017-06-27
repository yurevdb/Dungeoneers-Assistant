using System.Windows;
using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A viewmodel for the custom window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {
        #region Public Properties

        /// <summary>
        /// The title for the dialog window
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The content to host inside the dialog window
        /// </summary>
        public Control Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window)
        {
            TitleHeight = 30;
            WindowRadius = 10;
        }

        #endregion
    }
}

using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for NavigationMenuItemContextMenuViewModel
    /// </summary>
    public class NavigationMenuItemContextMenuViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The text in the context menu
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The click action for the context menu
        /// </summary>
        public ICommand Click { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NavigationMenuItemContextMenuViewModel()
        {

        }

        #endregion

    }
}

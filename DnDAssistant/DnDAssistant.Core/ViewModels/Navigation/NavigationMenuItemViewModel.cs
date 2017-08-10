using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for the navigation menu items
    /// </summary>
    public class NavigationMenuItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The action for a click command to the navigation menu item
        /// </summary>
        public ICommand Click { get; set; }

        /// <summary>
        /// The title of the navigation menu item
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationMenuItemViewModel()
        {

        }

        #endregion
    }
}

using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for a menu
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        /// <summary>
        /// The text to display for the menu item
        /// </summary>
        public List<MenuItemViewModel> Items { get; set; }
    }
}

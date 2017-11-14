using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for a menu item
    /// </summary>
    public class MenuItemViewModel : BaseViewModel
    {
        /// <summary>
        /// The text to display for the menu item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The icon for this menu item
        /// </summary>
        public IconType Icon { get; set; }

        /// <summary>
        /// The type of this menu item
        /// </summary>
        public MenuItemType Type { get; set; }

        /// <summary>
        /// The tooltip to show for the item
        /// </summary>
        public string ToolTip { get; set; } = string.Empty;

        /// <summary>
        /// The click command action. This will have to be set for each menu item seperatly
        /// </summary>
        public ICommand Click { get; set; }
    }
}

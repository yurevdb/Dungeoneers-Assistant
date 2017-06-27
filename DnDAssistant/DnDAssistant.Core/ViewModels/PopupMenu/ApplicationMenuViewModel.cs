using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class ApplicationMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel { Text = "Settings" },
                    new MenuItemViewModel { Text = "Log Out", Icon = IconType.None },
                })
            };
        }

        #endregion
    }
}

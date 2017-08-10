using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// The desing time data for <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A singel instance of the desing model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion

        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel{Type= MenuItemType.Header, Text="Design Settings"},
                new MenuItemViewModel{Text="Menu Item 1", Icon=IconType.Cog}
            });
        }
    }
}

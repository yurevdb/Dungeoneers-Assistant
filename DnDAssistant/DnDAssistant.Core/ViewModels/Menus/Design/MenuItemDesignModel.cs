namespace DnDAssistant.Core
{
    /// <summary>
    /// The desing time data for <see cref="MenuItemViewModel"/>
    /// </summary>
    public class MenuItemDesignModel : MenuItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A singel instance of the desing model
        /// </summary>
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        #endregion

        public MenuItemDesignModel()
        {
            Text = "Hello World";
            Icon = IconType.Cog;
        }
    }
}

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The background color of the menu in ARGB values
        /// </summary>
        public string MenuBackground { get; set; }

        /// <summary>
        /// The alignment of the menu arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }


        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePopupViewModel()
        {
            // Set default values
            // TODO: Move colors into core and use it here
            MenuBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Center;
        }

        #endregion
    }
}

using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for WidgetContextMenuItemViewModel
    /// </summary>
    public class WidgetContextMenuItemViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        public string Text { get; set; }
        
        public ICommand Click { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetContextMenuItemViewModel()
        {

        }

        #endregion

    }
}

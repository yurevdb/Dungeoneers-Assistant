using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for WidgetViewModel
    /// </summary>
    public class WidgetViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the widget
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The command to execute when the widget is clicked, will most likely always be goto a page
        /// </summary>
        public ICommand Click { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetViewModel()
        {

        }

        #endregion

    }
}

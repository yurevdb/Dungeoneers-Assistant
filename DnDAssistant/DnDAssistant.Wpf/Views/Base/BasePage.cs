using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A base class for the functionality for all the pages in the application
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Properties

        /// <summary>
        /// The time for the page animation to take
        /// </summary>
        public float SlideSeconds { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {

        }

        #endregion
    }
}

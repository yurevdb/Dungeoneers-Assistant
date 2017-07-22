using System;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A viewmodel that holds the solution wide accessible data
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The path to the folder for the application data
        /// </summary>
        public string BaseDataPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Dungeoneers Assistant";

        /// <summary>
        /// The current page of the application
        /// </summary>
        public static ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Startup;

        #endregion

        /// <summary>
        /// Function to set the current page of the application
        /// </summary>
        /// <param name="page">The page to go to</param>
        public static void GoTo(ApplicationPage page)
        {
            // Set the current page of the application
            CurrentPage = page;
        }
    }
}

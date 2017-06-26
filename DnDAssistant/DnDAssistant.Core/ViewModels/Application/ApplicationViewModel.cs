using System;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A viewmodel that holds the solution wide accessible data
    /// </summary>
    public class ApplicationViewModel
    {
        #region Public Properties

        /// <summary>
        /// The path to the folder for the application data
        /// </summary>
        public string BaseDataPath => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Dungeoneers Assistant";

        #endregion
    }
}

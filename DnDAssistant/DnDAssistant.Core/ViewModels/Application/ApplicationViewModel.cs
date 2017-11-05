using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

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
        /// The path to the resource folder
        /// </summary>
        public string ResourcePath => $"{CampaignDataPath}\\Resources";

        /// <summary>
        /// The path to the folder for the Campaign data
        /// </summary>
        public string CampaignDataPath { get; set; }

        /// <summary>
        /// The current page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Startup;

        /// <summary>
        /// The current page of the campaignhost window
        /// </summary>
        public CampaignHostWindows CurrentCampaignPage { get; private set; } = CampaignHostWindows.Selector;

        /// <summary>
        /// The selected Campaign
        /// </summary>
        public CampaignViewModel Campaign { get; private set; }
        
        /// <summary>
        /// Indicating wether the Campaign dropdown menu is visible or not
        /// </summary>
        public bool CampaignMenuVisible { get; set; } = false;

        /// <summary>
        /// Indicating wether any popup is visible
        /// </summary>
        public bool AnyPopUpVisible => CampaignMenuVisible;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationViewModel()
        {
            
        } 

        #endregion

        /// <summary>
        /// Function to set the current page of the application
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoTo(ApplicationPage page)
        {
            // Set the current page of the application
            CurrentPage = page;
        }

        /// <summary>
        /// Function to set the current page of the campaign window
        /// </summary>
        /// <param name="page">The page to go to</param>
        public void GoTo(CampaignHostWindows page)
        {
            // Set the current page of the application
            CurrentCampaignPage = page;
        }

        /// <summary>
        /// Function to set the Current Campaign of the application
        /// </summary>
        /// <param name="campaign">The Campaign to edit</param>
        public void SetCampaign(CampaignViewModel campaign)
        {
            // Set the Current Campaign of the application
            Campaign = campaign;
        }
    }
}

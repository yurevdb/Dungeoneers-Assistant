namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for CampaignViewModel
    /// </summary>
    public class CampaignViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the Campaign
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description of the Campaign
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The role in the Campaign
        /// </summary>
        public CampaingRole Role { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CampaignViewModel()
        {

        }

        #endregion

    }
}

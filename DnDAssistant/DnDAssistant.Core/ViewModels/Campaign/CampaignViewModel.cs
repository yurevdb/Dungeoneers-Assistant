using System.IO;

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
        public string Name { get; set; } = null;

        /// <summary>
        /// The description of the Campaign
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// The role in the Campaign
        /// </summary>
        public CampaingRole Role { get; set; }

        /// <summary>
        /// The URI to the image
        /// </summary>
        public string ImageURI { get; set; } = $"pack://siteoforigin:,,,/Resources/dnd.jpg";

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CampaignViewModel()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets up the Campaign on the computer e.g. creating directories, installing files, etc.
        /// </summary>
        public void Setup()
        {
            // Setup the path to the root directory of the campaign
            IoC.App.CampaignDataPath = $"{IoC.App.BaseDataPath}\\{Name}";

            // Create the directory for the campaign
            Directory.CreateDirectory(IoC.App.CampaignDataPath);

            // Create resource directory for the campaign
            Directory.CreateDirectory($"{IoC.App.CampaignDataPath}\\Resources");

            // Save the data 
            new XmlStream(this, $"{IoC.App.CampaignDataPath}\\config.xml").Serialize();
        }

        #endregion

    }
}

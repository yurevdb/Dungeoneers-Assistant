using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for CampaignListItemViewModel
    /// </summary>
    public class CampaignListItemViewModel : CampaignViewModel
    {
        #region Public Properties

        public bool ShowDeleteButton { get; set; } = true;

        public ICommand OpenCampaign { get; set; }

        public ICommand DeleteCampaign { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CampaignListItemViewModel()
        {
            OpenCampaign = new RelayParameterizedCommand((obj) =>
            {
                if (obj is CampaignListItemViewModel campaign)
                {
                    if(campaign.Name == "New Campaign")
                    {
                        IoC.App.GoTo(CampaignHostWindows.Creator);
                        return;
                    }

                    IoC.App.SetCampaign(campaign);
                }
            });

            DeleteCampaign = new RelayParameterizedCommand((obj) =>
            {
                if(obj is CampaignListItemViewModel campaign)
                {
                    IoC.CampaignSelector.RemoveCampaign(campaign);
                }
            });
        }

        #endregion

    }
}

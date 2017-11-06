using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for CampaignListItemViewModel
    /// </summary>
    public class CampaignListItemViewModel : CampaignViewModel
    {
        #region Public Properties

        /// <summary>
        /// Indicator wether there should be a delete button shown
        /// </summary>
        public bool ShowDeleteButton { get; set; } = true;

        /// <summary>
        /// Command to open the campaign
        /// </summary>
        public ICommand OpenCampaign { get; set; }

        /// <summary>
        /// Command to delete the campaign
        /// </summary>
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
                    IoC.UI.OpenWindow(Windows.Main);
                }
            });

            DeleteCampaign = new RelayParameterizedCommand((obj) =>  
            {
                if(obj is CampaignListItemViewModel campaign)
                {
                    var res = IoC.UI.ShowResponseMessage(new DialogViewModel { Message = "This campaign will be deleted.", Title = "Deleting", Buttons = Buttons.YesNo });

                    if (res == DialogResponse.No || res == DialogResponse.Cancel)
                        return;

                    if(res == DialogResponse.Yes)
                        IoC.CampaignSelector.RemoveCampaign(campaign);
                }
            });
        }

        #endregion

    }
}

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for CampaignSelectorViewModel
    /// </summary>
    public class CampaignSelectorViewModel : BaseViewModel
    {
        #region Private Members
        
        private ObservableCollection<CampaignViewModel> _Campaigns = new ObservableCollection<CampaignViewModel>();

        private string _RemovedCampaignName;

        #endregion

        #region Public Properties
        /// <summary>
        /// The private list of campaigns
        /// NOTE: Do not Modify this list
        /// </summary>
        public ObservableCollection<CampaignViewModel> Campaigns
        {
            get => _Campaigns;
            set
            {
                // Make sure list has changed
                if (_Campaigns == value)
                    return;

                // Update list
                _Campaigns = value;

                // Update list
                FilteredCampaigns = new ObservableCollection<CampaignViewModel>(_Campaigns);
                FilteredCampaigns.CollectionChanged += (s,e) => RemovedCampaignAsync(e);
            }
        }

        /// <summary>
        /// The filtered list of campaigns
        /// </summary>
        public ObservableCollection<CampaignViewModel> FilteredCampaigns { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CampaignSelectorViewModel()
        {
        }

        #endregion

        /// <summary>
        /// Gets all the stored campaigns
        /// </summary>
        public void GetCampaigns()
        {
            IoC.Splash.StatusText = "Gathering data";

            // Add ListviewItems for every campaign saved on the computer
            foreach (var f in Directory.GetDirectories(IoC.App.BaseDataPath))
            {
                if (File.Exists($"{f}\\config.xml"))
                {
                    //TODO: get extra info from the config.xml file in the campaign directory (still needs to be added)
                    var campaignVM = new XmlStream().Deserialize<CampaignViewModel>($"{f}\\config.xml");

                    var campaignListItem = new CampaignListItemViewModel
                    {
                        Name = campaignVM.Name,
                        Description = campaignVM.Description,
                        ImageURI = campaignVM.ImageURI,
                        Role = campaignVM.Role,
                    };

                    if (campaignListItem.Name == "New Campaign")
                    {
                        campaignListItem.ShowDeleteButton = false;
                    }

                    _Campaigns.Add(campaignListItem);

                }
            }

            // Add the ListviewItem to add a new Campaign
            var newCampaignVM = new CampaignListItemViewModel
            {
                Name = "New Campaign",
                Description = "Opens the window to create a new Campaign.",
                ImageURI = "pack://siteoforigin:,,,/Resources/plus.ico",
                ShowDeleteButton = false
            };

            _Campaigns.Add(newCampaignVM);
            
            Campaigns = new ObservableCollection<CampaignViewModel>(_Campaigns);
        }

        /// <summary>
        /// Remove a campaign from the list of stored campaigns
        /// </summary>
        /// <param name="campaign"></param>
        public void RemoveCampaign(CampaignViewModel campaign)
        {
            _RemovedCampaignName = campaign.Name;

            // Remove the campaign from the list
            FilteredCampaigns.Remove(Campaigns.Where(c => c.Name == campaign.Name).Single());
        }

        /// <summary>
        /// Adds a campaign to the list of campaigns
        /// </summary>
        /// <param name="campaign"></param>
        public void AddCampaign(CampaignListItemViewModel campaign)
        {
            _Campaigns.Add(campaign);
            Campaigns = new ObservableCollection<CampaignViewModel>(_Campaigns);
        }

        /// <summary>
        /// Collection Changed event handler to remove a campaign
        /// </summary>
        /// <param name="e"></param>
        private async void RemovedCampaignAsync(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Give Garbage Collector time to do its thing
            await Task.Delay(100);

            // Make sure the Garbage collector deleted all the used files for the bindings
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                // Remove the campaign from the stored data
                foreach (var f in Directory.GetDirectories(IoC.App.BaseDataPath))
                    if (f.Split('\\').Last() == _RemovedCampaignName)
                        Directory.Delete(f, true);

                _RemovedCampaignName = string.Empty;
            }
        }
    }
}

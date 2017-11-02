using System.Windows.Input;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Default class for ControlHubViewModel
    /// </summary>
    public class ControlHubViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        public ICommand OpenDropDown { get; set; }

        public CampaignViewModel Campaign { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ControlHubViewModel()
        {
            OpenDropDown = new RelayCommand(() =>
            {
                IoC.App.CampaignMenuVisible ^= true;
            });
        }

        #endregion

    }
}

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

        #region Commands
        public ICommand OpenDropDown { get; set; }

        public ICommand SwitchAroo { get; set; } 
        #endregion

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

            SwitchAroo = new RelayCommand(() => 
            {
                IoC.UI.OpenWindow(Windows.CampaignSelector);
            } );
        }

        #endregion

    }
}

using System.Windows.Input;
using DnDAssistant.Core;

namespace DnDAssistant.Xamarin
{
    /// <summary>
    /// Default class for CampaignViewModelXam
    /// </summary>
    public class CampaignViewModelXam : BaseViewModel
    {
        #region Private Members

        private int _Count = 0;

        #endregion

        #region Public Properties

        public string Text { get; set; } = "Welcome, Press the button to see something spectacular";

        public ICommand Click { get; set; }

        public ICommand Switch { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CampaignViewModelXam()
        {
            Click = new RelayCommand(() => Text = $"You've clicked the button {++_Count} times.");
            Switch = new RelayCommand(() => App.Current.MainPage = new CampaignSelect());
        }

        #endregion

    }
}

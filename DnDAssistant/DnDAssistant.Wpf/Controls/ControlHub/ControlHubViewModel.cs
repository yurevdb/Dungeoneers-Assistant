using System.Windows;
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
                var mw = Application.Current.MainWindow;
                Application.Current.MainWindow = new CampaignHostWindow();
                Application.Current.MainWindow.Show();
                mw.Close();
            } );
        }

        #endregion

    }
}

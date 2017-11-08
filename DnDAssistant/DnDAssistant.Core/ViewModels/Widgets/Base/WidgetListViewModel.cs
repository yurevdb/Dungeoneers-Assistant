using System.Collections.ObjectModel;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for WidgetListViewModel
    /// </summary>
    public class WidgetListViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The collection of widgets, needs to be made to be able to search through them
        /// </summary>
        public ObservableCollection<WidgetViewModel> Widgets { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetListViewModel()
        {
            Widgets = new ObservableCollection<WidgetViewModel>
            {
                new WidgetViewModel
                {
                    Name = "Dice Roller",
                    Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel{ Message = "Not yet implemented", Title = "Dice Roller", Buttons = Buttons.Ok}))
                },

                new WidgetViewModel
                {
                    Name = "Story Board",
                    Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel{ Message = "Not yet implemented", Title = "Story Board", Buttons = Buttons.Ok}))
                },

                new WidgetViewModel
                {
                    Name = "Non Player Characters",
                    Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel{ Message = "Not yet implemented", Title = "Non Player Characters", Buttons = Buttons.Ok}))
                }
            };
        }

        #endregion

    }
}

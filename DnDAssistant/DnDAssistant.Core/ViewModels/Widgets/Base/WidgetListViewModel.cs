using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for WidgetListViewModel
    /// </summary>
    public class WidgetListViewModel : BaseViewModel
    {
        #region Private Members

        private ObservableCollection<WidgetViewModel> _Widgets { get; set; } = new ObservableCollection<WidgetViewModel>();

        private string _SearchText;

        private string _LastSearchText;

        private bool _SearchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// The collection of widgets, needs to be made to be able to search through them
        /// </summary>
        public ObservableCollection<WidgetViewModel> Widgets
        {
            get => _Widgets;
            set
            {
                if (_Widgets == value)
                    return;

                _Widgets = value;

                FilteredWidgets = new ObservableCollection<WidgetViewModel>(_Widgets);
            }
        }

        /// <summary>
        /// The filtered Widgets
        /// </summary>
        public ObservableCollection<WidgetViewModel> FilteredWidgets { get; set; } = new ObservableCollection<WidgetViewModel>();

        /// <summary>
        /// The searchtext
        /// </summary>
        public string SearchText
        {
            get => _SearchText;
            set
            {
                if (_SearchText == value)
                    return;

                _SearchText = value;

                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        /// <summary>
        /// The command to search for a widget within the List of Widgets
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command to close the search
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetListViewModel()
        {
            SearchCommand = new RelayCommand(() => Search());
            CloseCommand = new RelayCommand(() => SearchText = string.Empty);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set up the widgets
        /// </summary>
        public void Setup()
        {
            Add(new WidgetViewModel
            {
                Name = "Dice Roller",
                Image = "pack://siteoforigin:,,,/Resources/d20.png",
                Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel { Message = "Not yet implemented", Title = "Dice Roller", Buttons = Buttons.Ok }))
            });

            Add(new WidgetViewModel
            {
                Name = "Story Board",
                Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel { Message = "Not yet implemented", Title = "Story Board", Buttons = Buttons.Ok }))
            });

            Add(new WidgetViewModel
            {
                Name = "Non Player Characters",
                Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel { Message = "Not yet implemented", Title = "Non Player Characters", Buttons = Buttons.Ok }))
            });
        }

        /// <summary>
        /// Add a Widget to the list of widgets
        /// </summary>
        /// <param name="widget">The widget to add</param>
        public void Add(WidgetViewModel widget)
        {
            _Widgets.Add(widget);
            Widgets = new ObservableCollection<WidgetViewModel>(_Widgets);
        }
        
        /// <summary>
        /// Remove the widget from the list
        /// </summary>
        /// <param name="widget">The widget to remove</param>
        public void Remove(WidgetViewModel widget)
        {
            FilteredWidgets.Remove(Widgets.Where(c => c.Name == widget.Name).Single());
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Searches through all the widgets to find the one that matches the searchtext
        /// </summary>
        private void Search()
        {
            if ((string.IsNullOrEmpty(_LastSearchText) && string.IsNullOrEmpty(SearchText)) || string.Equals(_LastSearchText, SearchText))
                return;

            if(string.IsNullOrEmpty(SearchText) || Widgets == null || Widgets.Count <= 0)
            {
                FilteredWidgets = new ObservableCollection<WidgetViewModel>(Widgets);

                _LastSearchText = SearchText;

                return;
            }

            FilteredWidgets = new ObservableCollection<WidgetViewModel>(Widgets.Where(widget => widget.Name.ToLower().Contains(SearchText.ToLower())));

            _LastSearchText = SearchText;
        }

        #endregion
    }
}

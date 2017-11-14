using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for the navigation menu items
    /// </summary>
    public class NavigationMenuItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The action for a click command to the navigation menu item
        /// </summary>
        public ICommand Click { get; set; }

        /// <summary>
        /// The title of the navigation menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The URI of the image
        /// </summary>
        public string ImageURI { get; set; } = string.Empty;

        /// <summary>
        /// Indicator wether an image URI is set
        /// </summary>
        public bool IsImageSet => (ImageURI == string.Empty) ? false : true;
        
        /// <summary>
        /// Indicator for when the Navigation Item is selected
        /// </summary>
        public bool IsSelected { get; set; } = false;

        /// <summary>
        /// The connected page to this navigation menu item
        /// </summary>
        public ApplicationPage ConnectedPage { get; set; }

        /// <summary>
        /// The context menu
        /// </summary>
        public ObservableCollection<NavigationMenuItemContextMenuViewModel> ContextMenu { get; set; } = new ObservableCollection<NavigationMenuItemContextMenuViewModel>
        {
            new NavigationMenuItemContextMenuViewModel
            {
                Text = "Remove",
                Click = new RelayParameterizedCommand(obj => IoC.Navigation.Remove(obj as NavigationMenuItemViewModel))
            },
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationMenuItemViewModel()
        {

        }

        /// <summary>
        /// Constructor to create a navigation item from a widget
        /// </summary>
        /// <param name="widget"></param>
        public NavigationMenuItemViewModel(WidgetViewModel widget)
        {
            Title = widget.Name;

            Click = widget.Click;

            ImageURI = widget.Image;
        }

        #endregion
    }
}

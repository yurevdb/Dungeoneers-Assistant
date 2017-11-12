using System.Collections.ObjectModel;
using System.Linq;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for the navigation menu
    /// </summary>
    public class NavigationMenuViewModel: BaseViewModel
    {
        #region Private Members

        private ObservableCollection<NavigationMenuItemViewModel> _Items = new ObservableCollection<NavigationMenuItemViewModel>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The <see cref="NavigationMenuItemViewModel"/> items
        /// </summary>
        public ObservableCollection<NavigationMenuItemViewModel> Items
        {
            get => _Items;
            set
            {
                // if the value doesn't differ from the current list
                if (_Items == value)
                    return;

                _Items = value;

                FilteredItems = new ObservableCollection<NavigationMenuItemViewModel>(_Items);
            }
        }

        /// <summary>
        /// The filtered <see cref="NavigationMenuItemViewModel"/> Items
        /// </summary>
        public ObservableCollection<NavigationMenuItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// List with Navigation Menu Items that the user has no control over
        /// </summary>
        public ObservableCollection<NavigationMenuItemViewModel> StaticList { get; set; } = new ObservableCollection<NavigationMenuItemViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationMenuViewModel()
        {
        }

        #endregion

        /// <summary>
        /// Sets up the navigation menu
        /// </summary>
        public void SetupNavigation()
        {
            StaticList.Add
            (
                new NavigationMenuItemViewModel
                {
                    Click = new RelayParameterizedCommand(obj =>
                    {
                        (obj as NavigationMenuItemViewModel).IsSelected ^= true;
                        IoC.App.GoToAsync(ApplicationPage.CharacterCreator);
                    }),
                    Title = "Character Creator",
                    ConnectedPage = ApplicationPage.CharacterCreator
                }
            );


            if (IoC.App.Campaign?.Role == CampaingRole.DungeonMaster)
                StaticList.Add(new NavigationMenuItemViewModel
                {
                    Click = new RelayParameterizedCommand(obj =>
                    {
                        (obj as NavigationMenuItemViewModel).IsSelected ^= true;
                        IoC.App.GoToAsync(ApplicationPage.DMTools);
                    }),
                    Title = "DM Tools",
                    ConnectedPage = ApplicationPage.DMTools
                });

            Items = new ObservableCollection<NavigationMenuItemViewModel>(_Items);
        }

        //TODO: add propertychanged way for this list with add and remove functionality
        /// <summary>
        /// Add a <see cref="NavigationMenuItemViewModel"/> to the navigation menu
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(NavigationMenuItemViewModel item)
        {
            // if the item is already in the navigation
            if (_Items.Any(i => i.Title == item.Title))
                return;

            // else add the item
            _Items.Add(item);
            Items = new ObservableCollection<NavigationMenuItemViewModel>(_Items);
        }

        /// <summary>
        /// Remove a <see cref="NavigationMenuItemViewModel"/> from the navigation menu
        /// </summary>
        /// <param name="item">The item to remove</param>
        public void Remove(NavigationMenuItemViewModel item)
        {
            if ((item as NavigationMenuItemViewModel) == null)
                return;

            if(FilteredItems.Count >= 1)
                FilteredItems.Remove(Items.Where(c => c.Title == item.Title).Single());
        }
    }
}

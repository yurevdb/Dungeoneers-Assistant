using System.Collections.ObjectModel;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for the navigation menu
    /// </summary>
    public class NavigationMenuViewModel: BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The <see cref="NavigationMenuViewModel"/> items
        /// </summary>
        public ObservableCollection<NavigationMenuItemViewModel> Items { get; set; }

        /// <summary>
        /// The <see cref="NavigationMenuViewModel"/> singleton
        /// </summary>
        public static NavigationMenuViewModel Instance => new NavigationMenuViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        private NavigationMenuViewModel()
        {

            Items = new ObservableCollection<NavigationMenuItemViewModel>
            {
                new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(() => IoC.App.GoTo(ApplicationPage.CharacterCreator)),
                    Title = "Character Creator"
                },
            };


            if (IoC.App.Campaign.Role == CampaingRole.DungeonMaster)
                Items.Insert(0, new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(() => IoC.App.GoTo(ApplicationPage.DMTools)),
                    Title = "DM Tools"
                });
        }

        #endregion

        //TODO: add propertychanged way for this list with add and remove functionality
    }
}

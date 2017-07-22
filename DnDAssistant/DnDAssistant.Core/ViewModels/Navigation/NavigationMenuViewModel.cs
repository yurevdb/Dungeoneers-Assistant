using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for the navigation menu
    /// </summary>
    public class NavigationMenuViewModel: BaseViewModel
    {
        #region Public Properties

        public List<NavigationMenuItemViewModel> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NavigationMenuViewModel()
        {
            Items = new List<NavigationMenuItemViewModel>
            {
                new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(()=> IoC.Application.GoTo(ApplicationPage.Startup)),
                    Title = "Startup"
                },
                new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(() =>  IoC.Application.GoTo(ApplicationPage.CharacterCreator)),
                    Title = "Character Creator"
                },
            };
        }

        #endregion
    }
}

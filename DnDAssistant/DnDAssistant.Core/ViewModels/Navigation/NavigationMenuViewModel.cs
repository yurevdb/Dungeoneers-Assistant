using System.Collections.Generic;

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
        public List<NavigationMenuItemViewModel> Items { get; set; }

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

            Items = new List<NavigationMenuItemViewModel>
            {
                new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(()=> IoC.App.GoTo(ApplicationPage.Startup)),
                    Title = "Startup"
                },
                new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(() =>
                    {
                        IoC.App.GoTo(ApplicationPage.CharacterCreator);

                        //Test for the error handling
                        IoC.Error.Add(new Error(ErrorType.Message, "Hello"));
                    }),
                    Title = "Character Creator"
                },
            };


            if (IoC.App.Campaign.Role == CampaingRole.DungeonMaster)
                Items.Insert(0, new NavigationMenuItemViewModel
                {
                    Click = new RelayCommand(() => IoC.UI.ShowMessage(new DialogViewModel { Title = "Error", Message = "This feature is not yet implemented", Buttons = Buttons.Ok })),
                    Title = "DM Tools"
                });
        }

        #endregion
    }
}

using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class ApplicationMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ApplicationMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel
                    {
                        Text = "Settings",
                        Icon = IconType.Cog,
                        Click = new RelayCommand(async () => await IoC.UI.ShowMessage(new DialogViewModel
                        {
                            Title = "Settings",
                            Message = "This should take you to the settings menu",
                            OkText = "Close"
                        }
                        ))
                    },

                    new MenuItemViewModel {
                        Text = "Switch Campaign",
                        Icon = IconType.None,
                        Click = new RelayCommand(async () => await IoC.UI.ShowMessage(new DialogViewModel
                        {
                            Title = "Switch Campaign",
                            Message = "This feature is not yet implemented",
                            OkText = "Ok"
                        }
                        ))
                    },
                })
            };
        }

        #endregion
    }
}

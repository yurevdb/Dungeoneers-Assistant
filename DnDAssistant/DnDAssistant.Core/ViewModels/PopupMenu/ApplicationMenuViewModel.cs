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
                        ToolTip = "Show the settings",
                        Click = new RelayCommand(async () => await IoC.UI.ShowMessage(new DialogViewModel
                        {
                            Title = "Error",
                            Message = "This should take you to the settings menu",
                            Buttons = Buttons.Ok,
                        }
                        ))
                    },

                    new MenuItemViewModel {
                        Text = "Switch Campaign",
                        Icon = IconType.None,
                        ToolTip = "Goes to the Campaign Select",
                        Click = new RelayCommand(()=>
                        {
                            // Set the campaignhostwindow to the selector
                            IoC.App.GoTo(CampaignHostWindows.Selector);

                            // Close the campaign menu
                            IoC.App.CampaignMenuVisible = false;

                            // Show the campaignhostwindow and close the current window
                            IoC.UI.OpenWindow(Windows.CampaignSelector);
                        })
                    },

                    new MenuItemViewModel
                    {
                        Text = "Show Navigation",
                        Icon = IconType.None,
                        ToolTip = "Shift + N",
                        Click = new RelayCommand(() =>
                        {
                            IoC.App.NavigationMenuVisible ^= true;
                        })
                    },

                    new MenuItemViewModel
                    {
                        Text = "Show Widgets",
                        Icon = IconType.None,
                        ToolTip = "Shift + W",
                        Click = new RelayCommand(() =>
                        {
                            IoC.App.GoTo(ApplicationPage.Startup);
                        })
                    }
                })
            };
        }

        #endregion
    }
}

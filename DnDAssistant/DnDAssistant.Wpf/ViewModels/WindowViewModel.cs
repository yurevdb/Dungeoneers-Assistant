using DnDAssistant.Core;
using System.Windows;
using System.Windows.Input;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A viewmodel for the custom window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// the window
        /// </summary>
        private Window _Window;

        /// <summary>
        ///  The margin around the window to allow for a drop shadow
        /// </summary>
        private int _OuterMarginSize = 10;

        /// <summary>
        /// the radius of the edges from the window
        /// </summary>
        private int _WindowRadius = 0;

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Shows the custom context menu
        /// </summary>
        public ICommand MenuCommand { get; set; }

        /// <summary>
        /// The command for when any area around the popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; } 

        /// <summary>
        /// Toggles the visibility of the navigation menu
        /// </summary>
        public ICommand ToggleNavigationCommand { get; set; }

        #region Navigation Commands

        /// <summary>
        /// Go to the widget page (startup)
        /// </summary>
        public ICommand GotoWidgetPage { get; set; }

        /// <summary>
        /// Go to the character creator page
        /// </summary>
        public ICommand GotoCharacterCreatorPage { get; set; }

        /// <summary>
        /// Go to the DMTools page
        /// </summary>
        public ICommand GotoDMToolsPage { get; set; }

        #endregion

        #endregion

        #region Public Properties

        #region Window Ui Properties

        /// <summary>
        /// The minimum height of the window
        /// </summary>
        public int MinimumWindowHeight { get; set; } = 550;

        /// <summary>
        /// The minimum width of the window
        /// </summary>
        public int MinimumWindowWidth { get; set; } = 900;

        /// <summary>
        /// The size of the resizeborder around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 5;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => _Window.WindowState == WindowState.Maximized ? 0 : _OuterMarginSize;
            set => _OuterMarginSize = value;
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// The radius of the edges from the window
        /// </summary>
        public int WindowRadius
        {
            get => _Window.WindowState == WindowState.Maximized ? 0 : _WindowRadius;
            set => _WindowRadius = value;
        }

        /// <summary>
        /// The radius of the edges from the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);
        
        /// <summary>
        /// The padding of the content
        /// </summary>
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        /// <summary>
        /// The height of the content margin
        /// </summary>
        public double InnerContentMarginHeight => TitleHeight + ResizeBorder - 7;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 55;

        /// <summary>
        /// The height of the caption bar
        /// </summary>
        public double CaptionHeight => TitleHeight - 14;
        #endregion

        #region Other

        /// <summary>
        /// True if we should dim the background
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        /// <summary>
        /// The view model for the application menu
        /// </summary>
        public ApplicationMenuViewModel AppMenu { get; set; }

        /// <summary>
        /// The background of the window. The name should be in the Resources folder of the application.
        /// </summary>
        public string Background { get; set; } = "Wallpaper.jpg";

        /// <summary>
        /// The tooltip text of the maximize and normalize window state button
        /// </summary>
        public string WindowStateButtonTooltipText { get; set; } = "Maximize";

        /// <summary>
        /// The Name of the Campaing
        /// </summary>
        public string CampaignName => IoC.App.Campaign.Name;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_window"></param>
        public WindowViewModel(Window _window)
        {
            _Window = _window;
            //Listen out for the window resizing
            _Window.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties affected by the resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            #region Commands

            MinimizeCommand = new RelayCommand(() => _Window.WindowState = WindowState.Minimized);
            // ^= is xor
            MaximizeCommand = new RelayCommand(() => 
            {
                _Window.WindowState ^= WindowState.Maximized;
                WindowStateButtonTooltipText = (_Window.WindowState == WindowState.Maximized) ? "Normalize" : "Maximize";
            });
            CloseCommand = new RelayCommand(() => _Window.Close());
            MenuCommand = new RelayCommand(() => { new CampaignHostWindow().Show(); _Window.Close(); });
            PopupClickawayCommand = new RelayCommand(() => IoC.App.CampaignMenuVisible = false);
            ToggleNavigationCommand = new RelayCommand(() => IoC.App.NavigationMenuVisible ^= true);
            GotoWidgetPage = new RelayCommand(() => IoC.App.GoTo(ApplicationPage.Startup));
            GotoCharacterCreatorPage = new RelayCommand(() => IoC.App.GoTo(ApplicationPage.CharacterCreator));
            GotoDMToolsPage = new RelayCommand(() => IoC.App.GoTo(ApplicationPage.DMTools));

            #endregion

            #region Menu

            AppMenu = new ApplicationMenuViewModel();

            #endregion

            // Fix window resize issue
            var resizer = new WindowResizer(_Window);
        }

        #endregion
    }
}

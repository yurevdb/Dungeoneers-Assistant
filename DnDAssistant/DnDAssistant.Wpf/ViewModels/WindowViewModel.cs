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

        #endregion

        #region Public Properties

        #region Window Ui Properties

        /// <summary>
        /// The minimum height of the window
        /// </summary>
        public int MinimumWindowHeight { get; set; } = 350;

        /// <summary>
        /// The minimum width of the window
        /// </summary>
        public int MinimumWindowWidth { get; set; } = 400;

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
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 40;

        /// <summary>
        /// The padding of the content
        /// </summary>
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        /// <summary>
        /// The height of the content margin
        /// </summary>
        public double InnerContentMarginHeight => TitleHeight + ResizeBorder - 7;

        /// <summary>
        /// The height of the caption bar
        /// </summary>
        public double CaptionHeight => TitleHeight + ResizeBorder - 2;
        #endregion
        
        #region Other

        /// <summary>
        /// True when the application menu should be visible, false when not
        /// </summary>
        public bool ApplicationMenuVisible { get; set; }

        /// <summary>
        /// True when a popup menu is visible
        /// </summary>
        public bool AnyPopupVisible => ApplicationMenuVisible;

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
            MaximizeCommand = new RelayCommand(() => _Window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _Window.Close());
            MenuCommand = new RelayCommand(() => ApplicationMenuVisible ^= true);
            PopupClickawayCommand = new RelayCommand(() => ApplicationMenuVisible = false );

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

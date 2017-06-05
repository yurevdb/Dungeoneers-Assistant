using DnDAssistant.Core;
using System;
using System.Runtime.InteropServices;
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
        private Window window;

        /// <summary>
        ///  The margin around the window to allow for a drop shadow
        /// </summary>
        private int outerMarginSize = 10;

        /// <summary>
        /// the radius of the edges from the window
        /// </summary>
        private int windowRadius = 0;

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

        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the resizeborder around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 2;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            set => outerMarginSize = value;
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
            get => window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            set => windowRadius = value;
        }

        /// <summary>
        /// The radius of the edges from the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 35;

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
        public double CaptionHeight => TitleHeight + ResizeBorder;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="_window"></param>
        public WindowViewModel(Window _window)
        {
            window = _window;
            //Listen out for the window resizing
            window.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties affected by the resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            #region Commands

            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            // ^= is xor
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));

            #endregion

            // Fix window resize issue
            var resizer = new WindowResizer(window);
        }

        #endregion

        #region Private Helpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        #endregion
    }
}

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// The base class for anu content that is being used insaide of a <see cref="DialogWindow"/>
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members

        /// <summary>
        /// The dialog window we will be contained within
        /// </summary>
        /// <returns></returns>
        private DialogWindow _DialogWindow;

        #endregion

        #region Public Commands

        /// <summary>
        /// Closes this dialog
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The minimum width of this dialog
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 250;

        /// <summary>
        /// The minimum height of this dialog
        /// </summary>
        public int WindowMinimumHeight{ get; set; } = 250;

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The title of this dialog
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            // Create a dialog window
            _DialogWindow = new DialogWindow();
            _DialogWindow.ViewModel = new DialogWindowViewModel(_DialogWindow);

            // Set the owner of the Dialog control to the mainwindow of the application
            _DialogWindow.Owner = Application.Current.MainWindow;

            //Create close command
            CloseCommand = new RelayCommand(() => _DialogWindow.Close());
        }

        #endregion
        
        #region Public Dialog Show Methods
        
        /// <summary>
        /// Display a dialog window for the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <typeparam name="T">The view model type for this control</typeparam>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
            where T : BaseDialogViewModel
        {
            // Create a task to await the dialog closing
            var tcs = new TaskCompletionSource<bool>();

            // Run on the ui thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    // Match controls size
                    _DialogWindow.ViewModel.TitleHeight = TitleHeight;
                    _DialogWindow.ViewModel.Title = viewModel.Title ?? Title;

                    // Set this control to the dialog window content
                    _DialogWindow.ViewModel.Content = this;
                    
                    // Setup this controls data context binding to the view model
                    DataContext = viewModel;

                    // Show dialog
                    _DialogWindow.ShowDialog();
                }
                finally
                {
                    // let caller know we finished
                    tcs.TrySetResult(true);
                }
            });

            return tcs.Task;
        }

        #endregion
    }
}

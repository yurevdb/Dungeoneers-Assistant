using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for ErrorViewModel
    /// </summary>
    public class ErrorViewModel : BaseViewModel
    {
        #region Private Members
        
        private ObservableCollection<Error> _Errors = new ObservableCollection<Error>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of errors
        /// </summary>
        public ObservableCollection<Error> Errors => _Errors;

        /// <summary>
        /// Indicator if there is at least 1 error
        /// </summary>
        public bool AnyError { get; set; }

        /// <summary>
        /// Gets the highest <see cref="ErrorType"/> in the error list
        /// </summary>
        public ErrorType HighestErrorType => CheckErrorTypes();

        /// <summary>
        /// The amount of unhandled errors in the errorlist
        /// </summary>
        public string ShowCount { get; set; }

        #endregion

        #region Command

        /// <summary>
        /// Command to handle the errors
        /// </summary>
        public ICommand OpenErrors { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ErrorViewModel()
        {
            _Errors.CollectionChanged += (s,e) => SetThings();

            OpenErrors = new RelayCommand(() =>
            {
                var errors = _Errors;
                foreach (var error in errors)
                {
                    if (error.NeedToShow)
                    {
                        IoC.UI.ShowMessage(new DialogViewModel
                        {
                            Title = error.Type.ToString(),
                            OkText = "Close",
                            Message = $"{error.Message}",
                        });

                        error.NeedToShow = false;

                        SetThings();
                    }
                }
            });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add and error to the list of errors
        /// </summary>
        /// <param name="Error"></param>
        public void Add(Error Error)
        {
            _Errors.Add(Error);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the highest errortype
        /// </summary>
        /// <param name="Error"></param>
        private ErrorType CheckErrorTypes()
        {
            var type = ErrorType.Message;

            foreach(var e in _Errors)
            {
                if (e.Type > type)
                    type = e.Type;
            }

            return type;
        }

        /// <summary>
        /// Get the amount of errors that need to be shown
        /// </summary>
        /// <returns></returns>
        private int CountErrorsToShow()
        {
            var count = 0;

            foreach (var e in _Errors)
                if (e.NeedToShow)
                    count++;

            return count;
        }

        /// <summary>
        /// Sets many of things
        /// </summary>
        private void SetThings()
        {
            AnyError = (CountErrorsToShow() > 0) ? true : false;
            ShowCount = CountErrorsToShow().ToString();
        }

        #endregion

    }
}

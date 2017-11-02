using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for ErrorViewModel
    /// </summary>
    public class ErrorViewModel : BaseViewModel
    {
        #region Private Members

        private List<Error> _Errors = new List<Error>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The list of errors
        /// </summary>
        public List<Error> Errors => _Errors;

        /// <summary>
        /// Indicator if there is at least 1 error
        /// </summary>
        public bool AnyError => _Errors.Count > 0;

        /// <summary>
        /// Gets the highest <see cref="ErrorType"/> in the error list
        /// </summary>
        public ErrorType HighestErrorType => CheckErrorTypes();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ErrorViewModel()
        {

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
        /// Add and error to the list of errors
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

        #endregion

    }
}

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for Error
    /// </summary>
    public class Error
    {
        #region Public Properties

        /// <summary>
        /// The type of error
        /// </summary>
        public ErrorType Type { get; set; } = ErrorType.Message;

        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indicator wether the error has been handled
        /// </summary>
        public bool Handled { get; set; } = false;

        /// <summary>
        /// Indicator wether the error needs to be shown
        /// </summary>
        public bool NeedToShow { get; set; } = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Error() { }

        /// <summary>
        /// Constructor with <see cref="ErrorType"/> parameter
        /// </summary>
        /// <param name="type">The type of error</param>
        public Error(ErrorType type)
        {
            Type = type;
        }
        
        /// <summary>
        /// Constructor with <see cref="ErrorType"/> and <see cref="Message"/> parameter
        /// </summary>
        /// <param name="type">The type of error</param>
        /// <param name="message">The error message</param>
        public Error(ErrorType type, string message)
        {
            Type = type;
            Message = message;
        }

        #endregion

    }
}

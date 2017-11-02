namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for ErrorType
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// A message, just to mention something
        /// </summary>
        Message = 0,

        /// <summary>
        /// A warning, something went wrong but no worries
        /// </summary>
        Warning = 1,

        /// <summary>
        /// An error, something went wrong and maybe worry
        /// </summary>
        Error = 2
    }
}

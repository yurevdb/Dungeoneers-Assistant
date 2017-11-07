namespace DnDAssistant.Core
{
    /// <summary>
    /// An enum for the different kind of pages
    /// </summary>
    public enum ApplicationPage
    {
        /// <summary>
        /// A page to test various things out
        /// </summary>
        Test = 0,

        /// <summary>
        /// The page where the user will land oafter opening the application. This contains various info.
        /// </summary>
        Startup = 1,

        /// <summary>
        /// The character creator page
        /// </summary>
        CharacterCreator = 2,

        /// <summary>
        /// DM Tools page
        /// </summary>
        DMTools = 3,
    }
}

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for StoryBoardViewModel
    /// </summary>
    public class StoryBoardViewModel : BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        public ChapterToolViewModel ChapterTool => new ChapterToolViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public StoryBoardViewModel()
        {

        }

        #endregion

    }
}

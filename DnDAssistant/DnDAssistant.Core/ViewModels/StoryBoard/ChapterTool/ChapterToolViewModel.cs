using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for ChapterToolViewModel
    /// </summary>
    public class ChapterToolViewModel: BaseViewModel
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// The text to show
        /// </summary>
        public string Text { get; set; } = "Create Chapter";

        /// <summary>
        /// Indicator wether the Create Chapter command should be active
        /// </summary>
        public bool CreateChapterActive { get; set; } = true;

        /// <summary>
        /// The command to create a new chapter
        /// </summary>
        public ICommand CreateChapter { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChapterToolViewModel()
        {
            CreateChapter = new RelayCommand(() =>
            {
                CreateChapterActive ^= true;
            });
        }

        #endregion

    }
}

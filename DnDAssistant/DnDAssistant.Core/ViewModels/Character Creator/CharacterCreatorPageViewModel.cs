namespace DnDAssistant.Core
{
    public class CharacterCreatorPageViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current <see cref="CreatorPage"/> whithin the Character Creator
        /// </summary>
        public CreatorPage CurrentCreatorPage { get; set; } = CreatorPage.BasicInfo;

        #endregion
    }
}

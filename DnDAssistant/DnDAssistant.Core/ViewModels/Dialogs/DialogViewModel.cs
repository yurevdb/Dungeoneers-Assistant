namespace DnDAssistant.Core
{
    /// <summary>
    /// Details for a dialog window
    /// </summary>
    public class DialogViewModel : BaseDialogViewModel
    {
        /// <summary>
        /// The message to dispaly
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Buttons to Show
        /// </summary>
        public Buttons Buttons { get; set; } = Buttons.None;
    }
}

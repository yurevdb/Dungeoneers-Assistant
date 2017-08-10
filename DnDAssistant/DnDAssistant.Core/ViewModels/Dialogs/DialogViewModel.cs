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
        /// Ok Text
        /// </summary>
        public string OkText { get; set; }
    }
}

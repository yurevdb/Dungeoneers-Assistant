namespace DnDAssistant.Core
{
    public class BasicCreatorViewModel
    {
#region Public properties
        /// <summary>
        /// <see cref="string"/> containing the chosen name of the character
        /// </summary>
        public string PlayerName { get; set; }
        /// <summary>
        /// <see cref="string"/> containing the picked class of the character
        /// </summary>
        public string PickedClass{ get; set; }
        /// <summary>
        /// <see cref="string"/> containing the picked race of the character
        /// </summary>
        public string PickedRace { get; set; }
#endregion


    }
}

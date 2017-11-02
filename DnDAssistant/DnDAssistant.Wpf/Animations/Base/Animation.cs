namespace DnDAssistant.Wpf
{
    /// <summary>
    /// The type of animation
    /// </summary>
    public enum Animation
    {
        /// <summary>
        /// No Animation
        /// </summary>
        None = 0,

        /// <summary>
        /// Slide and Fade animation from top to bottom
        /// </summary>
        SlideAndFadeInFromTop = 1,

        /// <summary>
        /// Slide and Fade animation from bottom to top
        /// </summary>
        SlideAndFadeOutToTop = 2,

        /// <summary>
        /// Slide and Fade animation from right
        /// </summary>
        SlideAndFadeFromRight = 3,

        /// <summary>
        /// Slide and Fade animation to bottom
        /// </summary>
        SlideAndFadeOutToBottom = 4,

        /// <summary>
        /// Slide and Fade in from bottom
        /// </summary>
        SlideAndFadeInFromBottom = 5,
    }
}

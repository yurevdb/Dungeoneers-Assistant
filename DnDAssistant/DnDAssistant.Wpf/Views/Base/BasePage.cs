using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A base class for the functionality for all the pages in the application
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Properties

        /// <summary>
        /// The animation to happen when the page loads in
        /// </summary>
        public Animation PageLoadAnimation { get; set; } = Animation.SlideAndFadeFromRight;

        /// <summary>
        /// the animation to happen when the page unloads
        /// </summary>
        public Animation PageUnloadAnimation { get; set; } = Animation.SlideAndFadeOutToBottom;

        /// <summary>
        /// The time for the page animation to take
        /// </summary>
        public float SlideSeconds { get; set; } = 0.9f;

        /// <summary>
        /// A flag determining if the page should animte out on load
        /// </summary>
        public bool ShouldAnimateOut { get; set; } = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            // animate the page
            Loaded += BasePage_Loaded;
        }

        /// <summary>
        /// Starts the animation for the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // if the page should animate out on load...
            if (ShouldAnimateOut)
                // animate out
                AnimateOutAsync();
            // else...
            else
                // animate in
                AnimateInAsync();
        }

        #endregion

        #region Animations

        /// <summary>
        /// Animates the <see cref="BasePage"/> in
        /// </summary>
        public async void AnimateInAsync()
        {
            // if there is no need for an animtion...
            if (PageLoadAnimation == Animation.None)
                // return
                return;

            // execute the correct animation
            switch (PageLoadAnimation)
            {
                case Animation.SlideAndFadeFromRight:
                    await Animations.SlideAndFadeInAsync(this, SlideDirection.Right, SlideSeconds);
                    return;
                case Animation.SlideAndFadeInFromBottom:
                    await Animations.SlideAndFadeInAsync(this, SlideDirection.Bottom, SlideSeconds);
                    return;
                case Animation.SlideAndFadeInFromTop:
                    await Animations.SlideAndFadeInAsync(this, SlideDirection.Top, SlideSeconds);
                    return;
            }
        }

        /// <summary>
        /// Animates the <see cref="BasePage"/> out
        /// </summary>
        public async void AnimateOutAsync()
        {
            // if there is no need for an animtion...
            if (PageUnloadAnimation == Animation.None)
                // return
                return;

            // execute the correct animation
            switch (PageUnloadAnimation)
            {
                case Animation.SlideAndFadeOutToBottom:
                    await Animations.SlideAndFadeOutAsync(this, SlideDirection.Bottom, SlideSeconds);
                    return;
                case Animation.SlideAndFadeOutToTop:
                    await Animations.SlideAndFadeOutAsync(this, SlideDirection.Top, SlideSeconds);
                    return;
            }
        }

        #endregion
    }
}

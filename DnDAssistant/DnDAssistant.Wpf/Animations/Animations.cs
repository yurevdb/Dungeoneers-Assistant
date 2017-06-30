using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Helpers to animate a <see cref="FrameworkElement"/>
    /// </summary>
    public static class Animations
    {
        #region Slide in / to Top

        /// <summary>
        /// Adds a slide in from top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task SlideInFromTopAsync(this FrameworkElement element, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in from top animation
            sb.AddSlideInFromTop(seconds, element.ActualHeight);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Adds a slide out to top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task SlideOutToTopAsync(this FrameworkElement element, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in from top animation
            sb.AddSlideOutToTop(seconds, element.ActualHeight);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion
        
        #region Fade in / out

        /// <summary>
        /// Adds a fade out animation to the <see cref="FrameworkElement"/>
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task FadeInAsync(this FrameworkElement element, float seconds = 0.2f)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Adds a fade out animation to the <see cref="FrameworkElement"/> if its <see cref="Visibility"/> isn't hidden or collapsed
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.2f)
        {
            // If the element is hidden or collapsed...
            if (element.Visibility == Visibility.Collapsed || element.Visibility == Visibility.Hidden)
                // Do nothing
                return;

            // Create the storyboard
            var sb = new Storyboard();

            // Add fade out animation
            sb.AddFadeOut(seconds);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide and fade in / to Top

        /// <summary>
        /// Adds a slide in from top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromTopAsync(this FrameworkElement element, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in from top animation
            sb.AddSlideInFromTop(seconds, element.ActualHeight);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Adds a slide out to top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToTopAsync(this FrameworkElement element, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in from top animation
            sb.AddSlideOutToTop(seconds, element.ActualHeight);

            // Add fade out animation
            sb.AddFadeOut(seconds);

            // Start the animation
            sb.Begin(element);

            // Make element visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion
    }
}

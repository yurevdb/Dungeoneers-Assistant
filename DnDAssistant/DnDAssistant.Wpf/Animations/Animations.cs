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
        #region Slide in / to

        /// <summary>
        /// Adds a slide in from top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <param name="direction">The <see cref="SlideDirection"/> from wich the slide should happen</param>
        /// <returns></returns>
        public static async Task SlideInAsync(this FrameworkElement element, SlideDirection direction, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in animation
            switch (direction)
            {
                case SlideDirection.Top:
                    sb.AddSlideInFromTop(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Right:
                    sb.AddSlideInFromRight(seconds, element.ActualWidth);
                    break;
                case SlideDirection.Bottom:
                    sb.AddSlideInFromRight(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Left:
                    sb.AddSlideInFromRight(seconds, element.ActualWidth);
                    break;
            }

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
        /// <param name="direction">The <see cref="SlideDirection"/> to wich the slide should happen</param>
        /// <returns></returns>
        public static async Task SlideOutAsync(this FrameworkElement element, SlideDirection direction, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in animation
            switch (direction)
            {
                case SlideDirection.Top:
                    sb.AddSlideOutToTop(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Right:
                    sb.AddSlideOutToRight(seconds, element.ActualWidth);
                    break;
                case SlideDirection.Bottom:
                    sb.AddSlideOutToBottom(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Left:
                    sb.AddSlideOutToLeft(seconds, element.ActualWidth);
                    break;
            }
            
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

        #region Slide and fade in / to

        /// <summary>
        /// Adds a slide in from top animation to the element
        /// </summary>
        /// <param name="element">The <see cref="FrameworkElement"/> to add the animation to</param>
        /// <param name="seconds">The time the animation should take</param>
        /// <param name="direction">The <see cref="SlideDirection"/> from wich the slide should happen</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, SlideDirection direction, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in animation
            switch (direction)
            {
                case SlideDirection.Top:
                    sb.AddSlideInFromTop(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Right:
                    sb.AddSlideInFromRight(seconds, element.ActualWidth);
                    break;
                case SlideDirection.Bottom:
                    sb.AddSlideInFromRight(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Left:
                    sb.AddSlideInFromRight(seconds, element.ActualWidth);
                    break;
            }
            
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
        /// <param name="direction">The <see cref="SlideDirection"/> to wich the slide should happen</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, SlideDirection direction, float seconds)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide in animation
            switch (direction)
            {
                case SlideDirection.Top:
                    sb.AddSlideOutToTop(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Right:
                    sb.AddSlideOutToRight(seconds, element.ActualWidth);
                    break;
                case SlideDirection.Bottom:
                    sb.AddSlideOutToBottom(seconds, element.ActualHeight);
                    break;
                case SlideDirection.Left:
                    sb.AddSlideOutToLeft(seconds, element.ActualWidth);
                    break;
            }

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

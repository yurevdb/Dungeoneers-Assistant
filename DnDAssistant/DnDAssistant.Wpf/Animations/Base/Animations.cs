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
    }
}

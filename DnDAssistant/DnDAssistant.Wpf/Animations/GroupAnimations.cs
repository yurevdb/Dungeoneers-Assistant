using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Default class for GroupAnimations
    /// </summary>
    public static class GroupAnimations
    {
        #region Fader

        /// <summary>
        /// Will fade in each <see cref="FrameworkElement"/> to create one singular motion.
        /// </summary>
        /// <param name="animationSeconds">The time it takes to complete one animation cycle</param>
        /// <param name="elements">The group of elements to animate</param>
        public static async void FadeAsync(float animationSeconds, params FrameworkElement[] elements)
        {
            // Time for a single animation to take
            var animationTime = animationSeconds / elements.Length;

            while (true)
            {
                foreach (var element in elements)
                {
                    var sb = new Storyboard();

                    sb.AddFadeOut(animationTime);

                    sb.Begin(element);

                    element.Visibility = Visibility.Visible;

                    await Task.Delay((int)((animationTime/elements.Length) * 1000));
                }
            }
        }

        #endregion
    }
}

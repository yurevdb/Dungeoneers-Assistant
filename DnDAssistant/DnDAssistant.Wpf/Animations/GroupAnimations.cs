using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
                    // Add dice to the grid of the element
                    ((element as Grid)?.Children[1] as Grid)?.Children.Clear();
                    ((element as Grid)?.Children[1] as Grid)?.Children.Add(DiceSelector.GetDice());

                    var sb = new Storyboard();

                    sb.AddFadeOut(animationTime);
                    
                    element.Visibility = Visibility.Visible;

                    sb.Begin(element);
                    
                    await Task.Delay((int)((animationTime/elements.Length) * 1000));
                }
            }
        }

        #endregion
    }
}

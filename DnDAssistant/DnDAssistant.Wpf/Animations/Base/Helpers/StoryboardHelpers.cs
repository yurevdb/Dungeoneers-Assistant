using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Animation helpers for <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        #region Slide in / to

        /// <summary>
        /// Adds a slide in from top animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideInFromTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, 0, offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to top animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideOutToTop(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, -offset, 0, offset),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide in from right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideInFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideOutToRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(offset, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide in from right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideInFromBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, offset, 0, -offset),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideOutToBottom(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(0, offset, 0, -offset),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide in from right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideInFromLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(-offset, 0, offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide out to right animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The offset of the animation</param>
        /// <param name="decelerationRatio"></param>
        public static void AddSlideOutToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            // Create the margin animation to slide in from top
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion

        #region Fade in / out

        /// <summary>
        /// Adds a fade in animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // Create the margin animation to slide in from top
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade out animation
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animation to slide in from top
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // Set the property for the animation to animate
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        #endregion
    }
}

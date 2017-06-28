using System.Windows;
using System.Threading.Tasks;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// An interface for animating a <see cref="FrameworkElement"/>
    /// </summary>
    public interface IAnimate
    {
        /// <summary>
        /// Animates a <see cref="FrameworkElement"/> in asynchronously
        /// </summary>
        /// <returns></returns>
        Task AnimateInAsync(Animation animation);

        /// <summary>
        /// Animates a <see cref="FrameworkElement"/> out asynchronously
        /// </summary>
        /// <returns></returns>
        Task AnimateOutAsync(Animation animation);
    }
}

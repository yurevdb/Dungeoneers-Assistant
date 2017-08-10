using System.Windows;
using System.Threading.Tasks;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// An interface for animating a <see cref="FrameworkElement"/> out
    /// </summary>
    public interface IAnimateOut
    {
        /// <summary>
        /// Animates a <see cref="FrameworkElement"/> out asynchronously
        /// </summary>
        /// <returns></returns>
        Task AnimateOutAsync(Animation animation);
    }
}

using System.Windows;
using System.Threading.Tasks;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// An interface for animating a <see cref="FrameworkElement"/> in
    /// </summary>
    public interface IAnimateIn
    {
        /// <summary>
        /// Animates a <see cref="FrameworkElement"/> in asynchronously
        /// </summary>
        /// <returns></returns>
        Task AnimateInAsync(Animation animation);
    }
}

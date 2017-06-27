using System;
using System.Threading.Tasks;
using PropertyChanged;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A base for every viewmodel. Use OnPropertyChanged for a property to update it
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel /*: INotifyPropertyChanged*/
    {
        //    /// <summary>
        //    /// The event to notify the ui that a property has been changed
        //    /// </summary>
        //    public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        //    /// <summary>
        //    /// Fires the <see cref="PropertyChanged"/> event
        //    /// </summary>
        //    /// <param name="name"></param>
        //    public void OnPropertyChanged([CallerMemberName]string name = null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //    }

        // All methods here must be protected instead of public
        // Only made usable for the ViewModels
        #region Protected Helper Methods

        /// <summary>
        /// Function to asynchronously run an <see cref="Action"/>
        /// </summary>
        /// <param name="Action">The <see cref="Action"/> to run asynchronously</param>
        /// <returns></returns>
        protected async Task RunAsync(Action Action)
        {
            // Run the task
            await Task.Run(Action);
        }

        #endregion
    }
}

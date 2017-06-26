using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A base for every viewmodel. Use OnPropertyChanged for a property to update it
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// The propertychanged event delegate
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The function the update the view with OnPropertyChanged
        /// </summary>
        /// <param name="PropertyName">The name of the property to update</param>
        protected void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            // Call the property changed event
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
        
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

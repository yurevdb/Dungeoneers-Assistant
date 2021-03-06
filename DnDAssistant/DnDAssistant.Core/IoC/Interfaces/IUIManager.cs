﻿using System.Threading.Tasks;

namespace DnDAssistant.Core
{
    /// <summary>
    /// The UI Manager that handles any ui interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Displays a single dialog window to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task ShowMessage(DialogViewModel viewModel);

        /// <summary>
        /// Displays a single dialog window to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        DialogResponse ShowResponseMessage(DialogViewModel viewModel);

        /// <summary>
        /// Opens the given window
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        void OpenWindow(Windows window);
    }
}

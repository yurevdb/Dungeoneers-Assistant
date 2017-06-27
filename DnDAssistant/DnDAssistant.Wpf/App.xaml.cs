﻿using System;
using System.IO;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom start up so we load our IoC before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let it do it's thang
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();

            // Create the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configure the application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            // Setup the binding of the solution wide accessible viewmodels
            IoC.Setup();

            // Check if the appdata folder is set up for the application
            SetupAppdata();

            // Bind the ui manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
        }

        /// <summary>
        /// Sets up the folder structure for the application data
        /// </summary>
        private void SetupAppdata()
        {
            // If the directory for the appdata does not exist...
            if (!Directory.Exists(IoC.Get<ApplicationViewModel>().BaseDataPath))
                // Create the directory
                Directory.CreateDirectory(IoC.Get<ApplicationViewModel>().BaseDataPath);

            // Add more directories if needed here
        }
    }
}

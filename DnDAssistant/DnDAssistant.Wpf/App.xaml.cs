﻿using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    internal delegate void Invoker();

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Splash Screen

        public App()
        {
            _ApplicationInitialize = _applicationInitialize;
        }

        public static new App Current => Application.Current as App;

        internal delegate void ApplicationInitializeDelegate(Splash splashWindow);
        internal ApplicationInitializeDelegate _ApplicationInitialize;

        private void _applicationInitialize(Splash splashWindow)
        {
            Thread.Sleep(30000);

            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Invoker)delegate
            {
                MainWindow = new MainWindow();
                MainWindow.Show();
            });
        } 

        #endregion

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
            Current.MainWindow = new Splash();
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

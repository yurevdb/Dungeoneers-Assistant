using System;
using System.Collections.Generic;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for SplashViewModel
    /// </summary>
    public class SplashViewModel : BaseViewModel
    {
        #region Private Members

        private Random _Rng = new Random();

        /// <summary>
        /// List of entertaining texts
        /// </summary>
        private List<string> _EntertainingTexts = new List<string>
        {
            "Showing dominance",
            "Rolled to death",
        };

        #endregion

        #region Public Properties

        /// <summary>
        /// Entertaining Text
        /// </summary>
        public string EntertainingText => GetEntertainingText();

        /// <summary>
        /// Status Text
        /// </summary>
        public string StatusText { get; set; } = "Checking for updates";

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SplashViewModel(){}

        #endregion

        #region Methods

        private string GetEntertainingText()
        {
            var number = _Rng.Next(0, _EntertainingTexts.Count);

            return _EntertainingTexts[number];
        }

        #endregion

    }
}

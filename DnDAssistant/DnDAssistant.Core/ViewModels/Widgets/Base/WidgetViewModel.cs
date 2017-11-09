using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DnDAssistant.Core
{
    /// <summary>
    /// Default class for WidgetViewModel
    /// </summary>
    public class WidgetViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The different value for rgb
        /// </summary>
        private List<string> _Colors = new List<string> { "98641A", "99241a", "328dcd" };

        #endregion

        #region Public Properties

        /// <summary>
        /// The name of the widget
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The command to execute when the widget is clicked, will most likely always be goto a page
        /// </summary>
        public ICommand Click { get; set; }

        /// <summary>
        /// The Uri to the widget image
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Indicator wether an image uri was set
        /// </summary>
        public bool ImageSet => (Image == string.Empty) ? true : false;

        /// <summary>
        /// The string for the rgb background 
        /// </summary>
        public string BackgroundColor => _Colors[new Random().Next(0, _Colors.Count)];

        /// <summary>
        /// Gets the initials of the widget name
        /// </summary>
        public string NameInitials => GetInitials();
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetViewModel()
        {

        }

        #endregion

        /// <summary>
        /// Returns the initials of the name of the widget, if 1 was given
        /// </summary>
        /// <returns></returns>
        private string GetInitials()
        {
            if (Name == string.Empty)
                return string.Empty;

            var split = Name.Split(' ');

            var initials = "";

            foreach(var s in split)
                initials += s.ToUpper().ToCharArray()[0].ToString();

            return initials;
        }

    }
}

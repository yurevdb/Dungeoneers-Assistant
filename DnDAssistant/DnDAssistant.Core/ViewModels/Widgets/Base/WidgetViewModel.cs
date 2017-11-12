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
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets the initials of the widget name
        /// </summary>
        public string NameInitials => GetInitials();

        /// <summary>
        /// Indicator wether to show this widget
        /// </summary>
        public bool ShowWidget { get; set; } = true;

        /// <summary>
        /// Items for the context menu
        /// </summary>
        public List<WidgetContextMenuItemViewModel> ContextMenu { get; set; } = 
            new List<WidgetContextMenuItemViewModel>
            {
                new WidgetContextMenuItemViewModel{
                    Text = "Add Favorite",
                    Click = new RelayParameterizedCommand((obj)=> IoC.Navigation.Add(new NavigationMenuItemViewModel(obj as WidgetViewModel)))
                },

                new WidgetContextMenuItemViewModel{
                    Text = "Remove from widgets",
                    Click = new RelayParameterizedCommand(obj => IoC.Widgets.Remove((obj as WidgetViewModel)))
                }
            };
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public WidgetViewModel()
        {
            if (ImageSet)
                BackgroundColor = SetBackground();
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

        /// <summary>
        /// Sets the background color of the widget to that of a random resourced color
        /// </summary>
        private string SetBackground()
        {
            return _Colors[new Random().Next(0, _Colors.Count)];
        }

    }
}

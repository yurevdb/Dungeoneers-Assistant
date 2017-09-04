using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A locator for viewmodels
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        public static ViewModelLocator Instance => new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Application;

        public static NavigationMenuViewModel NavigationViewModel => IoC.NavigationMenu;

        public static CharacterCreatorPageViewModel CharacterCreatorPageViewModel => IoC.CharacterCreatorPage;

        #endregion
    }
}

using Ninject;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A class for the injection of control
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to access the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => Get<IUIManager>();

        /// <summary>
        /// A shortcut to acces the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel App => Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="ErrorViewModel"/>
        /// </summary>
        public static ErrorViewModel Error => Get<ErrorViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="SplashViewModel"/>
        /// </summary>
        public static SplashViewModel Splash => Get<SplashViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="CampaignSelectorViewModel"/>
        /// </summary>
        public static CampaignSelectorViewModel CampaignSelector => Get<CampaignSelectorViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="NavigationMenuViewModel"/>
        /// </summary>
        public static NavigationMenuViewModel Navigation => Get<NavigationMenuViewModel>();

        /// <summary>
        /// A shortcut to acces the <see cref="WidgetListViewModel"/>
        /// </summary>
        public static WidgetListViewModel Widgets => Get<WidgetListViewModel>();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all
        ///       services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<ErrorViewModel>().ToConstant(new ErrorViewModel());
            Kernel.Bind<SplashViewModel>().ToConstant(new SplashViewModel());
            Kernel.Bind<CampaignSelectorViewModel>().ToConstant(new CampaignSelectorViewModel());
            Kernel.Bind<NavigationMenuViewModel>().ToConstant(new NavigationMenuViewModel());
            Kernel.Bind<WidgetListViewModel>().ToConstant(new WidgetListViewModel());
        }

        #endregion

        /// <summary>
        /// Get's service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}

﻿using System.Windows.Controls;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for NavigationMenu.xaml
    /// </summary>
    public partial class NavigationMenu : UserControl
    {
        public NavigationMenu()
        {
            InitializeComponent();
            DataContext = IoC.Navigation;
            if(!(IoC.Navigation.StaticList.Count > 0))
                IoC.Navigation.SetupNavigation();
        }
    }
}
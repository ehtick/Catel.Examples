﻿namespace Catel.Examples.Behaviors
{
    using System.Windows;
    using IoC;
    using MVVM;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //Logging.LogManager.AddDebugListener();

            var serviceLocator = ServiceLocator.Default;

            serviceLocator.RegisterType<IViewLocator, ViewLocator>();
            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.NamingConventions.Add("[UP].Views.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInBehavior.[VM]Window");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]View");
            viewLocator.NamingConventions.Add("[UP].Views.LogicInViewBase.[VM]Window");

            serviceLocator.RegisterType<IViewModelLocator, ViewModelLocator>();
            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.NamingConventions.Add("Catel.Examples.AdvancedDemo.ViewModels.[VW]ViewModel");

            base.OnStartup(e);
        }
    }
}

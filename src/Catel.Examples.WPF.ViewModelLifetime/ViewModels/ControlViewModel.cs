namespace Catel.Examples.ViewModelLifetime.ViewModels
{
    using System;
    using MVVM;

    public class ControlViewModel : ViewModelBase
    {
        public ControlViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Title = "Tab control";
        }
    }
}

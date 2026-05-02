namespace Catel.Examples.ViewModelLifetime.ViewModels;

using System;
using MVVM;

public class CreateTabWindowViewModel : ViewModelBase
{
    public CreateTabWindowViewModel(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        Title = "Create new tab";
    }

    public bool CloseWhenUnloaded { get; set; }
}

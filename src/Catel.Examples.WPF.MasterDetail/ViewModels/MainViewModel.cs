namespace Catel.Examples.MasterDetail.ViewModels;

using System;
using MVVM;

public class MainViewModel : ViewModelBase
{
    public MainViewModel(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        Title = "Master/detail example";
    }
}

namespace Catel.Examples.MultiLingual.ViewModels;

using System;
using Models;
using MVVM;

public class DataWindowViewModel : FeaturedViewModelBase
{
    public DataWindowViewModel(Language language, IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(language);

        Language = language;

        Title = "MultiLingual example";
    }

    [Model]
    [Fody.Expose("Name")]
    [Fody.Expose("Code")]
    private Language Language { get; set; }
}

namespace Catel.Examples.NestedUserControls.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Models;
    using MVVM;

    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Houses = new ObservableCollection<HouseModel>(ModelGenerator.GenerateHouses());

            Title = "Nested User Controls Example";
        }

        public ObservableCollection<HouseModel> Houses { get; private set; }
    }
}

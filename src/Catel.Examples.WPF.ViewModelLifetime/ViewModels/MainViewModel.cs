namespace Catel.Examples.ViewModelLifetime.ViewModels;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Catel.Services;
using MVVM;
using Services;

public class MainViewModel : ViewModelBase
{
    private readonly ITabService _tabService;
    private readonly IViewModelFactory _viewModelFactory;
    private readonly IUIVisualizerService _uiVisualizerService;

    private readonly DispatcherTimer _timer = new DispatcherTimer();

    public MainViewModel(IServiceProvider serviceProvider, IUIVisualizerService uiVisualizerService, 
        ITabService tabService, IViewModelFactory viewModelFactory)
        : base(serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(uiVisualizerService);
        ArgumentNullException.ThrowIfNull(tabService);

        _uiVisualizerService = uiVisualizerService;
        _tabService = tabService;
        _viewModelFactory = viewModelFactory;

        _timer.Tick += OnTimerTick;
        _timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
        _timer.Start();

        AddTab = new TaskCommand(serviceProvider, OnAddTabExecuteAsync);

        Title = "View model lifetime demo";
    }

    public int LiveViewModelCount { get; set; }

    private void OnTimerTick(object sender, EventArgs e)
    {
        LiveViewModelCount = _viewModelManager.ActiveViewModels.Count();
    }

    /// <summary>
    /// Gets the AddTab command.
    /// </summary>
    public TaskCommand AddTab { get; private set; }

    /// <summary>
    /// Method to invoke when the AddTab command is executed.
    /// </summary>
    private async Task OnAddTabExecuteAsync()
    {
        var vm = _viewModelFactory.CreateRequiredViewModel<CreateTabWindowViewModel>(null);
        var result = await _uiVisualizerService.ShowDialogAsync(vm);

        if (result.DialogResult ?? false)
        {
            _tabService.AddTab(vm.CloseWhenUnloaded);
        }
    }
}

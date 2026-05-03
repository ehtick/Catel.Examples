namespace Catel.Examples.Commanding;

using System.Windows;
using System.Windows.Input;
using Catel.Examples.Commanding.Views;
using Catel.IoC;
using Catel.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVVM;
using InputGesture = Windows.Input.InputGesture;

public partial class App : Application
{
#pragma warning disable IDISP006 // Implement IDisposable
    private readonly IHost _host;
#pragma warning restore IDISP006 // Implement IDisposable

    public App()
    {
        var hostBuilder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddCatelCore();
                services.AddCatelMvvm();

                services.AddLogging(x =>
                {
                    x.AddConsole();
                    x.AddDebug();

                    services.AddLogging(x =>
                    {
                        x.AddConsole();
                        x.AddDebug();
                    });
                });
            });

        _host = hostBuilder.Build();

        IoCContainer.ServiceProvider = _host.Services;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = _host.Services;

        serviceProvider.CreateTypesThatMustBeConstructedAtStartup();

        TypeCache.InitializeTypes(typeof(App).Assembly);

        // Registered as command
        var commandManager = serviceProvider.GetRequiredService<ICommandManager>();
        commandManager.CreateCommand(Commands.Refresh, new InputGesture(Key.F5));

        // Registered in command container
        commandManager.CreateCommandWithGesture(serviceProvider, typeof(Commands), Commands.GlobalAction);
        commandManager.CreateCommandWithGesture(serviceProvider, typeof(Commands), Commands.Test1);
        commandManager.CreateCommandWithGesture(serviceProvider, typeof(Commands), Commands.Test2);

        var mainWindow = ActivatorUtilities.CreateInstance<MainWindow>(serviceProvider);
        mainWindow.Show();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        using (_host)
        {
            await _host.StopAsync();
        }

        base.OnExit(e);
    }
}

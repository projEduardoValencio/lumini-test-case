using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Application.UseCases.Route;
using Lumini.Domain.Enums;
using Lumini.Domain.Interfaces.Repositories;
using Lumini.Infrastructure.DataAccess;
using Lumini.Infrastructure.Factories;
using Lumini.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lumini.ConsoleApp;

class LuminiConsoleApp
{
    static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var consoleApp = serviceProvider.GetService<LuminiConsoleApp>();
        await consoleApp!.Run();
    }

    private readonly IRouteUseCase _routeUseCase;
    
    public LuminiConsoleApp(IRouteUseCase routeUseCase)
    {
        _routeUseCase = routeUseCase;
    }
    
    private async Task Run()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(
            "===================================\n" +
            "Lumini Test Case - Eduardo Valencio\n" +
            "==================================="
        );
        Console.ResetColor();
        
        while (true)
        {
            ConsoleOptions option = Helpers.SelectionHelper.GetOption();

            if (option == ConsoleOptions.Exit)
            {
                Console.WriteLine("Saindo...");
                break;
            }
            
            await Helpers.ActionHelper.ExecuteAction(option, _routeUseCase);
        }
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        
        string connectionString = "Data Source=database.db";

        services.AddSingleton<LuminiDbContext>(_ => new DbContextFactory(connectionString).CreateSqliteDbContext());
        services.AddSingleton<IRouteRepository, RouteRepository>();
        services.AddSingleton<IRouteUseCase, RouteUseCase>();
        services.AddSingleton<LuminiConsoleApp>();

        return services.BuildServiceProvider();
    }
}
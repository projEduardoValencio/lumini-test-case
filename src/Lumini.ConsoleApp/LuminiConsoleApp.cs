using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Application.UseCases.Route;
using Lumini.Domain.Enums;
using Lumini.Infrastructure.DataAccess;
using Lumini.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lumini.ConsoleApp;

class LuminiConsoleApp
{
    static async Task Main(string[] args)
    {
        var consoleApp = new LuminiConsoleApp();
        await consoleApp.Run();
    }

    private readonly IRouteUseCase _routeUseCase;
    
    public LuminiConsoleApp()
    {
        string connectionString = "Data Source=lumini.db";
        var optionsBuilder = new DbContextOptionsBuilder<LuminiDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        var dbContext = new LuminiDbContext(optionsBuilder.Options);
        dbContext.Database.Migrate();
        
        var routeRepository = new RouteRepository(dbContext);
        _routeUseCase = new RouteUseCase(routeRepository);
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
}
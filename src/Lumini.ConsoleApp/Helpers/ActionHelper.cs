using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Domain.Enums;

namespace Lumini.ConsoleApp.Helpers;

public static class ActionHelper
{
    public static IRouteUseCase RouteUseCase { get; set; }
    
    public static void ExecuteAction(ConsoleOptions option, IRouteUseCase routeUseCase)
    {
        switch (option)
        {
            case ConsoleOptions.AddRoute:
                AddRoute(routeUseCase);
                break;
            case ConsoleOptions.RemoveRoute:
                RemoveRoute(routeUseCase);
                break;
            case ConsoleOptions.ListRoutes:
                ListRoutes(routeUseCase);
                break;
            case ConsoleOptions.CalculateTravelPath:
                CalculateTravelPath(routeUseCase);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    
    private static void AddRoute(IRouteUseCase routeUseCase)
    {
        Console.WriteLine("\nAdicionando rota...");
        
        Console.Write("Origem: ");
        string origin = Console.ReadLine();
        
        Console.Write("Destino: ");
        string destination = Console.ReadLine();
        
        Console.Write("Valor: R$ ");
        decimal value = Convert.ToDecimal(Console.ReadLine());
        
        // Verify if route already exists
        // Add route to database
    }
    
    private static void RemoveRoute(IRouteUseCase routeUseCase)
    {
        Console.WriteLine("\nRemovendo rota...");
        
        Console.Write("Origem: ");
        string origin = Console.ReadLine();
        
        Console.Write("Destino: ");
        string destination = Console.ReadLine();
        
        // Remove route from database
    }
    
    private static void ListRoutes(IRouteUseCase routeUseCase)
    {
        Console.WriteLine("\nListando rotas...");
        
        // List all routes from database
    }

    private static void updateRouteValue(string origin, string destination, IRouteUseCase routeUseCase)
    {
        Console.WriteLine("\nAtualizando valor da rota...");
        
        Console.Write($"Novo valor para rota {origin} - {destination}: R$ ");
        decimal value = Convert.ToDecimal(Console.ReadLine());
        
        // Update route value in database
    }
    
    private static void CalculateTravelPath(IRouteUseCase routeUseCase)
    {
        Console.WriteLine("\nCalculando rota...");
        
        Console.Write("Origem: ");
        string origin = Console.ReadLine();
        
        Console.Write("Destino: ");
        string destination = Console.ReadLine();
        
        // Calculate travel path
    }
}
using Lumini.Domain.Enums;

namespace Lumini.ConsoleApp.Helpers;

public static class ActionHelper
{
    public static void ExecuteAction(ConsoleOptions option)
    {
        switch (option)
        {
            case ConsoleOptions.AddRoute:
                AddRoute();
                break;
            case ConsoleOptions.RemoveRoute:
                RemoveRoute();
                break;
            case ConsoleOptions.ListRoutes:
                ListRoutes();
                break;
            case ConsoleOptions.CalculateTravelPath:
                CalculateTravelPath();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    
    private static void AddRoute()
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
    
    private static void RemoveRoute()
    {
        Console.WriteLine("\nRemovendo rota...");
        
        Console.Write("Origem: ");
        string origin = Console.ReadLine();
        
        Console.Write("Destino: ");
        string destination = Console.ReadLine();
        
        // Remove route from database
    }
    
    private static void ListRoutes()
    {
        Console.WriteLine("\nListando rotas...");
        
        // List all routes from database
    }

    private static void updateRouteValue(string origin, string destination)
    {
        Console.WriteLine("\nAtualizando valor da rota...");
        
        Console.Write($"Novo valor para rota {origin} - {destination}: R$ ");
        decimal value = Convert.ToDecimal(Console.ReadLine());
        
        // Update route value in database
    }
    
    private static void CalculateTravelPath()
    {
        Console.WriteLine("\nCalculando rota...");
        
        Console.Write("Origem: ");
        string origin = Console.ReadLine();
        
        Console.Write("Destino: ");
        string destination = Console.ReadLine();
        
        // Calculate travel path
    }
}
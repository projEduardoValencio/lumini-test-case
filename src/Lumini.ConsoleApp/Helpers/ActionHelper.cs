using System.Text;
using Lumini.Application.Interfaces.UseCases.Route;
using Lumini.Communication.Requests.Route;
using Lumini.Communication.Responses.Route;
using Lumini.ConsoleApp.Utils;
using Lumini.Domain.Enums;
using Lumini.Exceptions.Exceptions.Route;

namespace Lumini.ConsoleApp.Helpers;

public static class ActionHelper
{
    public static async Task ExecuteAction(ConsoleOptions option, IRouteUseCase routeUseCase)
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
                await ListRoutes(routeUseCase);
                break;
            case ConsoleOptions.CalculateTravelPath:
                await CalculateTravelPath(routeUseCase);
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    
    private static void AddRoute(IRouteUseCase routeUseCase)
    {
        ConsoleUtils.WriteOperationTitle("\nAdicionar rota...");

        string origin;
        string destination;
        while (true)
        {
            origin = ConsoleUtils.ReadNonNullInput("Origem: ");
            destination = ConsoleUtils.ReadNonNullInput("Destino: ");

            if (origin != destination)
            {
                break;
            };
            
            ConsoleUtils.WriteError("Origem e destino não podem ser iguais.");
        }

        decimal value = ConsoleUtils.ReadDecimalValue("Custo: R$ ");

        RequestsRegisterRoute request = new RequestsRegisterRoute
        {
            Origin = origin,
            Destination = destination,
            Value = value
        };

        try
        {
            routeUseCase.CreateRoute(request);
            ConsoleUtils.WriteSuccess("Rota criada com sucesso.");
        }
        catch (RouteAlreadyExistsException)
        {
            Console.WriteLine("A Rota informada já existe.");
            bool updateValue = ConsoleUtils.ReadYesNoInput("Deseje atualizar o valor da rota existente? (S/N): ");

            if (!updateValue) return;
            
            decimal newValue = ConsoleUtils.ReadDecimalValue("Novo valor de custo para a rota: R$ ");

            RequestUpdateRouteValue requestUpdateRouteValue = new RequestUpdateRouteValue
            {
                Origin = origin,
                Destination = destination,
                NewValue = newValue
            };

            try
            {
                routeUseCase.UpdateRouteValue(requestUpdateRouteValue);
                ConsoleUtils.WriteSuccess("Valor da rota atualizado com sucesso.");
            } catch (Exception e)
            {
                ConsoleUtils.WriteError(e.Message);
            }
        }
        catch (Exception e)
        {
            ConsoleUtils.WriteError(e.Message);
        }
    }
    
    private static void RemoveRoute(IRouteUseCase routeUseCase)
    {
        ConsoleUtils.WriteOperationTitle("\nRemover rota...");
        
        string origin = ConsoleUtils.ReadNonNullInput("Origem: ");
        
        string destination = ConsoleUtils.ReadNonNullInput("Destino: ");

        try
        {
            RequestDeleteRoute request = new RequestDeleteRoute
            {
                Origin = origin,
                Destination = destination
            };

            routeUseCase.DeleteRoute(request);
            
            ConsoleUtils.WriteSuccess("Rota removida com sucesso.");
        }
        catch (RouteNotFoundException)
        {
            Console.WriteLine("A Rota informada não existe.");
        }
        catch (Exception e)
        {
            ConsoleUtils.WriteError(e.Message);
        }
    }
    
    private static async Task ListRoutes(IRouteUseCase routeUseCase)
    {
        ConsoleUtils.WriteOperationTitle("\nListando registro de rotas...");

        try
        {
            ResponseRouteList routes = await routeUseCase.ListRoutes();
            
            foreach (var route in routes.Routes)
            {
                Console.WriteLine($"{route.Origin}-{route.Destination} R$ {Math.Round(route.Value, 2)}");
            }
        }
        catch (Exception e)
        {
            ConsoleUtils.WriteError(e.Message);
        }
    }
    
    private static async Task CalculateTravelPath(IRouteUseCase routeUseCase)
    {
        ConsoleUtils.WriteOperationTitle("\nCalcular rota com menor custo...");
        
        string origin = ConsoleUtils.ReadNonNullInput("Origem: ");
        
        string destination = ConsoleUtils.ReadNonNullInput("Destino: ");

        RequestLowCostTravel request = new RequestLowCostTravel
        {
            Origin = origin,
            Destination = destination
        };

        try
        {
            ResponseLowCostTravel response = await routeUseCase.LowCostTravelPath(request);

            if (response.Path.Count is 0)
            {
                ConsoleUtils.WriteError("Não foi possível encontrar uma rota para o destino informado.");
            }

            StringBuilder stringBuilderPath = new StringBuilder();

            foreach (var path in response.Path)
            {
                stringBuilderPath.Append(path);
                stringBuilderPath.Append(" -> ");
            }

            ConsoleUtils.WriteSuccess(
                $"Rota mais econômica: {stringBuilderPath.ToString().TrimEnd(' ', '-')} | Custo total: R$ {Math.Round(response.TotalValue, 2)}");
        }
        catch (NoPathAvailableException)
        {
            ConsoleUtils.WriteError("Não foi possível encontrar uma rota para o destino informado.");
        }
        catch (Exception e)
        {
            ConsoleUtils.WriteError(e.Message);
            throw;
        }
    }
}
using Lumini.Domain.Enums;

namespace Lumini.ConsoleApp.Utils;

public class ConvertConsoleOptionsEnum
{
    public static string ConverteToString(ConsoleOptions option)
    {
        switch (option)
        {
            case ConsoleOptions.Exit:
                return "Sair";
            case ConsoleOptions.AddRoute:
                return "Adicionar rota";
            case ConsoleOptions.RemoveRoute:
                return "Remover rota";
            case ConsoleOptions.ListRoutes:
                return "Listar rotas";
            case ConsoleOptions.CalculateTravelPath:
                return "Calcular rota";
            default:
                return "";
        }
    }
}
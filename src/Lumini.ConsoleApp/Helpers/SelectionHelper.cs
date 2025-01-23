using Lumini.ConsoleApp.Utils;
using Lumini.Domain.Enums;

namespace Lumini.ConsoleApp.Helpers;

public static class SelectionHelper
{
    public static ConsoleOptions GetOption()
    {
        
        Console.WriteLine("\nSelecione uma das opções abaixo: ");
        List<ConsoleOptions> options = Enum.GetValues(typeof(ConsoleOptions)).Cast<ConsoleOptions>().ToList();
        
        foreach (var option in options)
        {
            Console.WriteLine($"{(int)option} - {ConvertConsoleOptionsEnum.ConverteToString(option)}");
        }
        
        try
        {
            Console.Write("Opção: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            if (options.Contains((ConsoleOptions)selectedOption))
            {
                return (ConsoleOptions) selectedOption;
            }

            throw new ArgumentException("Opção inválida.");
        }
        catch (Exception)
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            return GetOption();
        }
    }
}
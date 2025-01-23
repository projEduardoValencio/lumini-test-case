using Lumini.Domain.Enums;

namespace Lumini.ConsoleApp;

class LuminiConsoleApp
{
    static void Main(string[] args)
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
            
            Helpers.ActionHelper.ExecuteAction(option);
        }
    }
}
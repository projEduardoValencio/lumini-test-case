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
        
        Helpers.SelectionHelper.GetOption();
        
    }
}
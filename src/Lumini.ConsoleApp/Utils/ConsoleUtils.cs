namespace Lumini.ConsoleApp.Utils;

public static class ConsoleUtils
{
    public static void WriteError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static void WriteSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void WriteOperationTitle(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public static decimal ReadDecimalValue(string message)
    {
        decimal value;
        while (true)
        {
            Console.Write(message);
            try
            {
                value = Convert.ToDecimal(Console.ReadLine() ?? "0");
                
                if (value is not 0)
                {
                    break;
                }
                
                Console.WriteLine("Favor informar um valor valido.");
            }
            catch (FormatException)
            {
                WriteError("Valor inválido. Por favor, insira um número decimal.");
            }
            catch (ArgumentOutOfRangeException)
            {
                WriteError("Valor muito grande. Por favor, insira um valor menor.");
            }
            catch (Exception)
            {
                WriteError("Erro ao ler valor. Por favor, tente novamente.");
            }
        }

        return value;
    }
    
    public static string ReadNonNullInput(string message)
    {
        string? input;
        while (true)
        {
            Console.Write(message);

            try
            {
                input = Console.ReadLine()?.Trim().ToUpper().Replace(" ", "");
                if (input is not null)
                {
                    break;
                }
                
                Console.WriteLine("Favor informar um valor.");
            } 
            catch (ArgumentOutOfRangeException)
            {
                WriteError("Valor muito grande. Por favor, insira um valor menor.");
            }
            catch (Exception)
            {
                WriteError("Erro ao ler valor. Por favor, tente novamente.");
            }
        }

        return input;
    }
    
    public static bool ReadYesNoInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim().ToUpper();

            if (input == "S")
            {
                return true;
            }
            else if (input == "N")
            {
                return false;
            }
            else
            {
                WriteError("Entrada inválida. Por favor, insira 'S' para Sim ou 'N' para Não.");
            }
        }
    }
}
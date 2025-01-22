﻿namespace Lumini.ConsoleApp;

class Program
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
    }
}
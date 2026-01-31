using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Shared
{
    public static class ConsoleUtils
    {
        public static void PrintHeader(string title)
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine(CenterText(title, 60));
            Console.WriteLine(new string('=', 60));
            Console.WriteLine();
        }

        public static void PrintSection(string sectionTitle)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"{sectionTitle}");
            Console.WriteLine(new string('-', 50));
        }

        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        public static string CenterText(string text, int width)
        {
            if (text.Length >= width) return text;

            int padding = (width - text.Length) / 2;
            return text.PadLeft(padding + text.Length).PadRight(width);
        }

        public static void WaitForAnyKey(string message = "Presione cualquier tecla para continuar...")
        {
            Console.WriteLine($"\n{message}");
            Console.ReadKey();
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static string ReadLineWithPrompt(string prompt, string defaultValue = "")
        {
            Console.Write($"{prompt}: ");
            var input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
        }

        public static bool ReadYesNo(string prompt, bool defaultValue = false)
        {
            Console.Write($"{prompt} (s/n) [{(defaultValue ? "s" : "n")}]: ");
            var input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input)) return defaultValue;
            return input == "s" || input == "si";
        }
    }
}

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


    }
}

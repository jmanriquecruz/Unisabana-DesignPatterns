using DesignPatternsDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Team
{
    public static class TeamDemo
    {
        private static readonly IReadOnlyList<TeamMember> Team = new List<TeamMember>
        {
            new("Jose Manrique", "CC - 1127597008"),
        };

        public static void Run()
        {
            ConsoleUtils.ClearConsole();
            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleUtils.PrintHeader("EQUIPO DE DESARROLLO");
            Console.ResetColor();

            PrintTableHeader();

            foreach (var member in Team)
            {
                PrintRow(member);
            }

            PrintTableFooter();

            ConsoleUtils.WaitForAnyKey();
        }

        private static void PrintTableHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────────────┬───────────────────┐");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("│ NOMBRE                    │    CEDULA         │");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("├───────────────────────────┼───────────────────┤");
            Console.ResetColor();
        }

        private static void PrintRow(TeamMember member)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("│ ");
            Console.Write($"{member.Name,-25}");
            Console.Write(" │ ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{member.PersonId,-17}");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" │");
            Console.ResetColor();
        }

        private static void PrintTableFooter()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("└───────────────────────────┴───────────────────┘");
            Console.ResetColor();
        }
    }
}


using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation;
using DesignPatternsDemo.Scenarios._03_ChatMediator.Presentation;
using DesignPatternsDemo.Shared;
using DesignPatternsDemo.Team;

namespace DesignPatternsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Demo Patrones de diseño";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            var menu = new MenuSystem("Demostración patrones de diseño");

            menu.AddMenuItem("1", "Compañia automotriz - Patron Builder",
                () => BuilderDemo.Run());

            menu.AddMenuItem("2", "Multiplatforma Notificationes - Patron Bridge",
                () => BridgeDemo.Run());

            menu.AddMenuItem("3", "Sistema de Chat - Patron Mediator",
                () => MediatorDemo.Run());

            menu.AddMenuItem("4", "Acerca de esta aplicación",
                () => ShowAboutInfo());
            menu.AddMenuItem("5", "Integrantes del equipo",
                () => TeamDemo.Run());

            menu.Show();
        }

        private static void ShowAboutInfo()
        {
            ConsoleUtils.PrintHeader("APLICACIÓN DE CONSOLA");
            Console.WriteLine("ESTRUCTURA DEL PROYECTO:");
            Console.WriteLine("├── 01_VehicleBuilder/       # Patrón Builder");
            Console.WriteLine("├── 02_NotificationBridge/   # Patrón Bridge");
            Console.WriteLine("├── 03_ChatMediator/         # Patrón Mediator");
            Console.WriteLine("└── Shared/                  # Utilidades compartidas");

            ConsoleUtils.WaitForAnyKey("Presione cualquier tecla para continuar...");
        }
    }
}


using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation;
using DesignPatternsDemo.Shared;

namespace DesignPatternsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Design Patterns Demo";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            var menu = new MenuSystem("Demostración patrones de diseño");

            menu.AddMenuItem("1", "Compañia automotriz - Patron Builder",
                () => BuilderDemo.Run());

            menu.AddMenuItem("2", "Multiplatforma Notificationes - Patron Bridge",
                () => Console.WriteLine("Patron Bridge - pronto!"));

            menu.AddMenuItem("3", "Sistema de Chat - Patron Mediator",
                () => Console.WriteLine("Patron Mediator -pronto!"));

            menu.AddMenuItem("4", "Acerca de esta aplicación",
                () => ShowAboutInfo());

            menu.Show();
        }

        private static void ShowAboutInfo()
        {
            ConsoleUtils.PrintHeader("ACERCA DE ESTA APLICACIÓN");

            Console.WriteLine("Esta aplicación demuestra tres patrones de diseño comunes:");
            Console.WriteLine();

            Console.WriteLine("1. PATRÓN BUILDER (CONSTRUCTOR)");
            Console.WriteLine("- Problema que resuelve: Constructor telescópico con muchos parámetros");
            Console.WriteLine("- Se usa en: Sistema de personalización de vehículos");
            Console.WriteLine("- Beneficios: Inmutabilidad, interfaz fluida, validaciones centralizadas");
            Console.WriteLine();

            Console.WriteLine("2. PATRÓN BRIDGE (PUENTE)");
            Console.WriteLine("- Problema que resuelve: Explosión combinatoria de clases");
            Console.WriteLine("- Se usa en: Sistema de notificaciones multiplataforma");
            Console.WriteLine("- Beneficios: Separación de abstracción e implementación");
            Console.WriteLine();

            Console.WriteLine("3. PATRÓN MEDIATOR (MEDIADOR)");
            Console.WriteLine("- Problema que resuelve: Alto acoplamiento entre objetos");
            Console.WriteLine("- Se usa en: Sistema de chat grupal");
            Console.WriteLine("- Beneficios: Comunicación centralizada, dependencias reducidas");
            Console.WriteLine();

            Console.WriteLine("Cada patrón está implementado en su propia carpeta de escenario");
            Console.WriteLine("con separación clara de responsabilidades (Domain/Application/Presentation).");
            Console.WriteLine();

            Console.WriteLine("ESTRUCTURA DEL PROYECTO:");
            Console.WriteLine("├── 01_VehicleBuilder/       # Patrón Builder");
            Console.WriteLine("├── 02_NotificationBridge/   # Patrón Bridge");
            Console.WriteLine("├── 03_ChatMediator/         # Patrón Mediator");
            Console.WriteLine("└── Shared/                  # Utilidades compartidas");

            ConsoleUtils.WaitForAnyKey("Presione cualquier tecla para continuar...");
        }
    }
}



namespace DesignPatternsDemo.Shared
{
    public partial class MenuSystem
    {
        private readonly Dictionary<string, MenuItem> menuItems = new();
        private readonly string title;

        public MenuSystem(string title = "MENU")
        {
            this.title = title;
        }

        public void AddMenuItem(string key, string description, Action action)
        {
            this.menuItems[key.ToUpper()] = new MenuItem(key, description, action);
        }

        public void Show()
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.Clear();
                ConsoleUtils.PrintHeader(title);

                foreach (var item in menuItems.Values.OrderBy(m => m.Key))
                {
                    Console.WriteLine($"{item.Key}. {item.Description}");
                }
                Console.WriteLine("X. Salida");

                Console.Write("\nSeleccione una opción: ");
                var choice = Console.ReadLine()?.Trim().ToUpper();

                if (choice == "X")
                {
                    exitRequested = true;
                    Console.WriteLine("\nAdios!");
                    continue;
                }

                if (choice != null && menuItems.TryGetValue(choice, out var menuItem))
                {
                    Console.Clear();
                    ConsoleUtils.PrintHeader(menuItem.Description);
                    menuItem.Action?.Invoke();

                    if (!exitRequested)
                    {
                        Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nOpción invalida. Por favor intente de nuevo.");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}

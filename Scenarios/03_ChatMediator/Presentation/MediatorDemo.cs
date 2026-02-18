using DesignPatternsDemo.Scenarios._03_ChatMediator.Application.Services;
using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Rooms;

namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Presentation
{
    public static class MediatorDemo
    {
        public static void Run()
        {
            IChatMediator chatRoom = new ChatRoom();
            var service = new ChatService(chatRoom);

            bool continueDemo = true;

            while (continueDemo)
            {
                Console.WriteLine("\n=== CHAT MEDIATOR DEMO ===");
                Console.WriteLine("1. Agregar usuario");
                Console.WriteLine("2. Enviar mensaje");
                Console.WriteLine("3. Listar usuarios");
                Console.WriteLine("4. Salir");

                Console.Write("\nSeleccione opción: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddUser(service);
                        break;

                    case "2":
                        SendMessage(chatRoom);
                        break;

                    case "3":
                        ListUsers(service);
                        break;

                    case "4":
                        continueDemo = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (continueDemo)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void AddUser(ChatService service)
        {
            Console.Write("Nombre del usuario: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Nombre inválido.");
                return;
            }

            service.AddUser(name);
            Console.WriteLine($"Usuario '{name}' agregado al chat.");
        }

        private static void SendMessage(IChatMediator mediator)
        {
            if (!mediator.Users.Any())
            {
                Console.WriteLine("No hay usuarios en el chat.");
                return;
            }

            Console.WriteLine("Usuarios disponibles:");
            for (int i = 0; i < mediator.Users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mediator.Users[i].Name}");
            }

            Console.Write("Seleccione usuario: ");
            if (!int.TryParse(Console.ReadLine(), out int index) ||
                index < 1 || index > mediator.Users.Count)
            {
                Console.WriteLine("Selección inválida.");
                return;
            }

            Console.Write("Mensaje: ");
            var message = Console.ReadLine();

            mediator.Users[index - 1].Send(message ?? "");
        }

        private static void ListUsers(ChatService service)
        {
            var users = service.GetUsers();

            if (!users.Any())
            {
                Console.WriteLine("No hay usuarios registrados.");
                return;
            }

            Console.WriteLine("Usuarios en la sala:");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }
    }
}

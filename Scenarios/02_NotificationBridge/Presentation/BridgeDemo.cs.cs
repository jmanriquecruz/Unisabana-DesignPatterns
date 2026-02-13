using DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Factories;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Services;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation
{
    public static class BridgeDemo
    {
        public static void Run()
        {
           
            var platformFactory = new NotificationPlatformFactory();
            bool continueDemo = true;

            while (continueDemo)
            {
                Console.WriteLine("\n=== MENU NOTIFICACIONES ===");
                Console.WriteLine("Seleccione plataforma:");
                Console.WriteLine("1. Web");
                Console.WriteLine("2. Móvil");
                Console.WriteLine("3. Escritorio");
                Console.WriteLine("4. Volver");

                Console.Write("\nSeleccione una opción: ");
                var platformOption = Console.ReadLine();

                if (platformOption == "4")
                    break;

                INotificationPlatform platform;

                try
                {
                    platform = platformFactory.Create(platformOption!);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Continue();
                    continue;
                }

                if (platform is null)
                {
                    Console.WriteLine("Plataforma inválida.");
                    Continue();
                    continue;
                }

                Console.Clear();
                GetNotifications(platform, continueDemo);
               
            }
        }

        private static void GetNotifications(INotificationPlatform platform, bool continueDemo)
        {
            var service = new NotificationService();
            Console.WriteLine("Seleccione tipo de notificación:");
            Console.WriteLine("1. Mensaje");
            Console.WriteLine("2. Alerta");
            Console.WriteLine("3. Advertencia");
            Console.WriteLine("4. Volver");

            Console.Write("\nOpción: ");
            var notificationOption = Console.ReadLine();

            try
            {
                switch (notificationOption)
                {
                    case "1":
                        service.SendMessage(platform);
                        break;

                    case "2":
                        service.SendAlert(platform);
                        break;

                    case "3":
                        service.SendWarning(platform);
                        break;

                    case "4":
                        continueDemo = false;
                        Continue();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }


        }

        private static void Continue()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

}

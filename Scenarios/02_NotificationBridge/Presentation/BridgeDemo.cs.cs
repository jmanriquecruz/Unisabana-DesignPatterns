using DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Factories;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Services;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation 
{ 
    public static class BridgeDemo 
    { 
        public static void Run() 
        { 
            bool continueDemo = true; 
            while (continueDemo) 
            { 
                Console.WriteLine("\n=== NOTIFICATIONS MENU ==="); 
                Console.WriteLine("Select platform:"); 
                Console.WriteLine("1. Web"); 
                Console.WriteLine("2. Mobile"); 
                Console.WriteLine("3. Desktop"); 
                Console.WriteLine("4. Go back"); 
                Console.Write("\nSelect an option: "); 
                var platformOption = Console.ReadLine();
                if (platformOption == "4")
                {
                    break;
                }
                SetPlatform(platformOption, continueDemo); 
            } 
        } 
        private static void SetPlatform(string? platformOption, bool continueDemo) 
        { 
            var platformFactory = new NotificationPlatformFactory(); 
            INotificationPlatform platform = null; 
            try 
            { 
                platform = platformFactory.Create(platformOption!);
            } catch (ArgumentException ex) 
            { 
                Console.WriteLine(ex.Message); 
                Continue();
            }
            if (platform is null) 
            { 
                Console.WriteLine("Invalid platform."); 
                Continue(); 
            } 
            Console.Clear(); 
            GetNotifications(platform, continueDemo); 
        } 
        private static void GetNotifications(INotificationPlatform platform, bool continueDemo) 
        {
            var service = new NotificationService();
            Console.WriteLine("Seleccione tipo de notificación:");
            Console.WriteLine("1. Message"); 
            Console.WriteLine("2. Alert"); 
            Console.WriteLine("3. Warning"); 
            Console.WriteLine("4. Volver"); 
            Console.Write("\nOption: "); 
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
                        Console.WriteLine("Invalid option."); 
                        break; 
                } 
            } catch (Exception ex) 
            { 
                Console.WriteLine($"Error: {ex.Message}"); 
            } 
        } 
        private static void Continue() 
        { 
            Console.WriteLine("\nPresione una tecla para continuar."); 
            Console.ReadKey(); Console.Clear(); 
        } 
    } 
}
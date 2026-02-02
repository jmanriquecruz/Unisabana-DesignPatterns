using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Services;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Exceptions;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation
{
    public static class BuilderDemo
    {
        public static void Run()
        {

            var service = new VehicleService(new VehicleBuilder());
            bool continueDemo = true;

            while (continueDemo)
            {
                Console.WriteLine("\n=== MENU CONSTRUIR VEHICULO  ===");
                Console.WriteLine("1. Crear vehículo personalizado");
                Console.WriteLine("2. Crear vehículo deportivo(pre-configurado)");
                Console.WriteLine("3. Create vehículo familiar (pre-configurado)");
                Console.WriteLine("4. Crear vehículo eco (pre-configurado)");
                Console.WriteLine("5. Mostrar todos los vehículos");
                Console.WriteLine("6. Consolidado inventario");
                Console.WriteLine("7. Limpiar Inventario");
                Console.WriteLine("8. Volver");

                Console.Write("\nSeleccione opción: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCustomVehicle(service);
                        break;
                    case "2":
                        CreateSportsCar(service);
                        break;
                    case "3":
                        CreateFamilyCar(service);
                        break;
                    case "4":
                        CreateEcoCar(service);
                        break;
                    case "5":
                        ShowAllVehicles(service);
                        break;
                    case "6":
                        ShowInventorySummary(service);
                        break;
                    case "7":
                        ClearInventory(service);
                        break;
                    case "8":
                        continueDemo = false;
                        break;
                    default:
                        Console.WriteLine("Opción invalida.");
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

        private static void CreateCustomVehicle(VehicleService service)
        {
            Console.WriteLine("\n--- Crear vehículo personalizado ---");

            Console.Write("Tipo de motor ( V6, V8, Hibrido): ");
            string engine = Console.ReadLine() ?? "V6";

            Console.WriteLine("Colores disponibles: " + string.Join(", ", VehicleColor.GetAvailableColors().Select(c => c.Value)));
            string color = Console.ReadLine() ?? "Negro";

            Console.Write("Incluir Sunroof? (s/n): ");
            bool sunroof = (Console.ReadLine()?.ToLower() ?? "n") == "s";

            Console.Write("Incluir GPS? (s/n): ");
            bool gps = (Console.ReadLine()?.ToLower() ?? "n") == "s";

            Console.Write("Incluir Camara? (s/n): ");
            bool camera = (Console.ReadLine()?.ToLower() ?? "n") == "s";

            try
            {
                var vehicle = service.CreateCustomVehicle(engine.Trim(), color.Trim(), sunroof, gps, camera);
                Console.WriteLine($"\nVehiculo creado exitosamente!");
                Console.WriteLine($"   Descripción: {vehicle.GetDescription()}");
                Console.WriteLine($"   Precio: {vehicle.CalculateBasePrice():C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n error: {ex.Message}");
            }
            catch (DomainException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Intente nuevamente.");
            }
        }

        private static void CreateSportsCar(VehicleService service)
        {
            Console.Write("\nIngrese color para vehículo deportivo (predeterminado: Rojo): ");
            Console.WriteLine("Colores disponibles: " + string.Join(", ", VehicleColor.GetAvailableColors().Select(c => c.Value)));
            string color = Console.ReadLine() ?? "Rojo";

            var vehicle = service.CreateSportsCar(color);
            Console.WriteLine($"\n Vehículo deportivo creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculateBasePrice()}");
        }

        private static void CreateFamilyCar(VehicleService service)
        {
            Console.Write("\nIngrese color para vehiculo familiar (predeterminado: Azul): ");
            Console.WriteLine("Colores disponibles: " + string.Join(", ", VehicleColor.GetAvailableColors().Select(c => c.Value)));
            string color = Console.ReadLine() ?? "Azul";

            var vehicle = service.CreateFamilyCar(color);
            Console.WriteLine($"\n Vehículo familiar creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculateBasePrice()}");
        }

        private static void CreateEcoCar(VehicleService service)
        {
            Console.Write("\nIngresar colocar para vehiculo Eco (predeterminado: Verde): ");
            Console.WriteLine("Colores disponibles: " + string.Join(", ", VehicleColor.GetAvailableColors().Select(c => c.Value)));
            string color = Console.ReadLine() ?? "Verde";

            var vehicle = service.CreateEcoCar(color);
            Console.WriteLine($"\nVehículo Eco creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculateBasePrice()}");
        }

        private static void ShowAllVehicles(VehicleService service)
        {
            var vehicles = service.GetAllVehicles();

            if (vehicles.Count == 0)
            {
                Console.WriteLine("\nNo existen vehiculo en el inventario.");
                return;
            }

            Console.WriteLine($"\n=== INVENTARIO DE VEHÍCULOS ({vehicles.Count} ) ===");

            for (int i = 0; i < vehicles.Count; i++)
            {
                var vehicle = vehicles[i];
                Console.WriteLine($"\nVehículo #{i + 1}:");
                Console.WriteLine($"{vehicle.GetDescription()}");
                Console.WriteLine($"Precio: {vehicle.CalculateBasePrice()}");
            }
        }

        private static void ShowInventorySummary(VehicleService service)
        {
            var vehicles = service.GetAllVehicles();
            var byColor = service.GetVehiclesByColor();
            var totalValue = service.CalculateTotalInventoryValue();

            Console.WriteLine("\n=== RESUMEN INVENTARIO ===");
            Console.WriteLine($"Total VehículoS: {vehicles.Count}");
            Console.WriteLine($"Total general: {totalValue:C}");

            if (byColor.Any())
            {
                Console.WriteLine("\nVehículos por color:");
                foreach (var kvp in byColor)
                {
                    Console.WriteLine($"  {kvp.Key}: {kvp.Value} Vehículo(s)");
                }
            }
        }

        private static void ClearInventory(VehicleService service)
        {
            service.ClearInventory();
            Console.WriteLine("\nInventario eliminado!");
        }

       
    }
}

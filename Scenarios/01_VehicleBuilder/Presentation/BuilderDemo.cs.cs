using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Services;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders;
using DesignPatternsDemo.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Presentation
{
    public static class BuilderDemo
    {
        public static void Run()
        {

            var service = new VehicleService();
            bool continueDemo = true;

            while (continueDemo)
            {
                Console.WriteLine("\n=== CONSTRUIR VEHICULO MENU ===");
                Console.WriteLine("1. Crear vehículo personalizado");
                Console.WriteLine("2. Crear vehículo deportivo(pre-configurado)");
                Console.WriteLine("3. Create vehículo familiar (pre-configurado)");
                Console.WriteLine("4. Crear vehículo eco (pre-configurado)");
                Console.WriteLine("5. Mostrar todos los vehículos");
                Console.WriteLine("6. Consolidado inventario");
                Console.WriteLine("7. Limpiar Inventario Inventory");
                Console.WriteLine("8. Reglas de validación");
                Console.WriteLine("9. Retornar a menu principal");

                Console.Write("\nSelect option: ");
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
                        TestValidationRules();
                        break;
                    case "9":
                        continueDemo = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                if (continueDemo)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void CreateCustomVehicle(VehicleService service)
        {
            Console.WriteLine("\n--- Crear vehículo personalizado ---");

            Console.Write("Tipo de motor ( V6 3.0L, V8 4.0L, Hybrid 2.0L): ");
            string engine = Console.ReadLine() ?? "V6 3.0L";

            Console.Write("Color: ");
            string color = Console.ReadLine() ?? "Negro";

            Console.Write("Incluir Sunroof? (y/n): ");
            bool sunroof = (Console.ReadLine()?.ToLower() ?? "n") == "y";

            Console.Write("Incluir GPS? (y/n): ");
            bool gps = (Console.ReadLine()?.ToLower() ?? "n") == "y";

            Console.Write("Incluir Camara? (y/n): ");
            bool camera = (Console.ReadLine()?.ToLower() ?? "n") == "y";

            try
            {
                var vehicle = service.CreateCustomVehicle(engine, color, sunroof, gps, camera);
                Console.WriteLine($"\nVehiculo creado exitosamente!");
                Console.WriteLine($"   Descripción: {vehicle.GetDescription()}");
                Console.WriteLine($"   Precio: {vehicle.CalculatePrice():C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\n error: {ex.Message}");
            }
        }

        private static void CreateSportsCar(VehicleService service)
        {
            Console.Write("\nIngrese color para vehículo deportivo (predeterminado: Rojo): ");
            string color = Console.ReadLine() ?? "Red";

            var vehicle = service.CreateSportsCar(color);
            Console.WriteLine($"\n Vehículo deportivo creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculatePrice()}");
        }

        private static void CreateFamilyCar(VehicleService service)
        {
            Console.Write("\nIngrese color para vehiculo familiar (predeterminado: Azul): ");
            string color = Console.ReadLine() ?? "Azul";

            var vehicle = service.CreateFamilyCar(color);
            Console.WriteLine($"\n Vehículo familiar creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculatePrice()}");
        }

        private static void CreateEcoCar(VehicleService service)
        {
            Console.Write("\nIngresar colocar para vehiculo Eco (predeterminado: Verde): ");
            string color = Console.ReadLine() ?? "Verde";

            var vehicle = service.CreateEcoCar(color);
            Console.WriteLine($"\nVehículo Eco creado!");
            Console.WriteLine($"{vehicle.GetDescription()}");
            Console.WriteLine($"Precio: {vehicle.CalculatePrice()}");
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
                Console.WriteLine($"Precio: {vehicle.CalculatePrice()}");
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

        private static void TestValidationRules()
        {
            Console.WriteLine("\n=== REGLAS DE VALIDACIÓN ===");

            // Test 1: V8 with small wheels (should fail)
            Console.WriteLine("\nPrueba 1: V8 con llantas Standard");
            try
            {
                var builder1 = new VehicleBuilder()
                    .WithEngine("V8 4.0L")
                    .WithWheels("Standard 16\"")
                    .Build();
                Console.WriteLine("Prueba fallida - debe generar thrown exception");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Prueba exitosa: {ex.Message}");
            }

            // Test 2: Sunroof with fabric interior (should fail)
            Console.WriteLine("\nPrueba 2: Sunroof con interior de cuero");
            try
            {
                var builder2 = new VehicleBuilder()
                    .WithSunroof()
                    .Build(); 
                Console.WriteLine("Prueba fallida - debe generar thrown exception");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Prueba exitosa: {ex.Message}");
            }

            // Test 3: Valid configuration (should succeed)
            Console.WriteLine("\nTest 3: Validar  configuración carro deportivo");
            try
            {
                var builder3 = new VehicleBuilder()
                    .WithEngine("V8 4.0L")
                    .WithWheels("Sport 20\"")
                    .WithSunroof()
                    .WithLeatherInterior()
                    .Build();
                Console.WriteLine("Prueba exitosa: Vehiculo valido creado");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Prueba fallida: {ex.Message}");
            }
        }
    }
}

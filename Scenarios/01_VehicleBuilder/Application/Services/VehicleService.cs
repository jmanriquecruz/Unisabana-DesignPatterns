using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Services
{
    public class VehicleService
    {
        private readonly List<Vehicle> vehicles = new();

        public Vehicle CreateCustomVehicle(
            string engineType,
            string color,
            bool includeSunroof = false,
            bool includeGPS = false,
            bool includeCamera = false)
        {
            var builder = new VehicleBuilder()
                .WithEngine(engineType)
                .WithColor(color);

            if (includeSunroof) builder.WithSunroof();
            if (includeGPS) builder.WithGPS();
            if (includeCamera) builder.WithCamera();

            var vehicle = builder.Build();
            this.vehicles.Add(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Crea un auto deportivo pre-configurado
        /// </summary>
        /// <param name="color">Color personalizado (opcional)</param>
        /// <returns>Auto deportivo creado</returns>
        public Vehicle CreateSportsCar(string color = "Rojo")
        {
            var builder = new VehicleBuilder()
                .ConfigureAsSportsCar()
                .WithColor(color);

            var vehicle = builder.Build();
            this.vehicles.Add(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Crea un auto familiar pre-configurado
        /// </summary>
        /// <param name="color">Color personalizado (opcional)</param>
        /// <returns>Auto familiar creado</returns>
        public Vehicle CreateFamilyCar(string color = "Azul")
        {
            var builder = new VehicleBuilder()
                .ConfigureAsFamilyCar()
                .WithColor(color);

            var vehicle = builder.Build();
            this.vehicles.Add(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Crea un auto ecológico pre-configurado
        /// </summary>
        /// <param name="color">Color personalizado (opcional)</param>
        /// <returns>Auto ecológico creado</returns>
        public Vehicle CreateEcoCar(string color = "Verde")
        {
            var builder = new VehicleBuilder()
                .ConfigureAsEcoCar()
                .WithColor(color);

            var vehicle = builder.Build();
            this.vehicles.Add(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Obtiene todos los vehículos creados
        /// </summary>
        /// <returns>Lista de vehículos</returns>
        public List<Vehicle> GetAllVehicles()
        {
            return new List<Vehicle>(this.vehicles);
        }

        /// <summary>
        /// Calcula el valor total del inventario de vehículos
        /// </summary>
        /// <returns>Valor total en dinero</returns>
        public decimal CalculateTotalInventoryValue()
        {
            return this.vehicles.Sum(v => v.CalculatePrice());
        }

        /// <summary>
        /// Obtiene la cantidad de vehículos agrupados por color
        /// </summary>
        /// <returns>Diccionario color → cantidad</returns>
        public Dictionary<string, int> GetVehiclesByColor()
        {
            return this.vehicles
                .GroupBy(v => v.Color)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Limpia el inventario de vehículos
        /// </summary>
        public void ClearInventory()
        {
            this.vehicles.Clear();
        }
    }
}

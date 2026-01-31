using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities
{
    public class Vehicle
    {
        /// <summary>
        /// Tipo de motor del vehículo  "V6 2.5L", "V8 4.0L Turbo", "Hybrid 2.0L")
        /// </summary>
        public string EngineType { get; }

        /// <summary>
        /// Color exterior del vehículo
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Tipo de llantas/ruedas ("Standard 16\"", "Sport 20\"", "Comfort 18\"")
        /// </summary>
        public string WheelType { get; }

        /// <summary>
        /// Indica si el vehículo tiene techo solar
        /// </summary>
        public bool HasSunroof { get; }

        /// <summary>
        /// Sistema de sonido instalado ("Básico", "Premium", "Premium Plus")
        /// </summary>
        public string SoundSystem { get; }

        /// <summary>
        /// Tipo de interior ("Fabric", "Leather", "Synthetic Leather")
        /// </summary>
        public string InteriorType { get; }

        /// <summary>
        /// Indica si el vehículo tiene sistema de navegación GPS
        /// </summary>
        public bool HasGPS { get; }

        /// <summary>
        /// Indica si el vehículo tiene cámara de retroceso
        /// </summary>
        public bool HasCamera { get; }

        /// <summary>
        /// Tipo de transmisión ("Automático", "Manual", "Semi-automático")
        /// </summary>
        public string Transmission { get; }

        /// <summary>
        /// Indica si los asientos tienen calefacción
        /// </summary>
        public bool HasHeatedSeats { get; }

        // Constructor interno (solo Builder puede crear)
        internal Vehicle(
            string engineType,
            string color,
            string wheelType,
            bool hasSunroof,
            string soundSystem,
            string interiorType,
            bool hasGps,
            bool hasCamera,
            string transmission,
            bool hasHeatedSeats)
        {
            EngineType = engineType;
            Color = color;
            WheelType = wheelType;
            HasSunroof = hasSunroof;
            SoundSystem = soundSystem;
            InteriorType = interiorType;
            HasGPS = hasGps;
            HasCamera = hasCamera;
            Transmission = transmission;
            HasHeatedSeats = hasHeatedSeats;
        }

        // Métodos de dominio
        public decimal CalculatePrice()
        {
            decimal price = 25000; // Precio base

            // Motor
            if (EngineType.Contains("V8")) price += 8000;
            else if (EngineType.Contains("V6")) price += 4000;
            else if (EngineType.Contains("Hybrid")) price += 3000;

            // Características
            if (HasSunroof) price += 2000;
            if (SoundSystem == "Premium") price += 1500;
            if (InteriorType == "Leather") price += 3000;
            if (HasGPS) price += 800;
            if (HasCamera) price += 500;
            if (HasHeatedSeats) price += 1200;

            return price;
        }

        public string GetDescription()
        {
            var features = new List<string>();
            if (HasSunroof) features.Add("Techo solar");
            if (SoundSystem == "Premium") features.Add("Sonido premium");
            if (HasGPS) features.Add("GPS");
            if (HasCamera) features.Add("Cámara de retroceso");
            if (HasHeatedSeats) features.Add("Asientos calefaccionados");

            return $"{Color} {EngineType} con llantas {WheelType}" +
                   $" e interior de {InteriorType}. " +
                   $"Características: {string.Join(", ", features)}";
        }
    }
}

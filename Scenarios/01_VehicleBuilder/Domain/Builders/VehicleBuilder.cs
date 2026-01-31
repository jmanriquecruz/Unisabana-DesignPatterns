using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders
{
    public class VehicleBuilder
    {
        // Campos privados para almacenar la configuración temporal
        private string engineType = "V6 2.5L";
        private string color = "Blanco";
        private string wheelType = "Estándar 16\"";
        private bool hasSunroof = false;
        private string soundSystem = "Básico";
        private string interiorType = "Tela";
        private bool hasGPS = false;
        private bool hasCamera = false;
        private string transmission = "Automática";
        private bool hasHeatedSeats = false;

        /// <summary>
        /// Configura el tipo de motor del vehículo
        /// </summary>
        /// <param name="engineType">Tipo de motor (ej: "V8 4.0L Turbo")</param>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithEngine(string engineType)
        {
            this.engineType = engineType;
            return this;
        }

        /// <summary>
        /// Configura el color del vehículo
        /// </summary>
        /// <param name="color">Color del vehículo</param>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithColor(string color)
        {
            this.color = color;
            return this;
        }

        /// <summary>
        /// Configura el tipo de llantas del vehículo
        /// </summary>
        /// <param name="wheelType">Tipo de llantas (ej: "Deportivas 20\"")</param>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithWheels(string wheelType)
        {
            this.wheelType = wheelType;
            return this;
        }

        /// <summary>
        /// Agrega techo solar al vehículo
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithSunroof()
        {
            this.hasSunroof = true;
            return this;
        }

        /// <summary>
        /// Configura sistema de sonido premium
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithPremiumSoundSystem()
        {
            this.soundSystem = "Premium";
            return this;
        }

        /// <summary>
        /// Configura interior de cuero
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithLeatherInterior()
        {
            this.interiorType = "Cuero";
            return this;
        }

        /// <summary>
        /// Agrega sistema de navegación GPS
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithGPS()
        {
            this.hasGPS = true;
            return this;
        }

        /// <summary>
        /// Agrega cámara de retroceso
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithCamera()
        {
            this.hasCamera = true;
            return this;
        }

        /// <summary>
        /// Configura transmisión manual
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithManualTransmission()
        {
            this.transmission = "Manual";
            return this;
        }

        /// <summary>
        /// Agrega asientos calefaccionados
        /// </summary>
        /// <returns>Instancia del builder para encadenamiento</returns>
        public VehicleBuilder WithHeatedSeats()
        {
            this.hasHeatedSeats = true;
            return this;
        }

        /// <summary>
        /// Construye el vehículo con la configuración actual
        /// </summary>
        /// <returns>Instancia de Vehicle configurada</returns>
        /// <exception cref="InvalidOperationException">
        /// Cuando la configuración viola reglas de negocio
        /// </exception>
        public Vehicle Build()
        {
            ValidateConfiguration();
            return new Vehicle(
                this.engineType,
                this.color,
                this.wheelType,
                this.hasSunroof,
                this.soundSystem,
                this.interiorType,
                this.hasGPS,
                this.hasCamera,
                this.transmission,
                this.hasHeatedSeats
            );
        }

        /// <summary>
        /// Valida las reglas de negocio de la configuración
        /// </summary>
        private void ValidateConfiguration()
        {
            // Regla: Motor V8 requiere llantas deportivas
            if (this.engineType.Contains("V8") && this.wheelType == "Estándar 16\"")
            {
                throw new InvalidOperationException(
                    "El motor V8 requiere llantas deportivas (mínimo 18\")");
            }

            // Regla: Techo solar requiere interior de cuero
            if (this.hasSunroof && this.interiorType == "Tela")
            {
                throw new InvalidOperationException(
                    "El techo solar requiere interior de cuero");
            }

            // Regla: Vehículos híbridos solo vienen con transmisión automática
            if (this.engineType.Contains("Hybrid") && this.transmission == "Manual")
            {
                throw new InvalidOperationException(
                    "Los vehículos híbridos solo vienen con transmisión automática");
            }
        }

        /// <summary>
        /// Configuración predefinida para auto deportivo
        /// </summary>
        /// <returns>Instancia del builder con configuración deportiva</returns>
        public VehicleBuilder ConfigureAsSportsCar()
        {
            return this
                .WithEngine("V8 4.0L Turbo")
                .WithWheels("Deportivas 20\"")
                .WithLeatherInterior()
                .WithPremiumSoundSystem()
                .WithSunroof();
        }

        /// <summary>
        /// Configuración predefinida para auto familiar
        /// </summary>
        /// <returns>Instancia del builder con configuración familiar</returns>
        public VehicleBuilder ConfigureAsFamilyCar()
        {
            return this
                .WithEngine("V6 3.0L")
                .WithWheels("Confort 18\"")
                .WithGPS()
                .WithCamera()
                .WithHeatedSeats();
        }

        /// <summary>
        /// Configuración predefinida para auto ecológico
        /// </summary>
        /// <returns>Instancia del builder con configuración ecológica</returns>
        public VehicleBuilder ConfigureAsEcoCar()
        {
            return this
                .WithEngine("Híbrido 2.0L")
                .WithColor("Verde")
                .WithWheels("Ecológicas 17\"")
                .WithHeatedSeats();
        }
    }
}

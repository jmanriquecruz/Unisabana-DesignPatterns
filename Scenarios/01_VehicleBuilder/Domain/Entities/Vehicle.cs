using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Exceptions;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities
{
    public class Vehicle
    {
        public EngineType Engine { get; }
        public VehicleColor Color { get; }
        public WheelType Wheels { get; }
        public InteriorType Interior { get; }
        public SoundSystem SoundSystem { get; }
        public bool HasSunroof { get; }
        public bool HasGPS { get; }
        public bool HasCamera { get; }
        public bool HasHeatedSeats { get; }
        public string Transmission { get; }

        internal Vehicle(
            EngineType engine,
            VehicleColor color,
            WheelType wheels,
            InteriorType interior,
            SoundSystem soundSystem,
            string transmission,
            bool hasSunroof,
            bool hasGps,
            bool hasCamera,
            bool hasHeatedSeats)
        {
            Engine = engine ?? throw new DomainException("Engine requerido");
            Color = color ?? throw new DomainException("Color requerido");
            Wheels = wheels ?? throw new DomainException("Wheels requeridas");
            Interior = interior ?? throw new DomainException("Interior requerido");
            SoundSystem = soundSystem ?? SoundSystem.Basic;
            Transmission = transmission ?? throw new DomainException("Transmission requerida");

            HasSunroof = hasSunroof;
            HasGPS = hasGps;
            HasCamera = hasCamera;
            HasHeatedSeats = hasHeatedSeats;

            ValidateRules();
        }

        private void ValidateRules()
        {
            if (HasSunroof && !Interior.IsLeather)
                throw new DomainException("Techo solar requiere interior de cuero");
        }

        public decimal CalculateBasePrice()
        {
            decimal price = 25000;

            if (Engine.IsV8) price += 8000;
            else if (Engine.IsHybrid) price += 3000;

            if (HasSunroof) price += 2000;
            if (SoundSystem == SoundSystem.Premium) price += 1500;
            if (Interior.IsLeather) price += 3000;
            if (HasGPS) price += 800;
            if (HasCamera) price += 500;
            if (HasHeatedSeats) price += 1200;

            return price;
        }

        public string GetDescription()
        {
            return $"{Color} {Engine} con llantas {Wheels} e interior {Interior}";
        }
    }
}

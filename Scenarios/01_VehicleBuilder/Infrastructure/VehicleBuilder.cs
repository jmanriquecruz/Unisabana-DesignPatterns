using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Exceptions;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders
{
    public class VehicleBuilder : IVehicleBuilder
    {
        private EngineType _engine = null!;
        private VehicleColor _color = null!;
        private WheelType _wheels = null!;
        private SoundSystem _soundSystem = null!;
        private InteriorType _interior = null!;
        private string _transmission = default!;
        private bool _hasSunroof;
        private bool _hasGps;
        private bool _hasCamera;
        private bool _hasHeatedSeats;


        public IVehicleBuilder WithEngine(EngineType engine)
        {
            _engine = engine;
            return this;
        }

        public IVehicleBuilder WithColor(VehicleColor color)
        {
            _color = color;
            return this;
        }

        public IVehicleBuilder WithWheelType(WheelType wheels)
        {
            _wheels = wheels;
            return this;
        }

        public IVehicleBuilder WithSoundSystem(SoundSystem soundSystem)
        {
            _soundSystem = soundSystem;
            return this;
        }

        public IVehicleBuilder WithInterior(InteriorType interior)
        {
            _interior = interior;
            return this;
        }

        public IVehicleBuilder WithSunroof(bool hasSunroof)
        {
            _hasSunroof = hasSunroof;
            return this;
        }


        public IVehicleBuilder WithGPS(bool hasGps)
        {
            _hasGps = hasGps;
            return this;
        }

        public IVehicleBuilder WithCamera(bool hasCamera)
        {
            _hasCamera = hasCamera;
            return this;
        }

        public IVehicleBuilder WithTransmission(string transmission)
        {
            _transmission = transmission;
            return this;
        }

        public IVehicleBuilder WithHeatedSeats(bool hasHeatedSeats)
        {
            _hasHeatedSeats = hasHeatedSeats;
            return this;
        }

        public Vehicle Build()
        {
            Validate();

            return new Vehicle(
                _engine,
                _color,
                _wheels,
                _interior,
                _soundSystem,
                _transmission,
                _hasSunroof,
                _hasGps,
                _hasCamera,
                _hasHeatedSeats
            );
        }

        private void Validate()
        {
            if (_engine is null)
                throw new DomainException("Motor es requerido");

            if (_color is null)
                throw new DomainException("Color es requerido");

            if (_wheels is null)
                throw new DomainException("Tipo de llanta es requerido");

            if (_interior is null)
                throw new DomainException("Interior es requerido");

            if (_soundSystem is null)
                throw new DomainException("Sitema de Sonido es requerido");

            if (string.IsNullOrWhiteSpace(_transmission))
                throw new DomainException("Transmision es requerida");
        }

        public void Reset()
        {
            _engine = null!;
            _color = null!;
            _wheels = null!;
            _soundSystem = null!;
            _interior = null!;
            _transmission = null!;
            _hasSunroof = false;
            _hasGps = false;
            _hasCamera = false;
            _hasHeatedSeats = false;
        }
    }
}

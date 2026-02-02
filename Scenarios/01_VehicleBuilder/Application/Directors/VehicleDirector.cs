using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Directors
{
    public class VehicleDirector
    {
        private readonly IVehicleBuilder _builder;

        public VehicleDirector(IVehicleBuilder builder)
        {
            _builder = builder;
        }

        public Vehicle BuildSportsCar(VehicleColor color)
        {
            return _builder
                .WithEngine(EngineType.V8)
                .WithColor(color)
                .WithWheelType(WheelType.Sport20)
                .WithInterior(InteriorType.Leather)
                .WithSoundSystem(SoundSystem.Premium)
                .WithTransmission("Automático")
                .WithSunroof(true)
                .WithGPS(true)
                .WithCamera(true)
                .WithHeatedSeats(true)
                .Build();
        }

        public Vehicle BuildFamilyCar(VehicleColor color)
        {
            return _builder
                .WithEngine(EngineType.V6)
                .WithColor(color)
                .WithWheelType(WheelType.Comfort18)
                .WithInterior(InteriorType.Fabric)
                .WithSoundSystem(SoundSystem.Basic)
                .WithTransmission("Automático")
                .WithGPS(true)
                .WithCamera(true)
                .WithSunroof(false)
                .WithHeatedSeats(false)
                .Build();
        }

        public Vehicle BuildEcoCar(VehicleColor color)
        {
            return _builder
                .WithEngine(EngineType.Hybrid)
                .WithColor(color)
                .WithWheelType(WheelType.Standard16)
                .WithInterior(InteriorType.SyntheticLeather)
                .WithSoundSystem(SoundSystem.Basic)
                .WithTransmission("Automático")
                .WithGPS(true)
                .WithCamera(true)
                .WithSunroof(false)
                .WithHeatedSeats(false)
                .Build();
        }
    }
}

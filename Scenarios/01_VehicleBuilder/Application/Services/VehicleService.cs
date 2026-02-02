using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Directors;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;


namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Application.Services
{
    public class VehicleService
    {
        private readonly IVehicleBuilder _builder;
        private readonly VehicleDirector _director;
        private readonly List<Vehicle> _inventory = new();

        public VehicleService(IVehicleBuilder builder)
        {
            _builder = builder;
            _director = new VehicleDirector(builder);
        }


        public Vehicle CreateCustomVehicle(
            string engineInput,
            string colorInput,
            bool sunroof,
            bool gps,
            bool camera)
        {

            var engine = EngineType.FromString(engineInput);
            var color = VehicleColor.FromString(colorInput);

            var vehicle = _builder
                .WithEngine(engine)
                .WithColor(color)
                .WithWheelType(WheelType.Standard16)
                .WithInterior(InteriorType.Leather)
                .WithSoundSystem(SoundSystem.Basic)
                .WithTransmission("Automático")
                .WithSunroof(sunroof)
                .WithGPS(gps)
                .WithCamera(camera)
                .WithHeatedSeats(false)
                .Build();

            _inventory.Add(vehicle);
            return vehicle;
        }

        public Vehicle CreateSportsCar(string colorInput)
        {
            var color = VehicleColor.FromString(colorInput);
            var vehicle = _director.BuildSportsCar(color);
            _inventory.Add(vehicle);
            return vehicle;
        }

        public Vehicle CreateFamilyCar(string colorInput)
        {
            var color = VehicleColor.FromString(colorInput);
            var vehicle = _director.BuildFamilyCar(color);
            _inventory.Add(vehicle);
            return vehicle;
        }

        public Vehicle CreateEcoCar(string colorInput)
        {
            var color = VehicleColor.FromString(colorInput);
            var vehicle = _director.BuildEcoCar(color);
            _inventory.Add(vehicle);
            return vehicle;
        }

        public IReadOnlyList<Vehicle> GetAllVehicles() => _inventory;

        public Dictionary<VehicleColor, int> GetVehiclesByColor()
        {
            return _inventory
                .GroupBy(v => v.Color)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public decimal CalculateTotalInventoryValue() =>
            _inventory.Sum(v => v.CalculateBasePrice());

        public void ClearInventory() => _inventory.Clear();
    }
}

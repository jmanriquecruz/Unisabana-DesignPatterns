using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Entities;
using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects;


namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Builders 
{ 
    public interface IVehicleBuilder 
    { 
        void Reset(); 
        IVehicleBuilder WithEngine(EngineType engine); 
        IVehicleBuilder WithColor(VehicleColor color); 
        IVehicleBuilder WithWheelType(WheelType wheelType); 
        IVehicleBuilder WithSoundSystem(SoundSystem soundSystem); 
        IVehicleBuilder WithInterior(InteriorType interior); 
        IVehicleBuilder WithSunroof(bool hasSunroof); 
        IVehicleBuilder WithGPS(bool hasGps); 
        IVehicleBuilder WithCamera(bool hasCamera); 
        IVehicleBuilder WithTransmission(string transmission); 
        IVehicleBuilder WithHeatedSeats(bool hasHeatedSeats); 
        Vehicle Build(); 
    } 
}
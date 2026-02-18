using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Exceptions;
namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects
{
    public  record VehicleColor(string Value)
    {
        public static VehicleColor Black => new("Negro");
        public static VehicleColor White => new("Blanco");
        public static VehicleColor Red => new("Rojo");
        public static VehicleColor Blue => new("Azul");
        public static VehicleColor Green => new("Verde");

        public static VehicleColor FromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Color inválido");

            var normalized = value.Trim().ToLowerInvariant();

            return normalized switch
            {
                "negro" => Black,
                "blanco" => White,
                "rojo" => Red,
                "azul" => Blue,
                "verde" => Green,
                _ => throw new DomainException($"Color inválido: {value}")
            };
        }

        public static IReadOnlyList<VehicleColor> GetAvailableColors()
        {
            return new[] { Black, White, Red, Blue, Green };
        }

        public override string ToString() => Value;
    }
}

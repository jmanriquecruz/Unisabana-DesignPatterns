using DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects
{
    public sealed record EngineType
    {
        public string Value { get; }

        private EngineType(string value)
        {
            Value = value;
        }

        public static EngineType V6 => new("V6 2.5L");
        public static EngineType V8 => new("V8 4.0L Turbo");
        public static EngineType Hybrid => new("Hibrido 2.0L");

        public static EngineType FromString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Motor inválido");

            var normalized = value.Trim().ToLowerInvariant();

            return value switch
            {
                "v6" => V6,
                "v8" => V8,
                "hibrido" => Hybrid,
                _ => throw new DomainException($"Motor inválido: {value}")
            };
        }

        public bool IsV8 => Value.StartsWith("V8");
        public bool IsHybrid => Value.StartsWith("Hybrido");

        public override string ToString() => Value;
    }
}

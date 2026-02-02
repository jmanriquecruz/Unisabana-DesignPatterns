using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects
{
    public sealed record InteriorType
    {
        public string Value { get; }

        private InteriorType(string value)
        {
            Value = value;
        }

        public static InteriorType Fabric => new("Tela");
        public static InteriorType Leather => new("Cuero");
        public static InteriorType SyntheticLeather => new("Cuero Sintetico");

        public bool IsLeather => Value == "Cuero";

        public override string ToString() => Value;
    }
}

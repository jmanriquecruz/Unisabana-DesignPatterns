using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects
{
    public sealed record WheelType
    {
        public string Value { get; }

        private WheelType(string value)
        {
            Value = value;
        }

        public static WheelType Standard16 => new("Standard 16\"");
        public static WheelType Comfort18 => new("Comfort 18\"");
        public static WheelType Sport20 => new("Sport 20\"");

        public bool IsSmall => Value.Contains("16");

        public override string ToString() => Value;
    }
}

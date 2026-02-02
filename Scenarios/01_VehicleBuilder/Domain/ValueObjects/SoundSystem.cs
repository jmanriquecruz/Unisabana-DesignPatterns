using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._01_VehicleBuilder.Domain.ValueObjects
{
    public sealed record SoundSystem
    {
        public string Value { get; }

        private SoundSystem(string value)
        {
            Value = value;
        }

        public static SoundSystem Basic => new("Básico");
        public static SoundSystem Premium => new("Premium");
        public static SoundSystem PremiumPlus => new("Premium Plus");

        public override string ToString() => Value;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Team
{
    public class TeamMember
    {
        public string Name { get; }
        public string PersonId { get; } // Identificador único de persona

        public TeamMember(string name, string personId)
        {
            Name = name;
            PersonId = personId;
        }

        public override string ToString()
        {
            return $"👤 {Name,-25} | ID Persona: {PersonId}";
        }
    }
}

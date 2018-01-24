using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public enum TypeParticipant { ODC, Projectmedewerker, Opleiding }

    public class Participant 
    {
        public Int16 Id { get; set; }

        public string Name { get; set; }

        public TypeParticipant TypeParticipant { get; set; }

        public List<ProjectParticipant> Projects { get; set; }

    }
}

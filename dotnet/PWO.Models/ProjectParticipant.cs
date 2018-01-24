using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class ProjectParticipant 
    {
        public Int16 ParticipantId { get; set; }
        public Participant Participant { get; set; }

        public Int64 ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

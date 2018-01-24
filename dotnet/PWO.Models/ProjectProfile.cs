using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class ProjectProfile
    {
        public Int32 ProfileId { get; set; }
        public Profile Profile { get; set; }

        public Int64 ProjectId { get; set; }
        public Project Project { get; set; }

    }
}

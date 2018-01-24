using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class ProjectLink
    {
        public Int16 LinkId { get; set; }
        public Link Link { get; set; }

        public Int64 ProjectId { get; set; }
        public Project Project { get; set; }

    }
}

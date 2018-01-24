using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class Publication 
    {
        public Int16 Id { get; set; }

        public string Name { get; set; }

        public List<ProjectPublication> Projects { get; set; }

    }
}

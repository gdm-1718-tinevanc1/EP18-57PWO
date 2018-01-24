using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class Spearhead 
    {
        public Int16 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ProjectSpearhead> Projects { get; set; }

    }
}

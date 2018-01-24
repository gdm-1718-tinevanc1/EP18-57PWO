using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class Financingform 
    {
        public Int16 Id { get; set; }

        public string Name { get; set; }

        public List<Project> Projects { get; set; }
    }
}

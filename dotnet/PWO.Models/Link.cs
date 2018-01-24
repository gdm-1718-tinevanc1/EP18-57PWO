using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public enum TypeLink { Project, Url }
    public class Link 
    {
        public Int16 Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TypeLink TypeLink { get; set; }

        public List<ProjectLink> Projects { get; set; }

    }
}

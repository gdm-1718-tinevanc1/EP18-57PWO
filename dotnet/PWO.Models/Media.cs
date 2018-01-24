using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public enum TypeMedia { Icon, PrimaryImage, Images }

    public class Media 
    {
        public Int16 Id { get; set; }

        public string Url { get; set; }

        public TypeMedia TypeMedia { get; set; }

        public List<Project> Projects { get; set; }

    }
}

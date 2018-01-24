using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class Profile 
    {
        public Int32 Id { get; set; }
        
        public string UserName { get; set; }

        public string Email { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }
        
        public Int32 Employeenumber { get; set; }

        public List<ProjectProfile> Projects { get; set; }

    }
}

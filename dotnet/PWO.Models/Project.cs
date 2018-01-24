using System;
using System.Collections.Generic;

namespace PWO.Models
{
    public class Project 
    {
        public Int64 Id { get; set; }
        
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Abstract { get; set; }

        // public Json Title { get; set; }
        // public Json Subtitle { get; set; }
        // public Json Description { get; set; }
        // public Json Abstract { get; set; }
        // public Json Participant { get; set; }
        // public Json Tag { get; set; }
        // public Json Spearhead { get; set; }
        // public Json Financingform { get; set; }
        // public Json Link { get; set; }
        // public Json Media { get; set; }

        public List<ProjectParticipant> Participants { get; set; }
        public List<ProjectLink> Links { get; set; }
        public List<ProjectPublication> Publications { get; set; }
        public List<ProjectSpearhead> Spearheads { get; set; }
        public List<ProjectTag> Tags { get; set; }

        public List<ProjectProfile> Profiles { get; set; }


        public Int16 MediaId { get; set; }
        public Media Media { get; set; }

        public Int16 FinancingformId { get; set; }
        public Financingform Financingform { get; set; }
    }
}

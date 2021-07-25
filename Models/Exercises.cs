using System;
using System.Collections.Generic;

namespace SoftwareIntegration.Models
{
    public class Exercise
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime exerciseDuration { get; set; }
    }
}
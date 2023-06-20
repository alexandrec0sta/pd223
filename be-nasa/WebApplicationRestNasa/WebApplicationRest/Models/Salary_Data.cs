using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationRest.Models
{
    public class Salary_Data
    {
        public int? Id { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string EducationLevel { get; set; }
        public string JobTitle { get; set; }
        public float? YearsofExperience { get; set; }
        public string Salary { get; set; }
    }
}
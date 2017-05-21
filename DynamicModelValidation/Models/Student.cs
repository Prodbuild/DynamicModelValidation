using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicModelValidation.Models
{
    public class Student
    {
        [DynamicRequired("Student_Name", "Name is required")]
        public string Name { get; set; }

        [DynamicRequired("Student_Name", "Age is required")]
        public int Age { get; set; }

        [DynamicRequired("Student_Standard", "Standard is required")]
        public string Standard { get; set; }

    }
}
using System;
using System.Collections.Generic;

namespace Skunkworks_v2.Models
{
    public partial class Students
    {
        public Students(string firstName, string lastName, int? age, int grade, string teacher)
        {
            
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Grade = grade;
            Teacher = teacher;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int Grade { get; set; }
        public string Teacher { get; set; }
    }


}

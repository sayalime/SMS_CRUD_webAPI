using System;
using System.Collections.Generic;

namespace AspApiCoreapi.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FName { get; set; } = null!;
        public string? LName { get; set; }
        public decimal? ContactNumber { get; set; }
        public string? Department { get; set; }
        public decimal? Salary { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? BloodGroup { get; set; }
    }
}

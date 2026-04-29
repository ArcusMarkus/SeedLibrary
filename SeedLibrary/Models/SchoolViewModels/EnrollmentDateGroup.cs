using System;
using System.ComponentModel.DataAnnotations;

namespace SeedLibrary.Models.SeedViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}
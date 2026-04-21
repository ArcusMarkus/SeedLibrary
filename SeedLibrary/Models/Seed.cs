namespace SeedLibrary.Models
{
    public class Seed
    {
        public int ID { get; set; }
        //Name
        public string Name { get; set; }
        //Variety
        public string Variety { get; set; }
        public int Year {get; set; }
        public string Date {get; set; }
        public string Source { get; set; }
        public string Depth {get; set; }
        public int Count {get; set; }
        public string Note {get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
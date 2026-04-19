namespace SeedLibrary.Models
{
    public class SeedCopy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime Year { get; set; }
        public int Depth {get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
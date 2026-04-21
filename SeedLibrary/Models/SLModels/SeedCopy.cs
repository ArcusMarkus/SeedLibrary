namespace SeedLibrary.Models
{
    public class SeedCopy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public DateTime Year { get; set; }
        public string Depth {get; set; }
        public int Count {get; set; }
        public string Note {get; set; }
        public int SourceID{get; set;}
        public int DateID{get;set;}
    }
}
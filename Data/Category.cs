namespace Pratik_Survivor.Data
{
    public class Category 
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public List<Competitor> Competitors { get; set; }
    }
}

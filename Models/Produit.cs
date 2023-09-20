namespace Bugtracking.Models
{
    public class produit
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

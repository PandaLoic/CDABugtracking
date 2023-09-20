namespace Bugtracking.Models
{
    public class Role
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        // petit commentaire de test pour github
    }
}
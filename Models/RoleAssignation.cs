namespace Bugtracking.Models
{
    public class RoleAssignation
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public Role Role { get; set; }
        public produit produit { get; set; }
        public Utilisateur Utilisateur { get; set; }

    }
}

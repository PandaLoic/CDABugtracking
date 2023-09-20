using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class RoleAssignation
    {
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
        public produit produit { get; set; }
        public Utilisateur Utilisateur { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public Boolean  Actif { get; set; }
    }
}
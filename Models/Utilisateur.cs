using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class Utilisateur
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Prenom { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public Boolean  Actif { get; set; }
    }
}
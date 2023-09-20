using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class TicketModification
    {
        [Key]
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public TicketStatut TicketStatut { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }        
    }
}

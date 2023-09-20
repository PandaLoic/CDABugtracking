namespace Bugtracking.Models
{
    public class TicketModification
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public Ticket Ticket { get; set; }
        public TicketStatut TicketStatut { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public string Commentaire { get; set; }
        public DateTime Date { get; set; }
    }
}

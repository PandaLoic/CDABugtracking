namespace Bugtracking.Models
{
    public class TicketAssignation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Ticket Ticket { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public List<Role> Role { get; set; }
    }
}
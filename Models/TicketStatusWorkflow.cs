namespace Bugtracking.Models
{
    public class TicketStatusWorkflow
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public TicketStatut StatutSource { get; set; }
        public TicketStatut StatutDestination { get; set; }
        public List<Role> RolesAuthorises { get; set; }
    }
}
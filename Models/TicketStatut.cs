namespace Bugtracking.Models
{
    public class TicketStatut
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<TicketStatusWorkflow> NextStatut { get; set; }
    }
}
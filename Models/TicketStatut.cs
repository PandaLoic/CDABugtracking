using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class TicketStatut
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TicketStatusWorkflow> NextStatut { get; set; }
    }
}
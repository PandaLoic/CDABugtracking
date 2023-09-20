using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class TicketStatusWorkflow
    {
        [Key]
        public int Id { get; set; }
        public TicketStatut StatutSource { get; set; }
        public TicketStatut StatutDestination { get; set; }
        public List<Role> RolesAuthorises { get; set; }
    }
}
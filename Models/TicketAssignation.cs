using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class TicketAssignation
    {
        [Key]
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public List<Role> Role { get; set; }
    }
}
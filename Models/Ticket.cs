using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bugtracking.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketType TicketType { get; set; }
        public ProduitVersion ChargeEstime { get; set; }
        public string Commentaire { get; set; }
        public ProduitVersion Version { get; set; } 
        public ProduitVersion CorrectedVersion { get; set; }
        public List<TicketAssignation> TicketAssignation { get; set; }
        public Ticket Parent { get; set; }
        [NotMapped]
        public Ticket RootParent { get
            {
                Ticket result = this;
                while (result != null && result.Parent != null ) 
                {
                    result = result.Parent;
                    
                }
                return result;
            } 
        }

    }
}

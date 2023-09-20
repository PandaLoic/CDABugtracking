using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class produit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

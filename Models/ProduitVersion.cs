using System.ComponentModel.DataAnnotations;

namespace Bugtracking.Models
{
    public class ProduitVersion
    {
        [Key]
        public int Id { get; set; }
        public int VersionMajeur { get; set; }
        public int VersionMineur { get; set; }
        public int NumeroBuild { get; set; }
        public DateTime DateDebutValidité { get; set; }
        public DateTime DateFinValidit { get; set; }

    }
}

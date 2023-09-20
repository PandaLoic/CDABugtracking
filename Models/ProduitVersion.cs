namespace Bugtracking.Models
{
    public class ProduitVersion
    {
        public Guid Id { get; set; }
        public int VersionMajeur { get; set; }
        public int VersionMineur { get; set; }
        public int NumeroBuild { get; set; }
        public DateTime DateDebutValidité { get; set; }
        public DateTime DateFinValidit { get; set; }

    }
}

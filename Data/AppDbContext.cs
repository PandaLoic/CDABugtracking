using Microsoft.EntityFrameworkCore;
using Bugtracking.Models;
using Microsoft.Extensions.Hosting;
using System.Reflection.Emit;

namespace Bugtracking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketStatut>()
                .HasMany(ts => ts.NextStatut)
                .WithOne(tsw => tsw.StatutSource);


            /* https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many */

        }

        public DbSet<produit> produit { get; set; } = default!;
        public DbSet<ProduitVersion> ProduitVersion { get; set; } = default!;
        public DbSet<Role> Role { get; set; } = default!;
        public DbSet<Bugtracking.Models.RoleAssignation> RoleAssignation { get; set; } = default!;
        public DbSet<Bugtracking.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<Bugtracking.Models.TicketAssignation> TicketAssignation { get; set; } = default!;
        public DbSet<Bugtracking.Models.TicketModification> TicketModification { get; set; } = default!;
        public DbSet<Bugtracking.Models.TicketStatusWorkflow> TicketStatusWorkflow { get; set; } = default!;
        public DbSet<Bugtracking.Models.TicketStatut> TicketStatut { get; set; } = default!;
        public DbSet<Bugtracking.Models.Utilisateur> Utilisateur { get; set; } = default!;
        


    }
}

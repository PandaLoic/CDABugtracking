﻿// <auto-generated />
using System;
using Bugtracking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bugtracking.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bugtracking.Models.ProduitVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateDebutValidité")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateFinValidit")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumeroBuild")
                        .HasColumnType("int");

                    b.Property<int>("VersionMajeur")
                        .HasColumnType("int");

                    b.Property<int>("VersionMineur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProduitVersion");
                });

            modelBuilder.Entity("Bugtracking.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("TicketStatusWorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketStatusWorkflowId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Bugtracking.Models.RoleAssignation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.Property<int>("produitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UtilisateurId");

                    b.HasIndex("produitId");

                    b.ToTable("RoleAssignation");
                });

            modelBuilder.Entity("Bugtracking.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChargeEstimeId")
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CorrectedVersionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("TicketType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VersionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChargeEstimeId");

                    b.HasIndex("CorrectedVersionId");

                    b.HasIndex("ParentId");

                    b.HasIndex("VersionId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketAssignation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("TicketAssignation");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketModification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.Property<int>("TicketStatutId")
                        .HasColumnType("int");

                    b.Property<int>("UtilisateurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("TicketStatutId");

                    b.HasIndex("UtilisateurId");

                    b.ToTable("TicketModification");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketStatusWorkflow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("StatutDestinationId")
                        .HasColumnType("int");

                    b.Property<int>("StatutSourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatutDestinationId");

                    b.HasIndex("StatutSourceId");

                    b.ToTable("TicketStatusWorkflow");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketStatut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TicketStatut");
                });

            modelBuilder.Entity("Bugtracking.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Actif")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("Bugtracking.Models.produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("produit");
                });

            modelBuilder.Entity("Bugtracking.Models.Role", b =>
                {
                    b.HasOne("Bugtracking.Models.TicketStatusWorkflow", null)
                        .WithMany("RolesAuthorises")
                        .HasForeignKey("TicketStatusWorkflowId");
                });

            modelBuilder.Entity("Bugtracking.Models.RoleAssignation", b =>
                {
                    b.HasOne("Bugtracking.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.produit", "produit")
                        .WithMany()
                        .HasForeignKey("produitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Utilisateur");

                    b.Navigation("produit");
                });

            modelBuilder.Entity("Bugtracking.Models.Ticket", b =>
                {
                    b.HasOne("Bugtracking.Models.ProduitVersion", "ChargeEstime")
                        .WithMany()
                        .HasForeignKey("ChargeEstimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.ProduitVersion", "CorrectedVersion")
                        .WithMany()
                        .HasForeignKey("CorrectedVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.Ticket", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.ProduitVersion", "Version")
                        .WithMany()
                        .HasForeignKey("VersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChargeEstime");

                    b.Navigation("CorrectedVersion");

                    b.Navigation("Parent");

                    b.Navigation("Version");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketAssignation", b =>
                {
                    b.HasOne("Bugtracking.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.Ticket", "Ticket")
                        .WithMany("TicketAssignation")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Ticket");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketModification", b =>
                {
                    b.HasOne("Bugtracking.Models.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.TicketStatut", "TicketStatut")
                        .WithMany()
                        .HasForeignKey("TicketStatutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.Utilisateur", "Utilisateur")
                        .WithMany()
                        .HasForeignKey("UtilisateurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("TicketStatut");

                    b.Navigation("Utilisateur");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketStatusWorkflow", b =>
                {
                    b.HasOne("Bugtracking.Models.TicketStatut", "StatutDestination")
                        .WithMany()
                        .HasForeignKey("StatutDestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bugtracking.Models.TicketStatut", "StatutSource")
                        .WithMany("NextStatut")
                        .HasForeignKey("StatutSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatutDestination");

                    b.Navigation("StatutSource");
                });

            modelBuilder.Entity("Bugtracking.Models.Ticket", b =>
                {
                    b.Navigation("TicketAssignation");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketStatusWorkflow", b =>
                {
                    b.Navigation("RolesAuthorises");
                });

            modelBuilder.Entity("Bugtracking.Models.TicketStatut", b =>
                {
                    b.Navigation("NextStatut");
                });
#pragma warning restore 612, 618
        }
    }
}

using FileLocator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MIS_FileLocator.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

         public DbSet<FillingCabinet> FillingCabinets { get; set; }
         public DbSet<FileBoxes> FileBoxes { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Documents> Documents { get; set; } 

        public DbSet<ConfidentialityLevel> ConfidentialityLevels { get; set; }

        public DbSet<AuditTrails>AuditTrails { get; set; }

        // for tables configuration and relationships ( wag na wag na)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasIndex(x => x.EmployeeId)
                .IsUnique();


            modelBuilder.Entity<FillingCabinet>()
                .HasIndex(x => x.Name)
                .IsUnique(); // now same name 

            modelBuilder.Entity<FileBoxes>()
                .HasOne(x => x.FillingCabinet)
                .WithMany(x => x.FileBox)
                .HasForeignKey (x => x.FillingCabinetId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Folder>()
                .HasOne(x => x.FileBox)
                .WithMany(x => x.Folders)
                .HasForeignKey(x => x.FileBoxId)
                .OnDelete(DeleteBehavior.Restrict);

           

            modelBuilder.Entity<Documents>()
                .HasOne(x => x.Folder)
                .WithMany(x => x.Documents)
                .HasForeignKey(x => x.FolderId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Documents>()
                .HasOne(x =>x.ConfidentialityLevel)
                .WithMany()
                .HasForeignKey(x => x.ConfidentialityLevelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConfidentialityLevel>().HasData(
                new ConfidentialityLevel { Id = 1, Name = "Public" },
                new ConfidentialityLevel { Id = 2, Name = "Internal Use " },  
                new ConfidentialityLevel { Id = 3, Name = "Restricted" },
                new ConfidentialityLevel { Id = 4, Name = "Confidential" }
                );
        }
    }
}
    
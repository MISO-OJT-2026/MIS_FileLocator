using FileLocator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MIS_FileLocator.Models;
using MIS_FileLocator.Services;
using System.Text.Json;
using System.Threading.Channels;
namespace MIS_FileLocator.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : IdentityDbContext<ApplicationUser>(options)
    {

         public DbSet<FillingCabinet> FillingCabinets { get; set; }
         public DbSet<FileBoxes> FileBoxes { get; set; }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Documents> Documents { get; set; } 

        public DbSet<ConfidentialityLevel> ConfidentialityLevels { get; set; }

        public DbSet<AuditTrails>AuditTrails { get; set; }

        public DbSet<TransactionLog> TransactionLogs { get; set; }

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

      
         public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Grab the logged-in user's name
            var currentUsername = await currentUserService.GetCurrentFullNameAsync();

            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            var auditLogs = new List<AuditTrails>();

            foreach (var entry in entries)
            {
                // Skip our tracking tables to prevent an infinite loop!
                if (entry.Entity is AuditTrails || entry.Entity is TransactionLog)
                    continue;

                var auditTrail = new AuditTrails
                {
                    TableName = entry.Metadata.GetTableName() ?? entry.Entity.GetType().Name,
                    Action = entry.State.ToString(),
                    PerformedAt = DateTime.UtcNow,
                    FullName = currentUsername 
                };

                // Get the ID of the specific record being changed
                var primaryKey = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey());
                auditTrail.RecordId = primaryKey?.CurrentValue?.ToString() ?? "Unknown";

                // Capture what the data looked like BEFORE the change
                if (entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
                {
                    var oldValues = entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.OriginalValue);
                    auditTrail.OldValues = JsonSerializer.Serialize(oldValues);
                }

                // Capture what the data looks like AFTER the change
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var newValues = entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.CurrentValue);
                    auditTrail.NewValues = JsonSerializer.Serialize(newValues);
                }

                auditLogs.Add(auditTrail);
            }

            if (auditLogs.Any())
            {
                await AuditTrails.AddRangeAsync(auditLogs, cancellationToken);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
    
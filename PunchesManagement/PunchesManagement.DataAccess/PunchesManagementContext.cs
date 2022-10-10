using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess;

public class PunchesManagementContext : DbContext
{
    public PunchesManagementContext(DbContextOptions<PunchesManagementContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(eb =>
        {
            eb.HasMany(w => w.Punches)
            .WithOne(c => c.Manufacturer)
            .HasForeignKey(k => k.ManufacturerId);
        });

        modelBuilder.Entity<Types>(eb =>
        {
            eb.HasMany(w => w.Punches)
            .WithOne(c => c.Types)
            .HasForeignKey(k => k.TypesId)
            .OnDelete(DeleteBehavior.NoAction);
            
            eb.HasMany(w => w.TabletPress)
            .WithOne(c => c.Types)
            .HasForeignKey(k => k.TypesId)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<TabletPress>(eb =>
        {
            eb.HasMany(w => w.Products)
            .WithOne(c => c.TabletPress)
            .HasForeignKey(k => k.TabletPressId);

            eb.HasMany(w => w.Punches)
            .WithMany(c => c.TabletPress);
            //.UsingEntity<TabletPressPunches>(
            //    j => j.HasOne(pt => pt.TabletPress)
            //    .WithMany(p => p.TabletPressPunches)
            //    .HasForeignKey(pt => pt.TabletPressId),
            //    j => j.HasOne(pt => pt.Punches)
            //    .WithMany(p => p.TabletPressPunches)
            //    .HasForeignKey(pt => pt.PunchesId),
            //    j =>
            //    {
            //        j.Property(pt => pt.UsingDate).HasDefaultValueSql("");
            //        j.HasKey(t => new { t.TabletPressId, t.PunchesId });
            //    }
            //    );
            
        });

        modelBuilder.Entity<User>(eb =>
        {
            eb.HasOne(w => w.UserRole)
            .WithMany(c => c.User)
            .HasForeignKey(k => k.UserRoleId);
        });
    }
        

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<TabletPress> TabletPresses { get; set; }
    public DbSet<Punches> Punches { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
    public DbSet<Types> Types { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<TabletPressPunches> TabletPressesPunches { get; set; }
}

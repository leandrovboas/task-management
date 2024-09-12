using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infrastructure.Configurations;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<WorkItems> WorkItemss { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<WorkItemsHistory> WorkItemsHistories { get; set; }

    public override int SaveChanges()
    {
        foreach (var entity in ChangeTracker.Entries<Project>())
        {
            if (entity.State == EntityState.Deleted)
            {
                entity.State = EntityState.Modified;
                entity.Entity.ChangeIsDeleted(true);
            }
        }
        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasQueryFilter(P => !P.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }
}
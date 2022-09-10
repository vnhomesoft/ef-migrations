using DemoDbMigrations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DemoDbMigrations;
public class AppDbContext : DbContext {
    public DbSet<Student>? Students { get; set; }
    public DbSet<Subject>? Subjects{ get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // For specifying table schema,
        // see: https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-schema
        modelBuilder.HasDefaultSchema("myapp");
        
        modelBuilder.Entity<Student>()
                .HasMany(u => u.Subjects)
                .WithOne(f => f.Student)
                .HasForeignKey(f => f.StudentId);
        modelBuilder.Entity<StudentSubject>()
                .HasKey(e => new { e.StudentId, e.SubjectId });
    }
}
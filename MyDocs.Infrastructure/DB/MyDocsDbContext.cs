using Microsoft.EntityFrameworkCore;
using MyDocs.Domain.Entities;
using MyDocs.Domain.Enums;

namespace MyDocs.Infrastructure.DB;

public class MyDocsDbContext : DbContext
{
    public DbSet<FamilyMember> FamilyMembers { get; set; }
    //public DbSet<Document> Documents { get; set; }

    public MyDocsDbContext(DbContextOptions<MyDocsDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=mydocs.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FamilyMember>()
            .Property(f => f.Gender)
            .HasConversion(
                v => v.Value, // Convert Gender to int
                v => Gender.FromValue(v) // Convert int to Gender
            );

        modelBuilder.Entity<FamilyMember>()
        .Property(e => e.RelationshipTowardsUser)
        .HasConversion(
            v => v.Value, // Convert Relationship to int
            v => Relationship.FromValue(v) // Convert int to Relationship
        );
    }
}

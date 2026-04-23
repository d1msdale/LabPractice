using Microsoft.EntityFrameworkCore;
using Practice.Domain.Models;
using Practice.Infrastructure.Configuration.Entity;

namespace Practice.Infrastructure.Configuration;

public class PracticeDbContext(DbContextOptions<PracticeDbContext> options) : DbContext(options)
{
    public DbSet<Person> Practices => Set<Person>();
    public DbSet<Contact> Contacts => Set<Contact>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
    }
}
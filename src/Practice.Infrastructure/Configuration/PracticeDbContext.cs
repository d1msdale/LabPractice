using Microsoft.EntityFrameworkCore;
using Practice.Domain.Models;

namespace Practice.Infrastructure.Configuration;

public class PracticeDbContext(DbContextOptions<PracticeDbContext> options) : DbContext(options)
{
    public DbSet<Person> Practices => Set<Person>();
    public DbSet<Contact> Contacts => Set<Contact>();
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Domain.Models;

namespace Practice.Infrastructure.Configuration.Entity;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.DateOfBirth).IsRequired();
        builder.Property(p => p.Gender).IsRequired();

        builder.HasMany(p => p.Contacts)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
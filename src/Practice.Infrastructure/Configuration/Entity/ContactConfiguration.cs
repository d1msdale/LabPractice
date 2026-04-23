using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Domain.Models;

namespace Practice.Infrastructure.Configuration.Entity;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.PhoneNumber).IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Surname).IsRequired();

        // The inverse side of the one-to-many is declared on PersonConfiguration,
        // which owns the "PersonId" shadow foreign key and the Cascade delete rule.
    }
}
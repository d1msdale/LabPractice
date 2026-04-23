# Persistence

## DbContext

`PracticeDbContext` (in `src/Practice.Infrastructure/Configuration`) exposes:

- `DbSet<Person> Practices` — note the DbSet is named `Practices`, so **the `Person` entity maps to a table named `Practices`**. Keep this in mind for raw SQL and new migrations; don't rename without a migration.
- `DbSet<Contact> Contacts`

`OnModelCreating` applies `PersonConfiguration` and `ContactConfiguration` explicitly. When adding a new entity, register its configuration there (or switch to `ApplyConfigurationsFromAssembly` if the list grows).

## Entity configurations

Fluent API lives in `src/Practice.Infrastructure/Configuration/Entity/`. One `IEntityTypeConfiguration<T>` per entity. Prefer Fluent configuration over data annotations so Domain entities stay framework-free.

## Relations

- **Person 1 ──◄ N Contact** — one-to-many, configured on `PersonConfiguration`:
  - Navigation: `Person.Contacts` ↔ `Contact.Person`
  - Foreign key: `Contact.PersonId` (explicit nullable `Guid?` property, not a shadow FK)
  - Delete behavior: `Cascade` — removing a `Person` deletes its `Contacts`
  - The `Contact` side does **not** redeclare the relationship; only the principal (`Person`) side owns it to avoid conflicting configurations.

When adding new relations, declare them on exactly one side (typically the principal) and expose the FK as an explicit property on the dependent entity — consistent with how `Contact.PersonId` is modeled.
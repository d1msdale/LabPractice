# Architecture

Four-project layered setup targeting **.NET 10**. Reference direction is strict — do not add upward references:

```
Practice.Api  ──►  Practice.Infrastructure  ──►  Practice.Application  ──►  Practice.Domain
                                           └──►  Practice.Domain
```

- **Practice.Domain** — POCO entities only (`Person`, `Contact`, `Gender`). No framework dependencies.
- **Practice.Application** — currently empty; intended for use-cases / handlers. Only references Domain.
- **Practice.Infrastructure** — `PracticeDbContext`, EF Core + Npgsql, migrations, entity configurations, and `DatabaseExtensions.ConfigureDatabase` which registers the DbContext from `ConnectionStrings:DefaultConnection`.
- **Practice.Api** — ASP.NET Core host. `Program.cs` wires OpenAPI, the DbContext (via `ConfigureDatabase`), and controllers. **On startup it calls `db.Database.Migrate()`**, so a reachable Postgres is required to boot. Root namespace is `LabPractice` (not `Practice.Api`).

## Tests

`test/Project.Tests` uses the Microsoft.Testing.Platform (`TestingPlatformDotnetTestSupport=true`, `OutputType=Exe`) — the test project runs as an executable. The project is scaffolded but contains no tests yet.
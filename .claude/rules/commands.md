# Commands

The solution file is `LabPractice.slnx` (the newer XML format). Pass it explicitly — older `dotnet` CLIs do not auto-discover `.slnx`:

```bash
dotnet build LabPractice.slnx
dotnet test  LabPractice.slnx
dotnet run   --project src/Practice.Api
dotnet test  test/Project.Tests --filter "FullyQualifiedName~MyTest"   # single test
```

## Database (Postgres)

The API requires a reachable Postgres before boot, because `Program.cs` calls `db.Database.Migrate()` at startup.

```bash
docker compose up -d database   # postgres:18.1 on localhost:5432, db=lab, user/pw=postgres
```

## EF Core migrations

Migrations live in `src/Practice.Infrastructure/Migrations`. The startup project is the API; the migrations project is Infrastructure.

Create a migration:

```bash
dotnet ef migrations add InitMigration --startup-project src/Practice.Api --project src/Practice.Infrastructure
```

Apply migrations manually (the API also does this on startup):

```bash
dotnet ef database update --startup-project src/Practice.Api --project src/Practice.Infrastructure
```

Revert the last migration:

```bash
dotnet ef migrations remove --startup-project src/Practice.Api --project src/Practice.Infrastructure
```
# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

This file is deliberately short. Topic-specific rules live under `.claude/rules/` — **read the matching file on-demand** when the task touches that area, rather than pre-loading everything.

## Rule index (fetch when relevant)

- `.claude/rules/commands.md` — build, run, test, `dotnet ef` migration commands (create / update / remove). Read this before running any CLI command against the solution.
- `.claude/rules/architecture.md` — the four-project layering (Api → Infrastructure → Application → Domain), reference direction, startup behavior. Read this before adding projects, moving code between layers, or touching `Program.cs`.
- `.claude/rules/persistence.md` — `PracticeDbContext`, entity configurations, and the Person ↔ Contact relation (including the `Person` → `Practices` table-name quirk). Read this before modifying entities, DbContext, or anything under `src/Practice.Infrastructure/Configuration/`.

## At-a-glance

- Solution: `LabPractice.slnx` · TFM: **net10.0** · DB: **PostgreSQL** via Npgsql EF Core
- Root namespace of the API project is `LabPractice` (not `Practice.Api`)
- Startup runs `db.Database.Migrate()` — Postgres must be reachable (`docker compose up -d database`)
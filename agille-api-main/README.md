## Agile API


### How to add migrations:

```bash
dotnet ef migrations add migrationName --startup-project API --project Data
```

# How to run migrations:

```bash
dotnet ef database update --project API
```
# Bootcamp-2024

```
dotnet ef migrations add add_user_table -s Bootcamp.Api -p Bootcamp.Infrastructure -o Database/Migrations
dotnet ef database update -s Bootcamp.Api -p Bootcamp.Infrastructure
```
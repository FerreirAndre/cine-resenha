dotnet ef migrations add InitialCreate --project Cine.Resenha.Persistence --startup-project Cine.Resenha.Api

dotnet ef database update --project Cine.Resenha.Persistence --startup-project Cine.Resenha.Api

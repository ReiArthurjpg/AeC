using AeC.Domain.Entities; using AeC.Infrastructure.Context; using Microsoft.EntityFrameworkCore;
namespace AeC.Infrastructure.Services;
public static class DatabaseSeeder { public static async Task SeedAsync(ApplicationDbContext db){ if(await db.Usuarios.AnyAsync()) return; db.Usuarios.Add(new Usuario{Nome="Administrador",Login="admin",Senha=BCrypt.Net.BCrypt.HashPassword("Admin@123")}); await db.SaveChangesAsync(); } }

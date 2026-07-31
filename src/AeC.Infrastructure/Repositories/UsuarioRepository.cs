using AeC.Domain.Entities; using AeC.Domain.Interfaces; using AeC.Infrastructure.Context; using Microsoft.EntityFrameworkCore;
namespace AeC.Infrastructure.Repositories;
public sealed class UsuarioRepository(ApplicationDbContext db) : IUsuarioRepository
{ public Task<Usuario?> ObterPorUsuarioAsync(string usuario,CancellationToken ct=default)=>db.Usuarios.AsNoTracking().FirstOrDefaultAsync(x=>x.Login==usuario,ct); public Task<Usuario?> ObterPorIdAsync(int id,CancellationToken ct=default)=>db.Usuarios.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id,ct); public Task AdicionarAsync(Usuario u,CancellationToken ct=default)=>db.Usuarios.AddAsync(u,ct).AsTask(); public Task SalvarAsync(CancellationToken ct=default)=>db.SaveChangesAsync(ct); }

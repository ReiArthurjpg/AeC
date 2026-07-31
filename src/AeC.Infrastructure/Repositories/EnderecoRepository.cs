using AeC.Domain.Entities; using AeC.Domain.Interfaces; using AeC.Infrastructure.Context; using Microsoft.EntityFrameworkCore;
namespace AeC.Infrastructure.Repositories;
public sealed class EnderecoRepository(ApplicationDbContext db) : IEnderecoRepository
{
 public async Task<(IReadOnlyList<Endereco> Items,int Total)> ListarAsync(int uid,string? termo,string? ordenar,int pagina,int tamanho,CancellationToken ct=default){ var q=db.Enderecos.AsNoTracking().Where(x=>x.UsuarioId==uid); if(!string.IsNullOrWhiteSpace(termo)) q=q.Where(x=>x.CEP.Contains(termo)||x.Cidade.Contains(termo)); q=ordenar=="cidade_desc"?q.OrderByDescending(x=>x.Cidade):q.OrderBy(x=>x.Cidade).ThenBy(x=>x.Logradouro); var total=await q.CountAsync(ct); var items=await q.Skip((pagina-1)*tamanho).Take(tamanho).ToListAsync(ct); return(items,total); }
 public async Task<IReadOnlyList<Endereco>> ListarTodosAsync(int uid,CancellationToken ct=default)=> await db.Enderecos.AsNoTracking().Where(x=>x.UsuarioId==uid).OrderBy(x=>x.Cidade).ToListAsync(ct);
 public Task<Endereco?> ObterDoUsuarioAsync(int id,int uid,CancellationToken ct=default)=>db.Enderecos.FirstOrDefaultAsync(x=>x.Id==id&&x.UsuarioId==uid,ct);
 public Task AdicionarAsync(Endereco e,CancellationToken ct=default)=>db.Enderecos.AddAsync(e,ct).AsTask(); public void Atualizar(Endereco e)=>db.Enderecos.Update(e); public void Remover(Endereco e)=>db.Enderecos.Remove(e); public Task SalvarAsync(CancellationToken ct=default)=>db.SaveChangesAsync(ct);
}

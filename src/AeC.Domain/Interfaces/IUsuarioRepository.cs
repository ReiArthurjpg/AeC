using AeC.Domain.Entities;
namespace AeC.Domain.Interfaces;
public interface IUsuarioRepository { Task<Usuario?> ObterPorUsuarioAsync(string usuario, CancellationToken ct = default); Task<Usuario?> ObterPorIdAsync(int id, CancellationToken ct = default); Task AdicionarAsync(Usuario usuario, CancellationToken ct = default); Task SalvarAsync(CancellationToken ct = default); }

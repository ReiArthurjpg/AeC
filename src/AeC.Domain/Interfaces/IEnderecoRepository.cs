using AeC.Domain.Entities;
namespace AeC.Domain.Interfaces;
public interface IEnderecoRepository
{
    Task<(IReadOnlyList<Endereco> Items, int Total)> ListarAsync(int usuarioId, string? termo, string? ordenarPor, int pagina, int tamanhoPagina, CancellationToken ct = default);
    Task<IReadOnlyList<Endereco>> ListarTodosAsync(int usuarioId, CancellationToken ct = default);
    Task<Endereco?> ObterDoUsuarioAsync(int id, int usuarioId, CancellationToken ct = default);
    Task AdicionarAsync(Endereco endereco, CancellationToken ct = default);
    void Atualizar(Endereco endereco); void Remover(Endereco endereco); Task SalvarAsync(CancellationToken ct = default);
}

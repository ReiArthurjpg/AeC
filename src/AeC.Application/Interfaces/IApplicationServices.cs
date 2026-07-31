using AeC.Application.DTOs; using AeC.Shared.Results;
namespace AeC.Application.Interfaces;
public interface IAuthService { Task<AuthenticatedUserDto?> AutenticarAsync(LoginDto dto, CancellationToken ct = default); }
public interface IEnderecoService
{
    Task<PagedResult<EnderecoDto>> ListarAsync(int usuarioId, EnderecoFilterDto filtro, CancellationToken ct = default);
    Task<IReadOnlyList<EnderecoDto>> ListarTodosAsync(int usuarioId, CancellationToken ct = default);
    Task<EnderecoDto?> ObterAsync(int id, int usuarioId, CancellationToken ct = default);
    Task<int> CriarAsync(int usuarioId, EnderecoFormDto dto, CancellationToken ct = default);
    Task AtualizarAsync(int id, int usuarioId, EnderecoFormDto dto, CancellationToken ct = default);
    Task ExcluirAsync(int id, int usuarioId, CancellationToken ct = default);
}
public interface IViaCepService { Task<ViaCepAddressDto?> BuscarAsync(string cep, CancellationToken ct = default); }
public interface ICsvExportService { byte[] ExportarEnderecos(IEnumerable<EnderecoDto> enderecos); }
public interface IPasswordHasher { string Hash(string senha); bool Verify(string senha, string hash); }

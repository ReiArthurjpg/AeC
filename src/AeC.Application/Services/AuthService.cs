using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Domain.Entities; using AeC.Domain.Interfaces;
namespace AeC.Application.Services;
public sealed class AuthService(IUsuarioRepository usuarios, IPasswordHasher hasher) : IAuthService
{
    public async Task<AuthenticatedUserDto?> AutenticarAsync(LoginDto dto, CancellationToken ct = default)
    { var user = await usuarios.ObterPorUsuarioAsync(dto.Usuario.Trim(), ct); return user is not null && hasher.Verify(dto.Senha, user.Senha) ? new(user.Id,user.Nome,user.Login) : null; }

    public async Task<CadastroResultDto> CadastrarAsync(CadastroDto dto, CancellationToken ct = default)
    {
        var existente = await usuarios.ObterPorUsuarioAsync(dto.Usuario.Trim(), ct);
        if (existente is not null) return new(false, "Este nome de usuário já está em uso.");
        var usuario = new Usuario { Nome = dto.Nome.Trim(), Login = dto.Usuario.Trim(), Senha = hasher.Hash(dto.Senha) };
        await usuarios.AdicionarAsync(usuario, ct);
        await usuarios.SalvarAsync(ct);
        return new(true, null);
    }
}

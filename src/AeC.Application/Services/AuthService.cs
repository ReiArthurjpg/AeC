using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Domain.Interfaces;
namespace AeC.Application.Services;
public sealed class AuthService(IUsuarioRepository usuarios, IPasswordHasher hasher) : IAuthService
{
    public async Task<AuthenticatedUserDto?> AutenticarAsync(LoginDto dto, CancellationToken ct = default)
    { var user = await usuarios.ObterPorUsuarioAsync(dto.Usuario.Trim(), ct); return user is not null && hasher.Verify(dto.Senha, user.Senha) ? new(user.Id,user.Nome,user.Login) : null; }
}

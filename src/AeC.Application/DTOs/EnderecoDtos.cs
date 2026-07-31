using System.ComponentModel.DataAnnotations;
namespace AeC.Application.DTOs;
public sealed record EnderecoDto(int Id,string CEP,string Logradouro,string? Complemento,string Bairro,string Cidade,string UF,string Numero,int UsuarioId);
public sealed class EnderecoFormDto
{
    public int Id { get; set; }
    [Required, RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage="Informe um CEP válido.")] public string CEP { get; set; } = string.Empty;
    [Required, MaxLength(200)] public string Logradouro { get; set; } = string.Empty;
    [MaxLength(200)] public string? Complemento { get; set; }
    [Required, MaxLength(120)] public string Bairro { get; set; } = string.Empty;
    [Required, MaxLength(120)] public string Cidade { get; set; } = string.Empty;
    [Required, StringLength(2, MinimumLength=2)] public string UF { get; set; } = string.Empty;
    [Required, MaxLength(20)] public string Numero { get; set; } = string.Empty;
}
public sealed record EnderecoFilterDto(string? Termo, string? OrdenarPor, int Pagina = 1, int TamanhoPagina = 10);
public sealed record ViaCepAddressDto(string Cep,string Logradouro,string? Complemento,string Bairro,string Localidade,string Uf);
public sealed record LoginDto(string Usuario,string Senha);
public sealed record AuthenticatedUserDto(int Id,string Nome,string Usuario);

using System.ComponentModel.DataAnnotations;
namespace AeC.Application.DTOs;
public sealed record EnderecoDto(int Id,string CEP,string Logradouro,string? Complemento,string Bairro,string Cidade,string UF,string Numero,int UsuarioId);
public sealed class EnderecoFormDto
{
    public int Id { get; set; }
    [Required(ErrorMessage="O CEP é obrigatório."), RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage="Informe um CEP válido.")] public string CEP { get; set; } = string.Empty;
    [Required(ErrorMessage="O Logradouro é obrigatório."), MaxLength(200, ErrorMessage="Máximo de 200 caracteres.")] public string Logradouro { get; set; } = string.Empty;
    [MaxLength(200, ErrorMessage="Máximo de 200 caracteres.")] public string? Complemento { get; set; }
    [Required(ErrorMessage="O Bairro é obrigatório."), MaxLength(120, ErrorMessage="Máximo de 120 caracteres.")] public string Bairro { get; set; } = string.Empty;
    [Required(ErrorMessage="A Cidade é obrigatória."), MaxLength(120, ErrorMessage="Máximo de 120 caracteres.")] public string Cidade { get; set; } = string.Empty;
    [Required(ErrorMessage="A UF é obrigatória."), StringLength(2, MinimumLength=2, ErrorMessage="A UF deve ter 2 caracteres.")] public string UF { get; set; } = string.Empty;
    [Required(ErrorMessage="O Número é obrigatório."), MaxLength(20, ErrorMessage="Máximo de 20 caracteres.")] public string Numero { get; set; } = string.Empty;
}
public sealed record EnderecoFilterDto(string? Termo, string? OrdenarPor, int Pagina = 1, int TamanhoPagina = 10);
public sealed record ViaCepAddressDto(string Cep,string Logradouro,string? Complemento,string Bairro,string Localidade,string Uf);
public sealed record LoginDto(string Usuario,string Senha);
public sealed record AuthenticatedUserDto(int Id,string Nome,string Usuario);

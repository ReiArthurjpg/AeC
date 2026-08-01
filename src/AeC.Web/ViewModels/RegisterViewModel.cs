using System.ComponentModel.DataAnnotations;
namespace AeC.Web.ViewModels;
public sealed class RegisterViewModel
{
    [Required(ErrorMessage = "Informe seu nome completo.")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe um nome de usuário.")]
    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z0-9_\.]+$", ErrorMessage = "Use apenas letras, números, _ ou .")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe uma senha.")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mínimo de 6 caracteres.")]
    public string Senha { get; set; } = string.Empty;

    [Required(ErrorMessage = "Confirme a senha.")]
    [DataType(DataType.Password)]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
    public string ConfirmarSenha { get; set; } = string.Empty;
}

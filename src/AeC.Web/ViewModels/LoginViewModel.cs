using System.ComponentModel.DataAnnotations;
namespace AeC.Web.ViewModels;
public sealed class LoginViewModel { [Required(ErrorMessage="Informe o usuário.")] public string Usuario { get; set; } = string.Empty; [Required(ErrorMessage="Informe a senha."), DataType(DataType.Password)] public string Senha { get; set; } = string.Empty; }

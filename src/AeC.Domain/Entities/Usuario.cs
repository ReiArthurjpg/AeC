namespace AeC.Domain.Entities;
public sealed class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
}

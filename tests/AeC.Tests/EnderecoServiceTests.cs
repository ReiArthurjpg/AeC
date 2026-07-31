using AeC.Application.DTOs; using AeC.Application.Services; using AeC.Domain.Entities; using AeC.Domain.Interfaces; using Moq;
namespace AeC.Tests;
public sealed class EnderecoServiceTests
{ [Fact] public async Task ListarTodosAsync_DeveMapearSomenteRepositorioDoUsuario(){ var repo=new Mock<IEnderecoRepository>(); repo.Setup(x=>x.ListarTodosAsync(7,It.IsAny<CancellationToken>())).ReturnsAsync([new Endereco{Id=1,UsuarioId=7,CEP="01001000",Logradouro="Praça",Bairro="Sé",Cidade="São Paulo",UF="SP",Numero="1"}]); var sut=new EnderecoService(repo.Object); var r=await sut.ListarTodosAsync(7); Assert.Single(r); Assert.Equal(7,r[0].UsuarioId); } }

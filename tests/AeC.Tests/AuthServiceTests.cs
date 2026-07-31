using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Application.Services; using AeC.Domain.Entities; using AeC.Domain.Interfaces; using Moq;
namespace AeC.Tests;
public sealed class AuthServiceTests
{ [Fact] public async Task AutenticarAsync_DeveRetornarUsuarioQuandoSenhaValida(){ var repo=new Mock<IUsuarioRepository>(); var hasher=new Mock<IPasswordHasher>(); repo.Setup(x=>x.ObterPorUsuarioAsync("admin",It.IsAny<CancellationToken>())).ReturnsAsync(new Usuario{Id=1,Nome="Administrador",Login="admin",Senha="hash"}); hasher.Setup(x=>x.Verify("Admin@123","hash")).Returns(true); var sut=new AuthService(repo.Object,hasher.Object); var r=await sut.AutenticarAsync(new LoginDto("admin","Admin@123")); Assert.NotNull(r); Assert.Equal(1,r!.Id); } }

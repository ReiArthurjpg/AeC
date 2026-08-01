using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Domain.Entities; using AeC.Domain.Exceptions; using AeC.Domain.Interfaces; using AeC.Shared.Extensions; using AeC.Shared.Results;
namespace AeC.Application.Services;
public sealed class EnderecoService(IEnderecoRepository repo) : IEnderecoService
{
    public async Task<PagedResult<EnderecoDto>> ListarAsync(int usuarioId, EnderecoFilterDto f, CancellationToken ct = default){ var (items,total)=await repo.ListarAsync(usuarioId,f.Termo?.Clean(),f.OrdenarPor,f.UF,f.Cidade,f.Pagina<1?1:f.Pagina,f.TamanhoPagina<1?10:f.TamanhoPagina,ct); return new(items.Select(Map).ToList(),total,f.Pagina,f.TamanhoPagina); }
    public async Task<IReadOnlyList<EnderecoDto>> ListarTodosAsync(int usuarioId, CancellationToken ct = default)=> (await repo.ListarTodosAsync(usuarioId,ct)).Select(Map).ToList();
    public async Task<EnderecoDto?> ObterAsync(int id,int usuarioId,CancellationToken ct=default)=> (await repo.ObterDoUsuarioAsync(id,usuarioId,ct)) is { } e ? Map(e) : null;
    public async Task<int> CriarAsync(int usuarioId, string userName, EnderecoFormDto dto, CancellationToken ct=default){ var e=From(dto,usuarioId,userName); await repo.AdicionarAsync(e,ct); await repo.SalvarAsync(ct); return e.Id; }
    public async Task AtualizarAsync(int id,int usuarioId,string userName,EnderecoFormDto dto,CancellationToken ct=default){ var e=await repo.ObterDoUsuarioAsync(id,usuarioId,ct) ?? throw new DomainException("Endereço não encontrado."); Apply(e,dto); e.AtualizadoPor=userName; repo.Atualizar(e); await repo.SalvarAsync(ct); }
    public async Task ExcluirAsync(int id,int usuarioId,CancellationToken ct=default){ var e=await repo.ObterDoUsuarioAsync(id,usuarioId,ct) ?? throw new DomainException("Endereço não encontrado."); repo.Remover(e); await repo.SalvarAsync(ct); }
    static Endereco From(EnderecoFormDto d,int uid,string uname){ var e=new Endereco{UsuarioId=uid,CriadoPor=uname}; Apply(e,d); return e; }
    static void Apply(Endereco e,EnderecoFormDto d){ e.CEP=d.CEP.OnlyDigits(); e.Logradouro=d.Logradouro.Clean(); e.Complemento=d.Complemento.Clean(); e.Bairro=d.Bairro.Clean(); e.Cidade=d.Cidade.Clean(); e.UF=d.UF.Clean().ToUpperInvariant(); e.Numero=d.Numero.Clean(); }
    static EnderecoDto Map(Endereco e)=>new(e.Id,e.CEP,e.Logradouro,e.Complemento,e.Bairro,e.Cidade,e.UF,e.Numero,e.UsuarioId,e.CriadoPor,e.AtualizadoPor);
}

using System.Security.Claims; using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Web.ViewModels; using Microsoft.AspNetCore.Authorization; using Microsoft.AspNetCore.Mvc;
namespace AeC.Web.Controllers;
[Authorize] public sealed class EnderecosController(IEnderecoService service, IViaCepService viaCep, ICsvExportService csv) : Controller
{ int UsuarioId=>int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
 public async Task<IActionResult> Index(string? termo,string? ordenarPor,int pagina=1){ var data=await service.ListarAsync(UsuarioId,new(termo,ordenarPor,pagina,10)); return View(new EnderecoListViewModel{Enderecos=data,Termo=termo,OrdenarPor=ordenarPor}); }
 public IActionResult Create()=>View("Form",new EnderecoFormDto());
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Create(EnderecoFormDto dto){ if(!ModelState.IsValid) return View("Form",dto); await service.CriarAsync(UsuarioId,dto); TempData["Success"]="Endereço cadastrado com sucesso."; return RedirectToAction(nameof(Index)); }
 public async Task<IActionResult> Edit(int id){ var e=await service.ObterAsync(id,UsuarioId); if(e is null) return NotFound(); return View("Form",new EnderecoFormDto{Id=e.Id,CEP=e.CEP,Logradouro=e.Logradouro,Complemento=e.Complemento,Bairro=e.Bairro,Cidade=e.Cidade,UF=e.UF,Numero=e.Numero}); }
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id,EnderecoFormDto dto){ if(!ModelState.IsValid) return View("Form",dto); await service.AtualizarAsync(id,UsuarioId,dto); TempData["Success"]="Endereço atualizado com sucesso."; return RedirectToAction(nameof(Index)); }
 public async Task<IActionResult> Details(int id){ var e=await service.ObterAsync(id,UsuarioId); return e is null ? NotFound() : View(e); }
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Delete(int id){ await service.ExcluirAsync(id,UsuarioId); TempData["Success"]="Endereço excluído com sucesso."; return RedirectToAction(nameof(Index)); }
 public async Task<IActionResult> BuscarCep(string cep){ var e=await viaCep.BuscarAsync(cep); return e is null ? NotFound(new{message="CEP não encontrado."}) : Json(e); }
 public async Task<IActionResult> ExportCsv(){ var enderecos=await service.ListarTodosAsync(UsuarioId); return File(csv.ExportarEnderecos(enderecos),"text/csv; charset=utf-8","enderecos.csv"); } }

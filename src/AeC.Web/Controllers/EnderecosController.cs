using System.Security.Claims; using AeC.Application.DTOs; using AeC.Application.Interfaces; using AeC.Web.ViewModels; using Microsoft.AspNetCore.Authorization; using Microsoft.AspNetCore.Mvc;
namespace AeC.Web.Controllers;
[Authorize] public sealed class EnderecosController(IEnderecoService service, IViaCepService viaCep, ICsvExportService csv) : Controller
{ int UsuarioId=>int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    public async Task<IActionResult> Index(string? termo, string? ordenarPor, string? uf, string? cidade, int pagina = 1)
    {
        var data = await service.ListarAsync(UsuarioId, new(termo, ordenarPor, uf, cidade, pagina, 9));
        var todos = await service.ListarTodosAsync(UsuarioId);
        int totalCidades = todos.Select(x => x.Cidade).Distinct(StringComparer.OrdinalIgnoreCase).Count();
        var ufsDisponiveis = todos.Select(x => x.UF).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(x => x).ToList();
        return View(new EnderecoListViewModel { 
            Enderecos = data, 
            Termo = termo, 
            OrdenarPor = ordenarPor, 
            UF = uf, 
            Cidade = cidade, 
            TotalCidades = totalCidades,
            UfsDisponiveis = ufsDisponiveis
        });
    }

 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Create(EnderecoFormDto dto){ if(!ModelState.IsValid){ if(Request.Headers["X-Requested-With"]=="XMLHttpRequest"){ var errors=ModelState.Where(x=>x.Value?.Errors.Count>0).ToDictionary(k=>k.Key,v=>v.Value!.Errors.Select(e=>e.ErrorMessage).ToArray()); return Json(new{success=false,errors}); } return RedirectToAction(nameof(Index)); } await service.CriarAsync(UsuarioId,User.Identity!.Name!,dto); if(Request.Headers["X-Requested-With"]=="XMLHttpRequest") return Json(new{success=true}); TempData["Success"]="Endereço cadastrado com sucesso."; return RedirectToAction(nameof(Index)); }

 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Edit(int id,EnderecoFormDto dto){ if(!ModelState.IsValid){ if(Request.Headers["X-Requested-With"]=="XMLHttpRequest"){ var errors=ModelState.Where(x=>x.Value?.Errors.Count>0).ToDictionary(k=>k.Key,v=>v.Value!.Errors.Select(e=>e.ErrorMessage).ToArray()); return Json(new{success=false,errors}); } return RedirectToAction(nameof(Index)); } await service.AtualizarAsync(id,UsuarioId,User.Identity!.Name!,dto); if(Request.Headers["X-Requested-With"]=="XMLHttpRequest") return Json(new{success=true}); TempData["Success"]="Endereço atualizado com sucesso."; return RedirectToAction(nameof(Index)); }

 public async Task<IActionResult> GetJson(int id){ var e=await service.ObterAsync(id,UsuarioId); return e is null ? NotFound() : Json(e); }
 [HttpPost,ValidateAntiForgeryToken] public async Task<IActionResult> Delete(int id){ await service.ExcluirAsync(id,UsuarioId); TempData["Success"]="Endereço excluído com sucesso."; return RedirectToAction(nameof(Index)); }
 public async Task<IActionResult> BuscarCep(string cep){ var e=await viaCep.BuscarAsync(cep); return e is null ? NotFound(new{message="CEP não encontrado."}) : Json(e); }
 public async Task<IActionResult> ExportCsv(){ var enderecos=await service.ListarTodosAsync(UsuarioId); return File(csv.ExportarEnderecos(enderecos),"text/csv; charset=utf-8","enderecos.csv"); } }

using AeC.Application.DTOs;
using AeC.Shared.Results;
using System.Collections.Generic;
namespace AeC.Web.ViewModels;
public sealed class EnderecoListViewModel { 
    public PagedResult<EnderecoDto> Enderecos { get; set; } = new([],0,1,10); 
    public string? Termo { get; set; } 
    public string? OrdenarPor { get; set; } 
    public string? UF { get; set; }
    public string? Cidade { get; set; }
    public int TotalCidades { get; set; }
    public List<string> UfsDisponiveis { get; set; } = new();
}

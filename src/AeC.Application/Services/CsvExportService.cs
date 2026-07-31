using System.Text; using AeC.Application.DTOs; using AeC.Application.Interfaces;
namespace AeC.Application.Services;
public sealed class CsvExportService : ICsvExportService
{
    public byte[] ExportarEnderecos(IEnumerable<EnderecoDto> enderecos){ var sb=new StringBuilder(); sb.AppendLine("CEP,Logradouro,Complemento,Bairro,Cidade,UF,Número"); foreach(var e in enderecos) sb.AppendLine(string.Join(',', new[]{e.CEP,e.Logradouro,e.Complemento??"",e.Bairro,e.Cidade,e.UF,e.Numero}.Select(Escape))); return new UTF8Encoding(true).GetBytes(sb.ToString()); }
    static string Escape(string v)=> v.Contains(',')||v.Contains('"')||v.Contains('\n') ? $"\"{v.Replace("\"","\"\"")}\"" : v;
}

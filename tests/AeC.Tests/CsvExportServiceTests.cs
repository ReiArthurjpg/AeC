using AeC.Application.DTOs; using AeC.Application.Services;
namespace AeC.Tests;
public sealed class CsvExportServiceTests
{ [Fact] public void ExportarEnderecos_DeveGerarCabecalhoECamposEscapados(){ var sut=new CsvExportService(); var bytes=sut.ExportarEnderecos([new EnderecoDto(1,"01001000","Rua, Teste","Apto \"1\"","Centro","São Paulo","SP","10",1)]); var csv=System.Text.Encoding.UTF8.GetString(bytes); Assert.Contains("CEP,Logradouro,Complemento,Bairro,Cidade,UF,Número",csv); Assert.Contains("\"Rua, Teste\"",csv); Assert.Contains("\"Apto \"\"1\"\"\"",csv); } }

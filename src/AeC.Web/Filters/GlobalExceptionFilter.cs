using Microsoft.AspNetCore.Mvc; using Microsoft.AspNetCore.Mvc.Filters;
namespace AeC.Web.Filters;
public sealed class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
{ public void OnException(ExceptionContext context){ logger.LogError(context.Exception,"Erro não tratado"); context.Result=new ViewResult{ViewName="~/Views/Shared/Error.cshtml"}; context.ExceptionHandled=true; } }

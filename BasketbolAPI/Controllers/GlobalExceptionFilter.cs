using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BasketbolAPI.Controllers;

/// <summary>
/// Denetleyici işlem hattında yakalanmamış istisnaları JSON hata gövdesine dönüştürür.
/// </summary>
public sealed class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = new JsonResult(new
        {
            message = "Bir hata oluştu",
            detail = context.Exception.Message
        })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}

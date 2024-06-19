using ErrorOr;
using LunaLoot.Tenant.Api.Common.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LunaLoot.Tenant.Api.Common;

[ApiController]
public class ApiController:ControllerBase
{
    protected IActionResult Problem(List<Error>? errors)
    {
        
        if (errors is null)
            return Problem(
                statusCode: StatusCodes.Status400BadRequest);
        
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();
         
            errors.ForEach( e=> modelStateDictionary.AddModelError(
                e.Code,
                e.Description
            ));
            return ValidationProblem(modelStateDictionary);
        }
        
        HttpContext.Items[HttpContextKeys.Errors] = errors;
        
      
        
        var firstError = errors.FirstOrDefault();

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        
        return Problem(
            statusCode: statusCode, title: firstError.Description
        );
    }
}
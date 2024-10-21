using Microsoft.AspNetCore.Mvc;
using POC.DDD.Application.DTOs.Output.Base;
using POC.DDD.Shared;

namespace POC.DDD.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult HandleResultError(ResultError resultError)
        {
            return resultError.Status switch
            {
                ResultErrorStatus.NotFound => NotFound(new ErrorResponse(resultError.Messages)),
                ResultErrorStatus.BadRequest => BadRequest(new ErrorResponse(resultError.Messages)),
                _ => throw new NotImplementedException()
            };
        }
    }
}

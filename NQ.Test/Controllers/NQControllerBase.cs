using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace NQ.Test.Controllers
{
    public class NQControllerBase : ControllerBase
    {
        protected IActionResult ExecuteAction<T>(Func<T> action)
        {
            try
            {
                return Ok(action());
            }
            catch (Exception exc)
            {
                return BadRequest(new
                {
                    Status = HttpStatusCode.BadRequest,
                    TraceId = HttpContext.TraceIdentifier,
                    Title = exc.Message
                });
            }
        }
    }
}

using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Domain.Base.Extensions;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;

namespace SistemaConcurso.Api.Base;

[ApiController]
[Route("api/[controller]")]
public class BasierController : ControllerBase
{
    public IActionResult Error(Exception e, string? message = null)
    {
        if (e is RuleException)
        {
            return BadRequest(e.Message);
        }
        
        var returnMessage = message ?? "An error has occurred, try again later!";
        return BadRequest(returnMessage);
    }
    
    public IActionResult Error(Exception e, EException eException)
    {
        var returnMessage = eException.GetDescription();
        return Error(e, returnMessage);
    }
}
using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Interfaces.Auth;

namespace SistemaConcurso.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthApplication application) : BasierController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDto dto)
    {
        try
        {
            var reg = await application.Login(dto);
            return Ok(reg);
        }
        catch (Exception e)
        {
            return Error(e, EException.LoginFailed);
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthDto dto)
    {
        try
        {
            await application.Register(dto);
            return Ok("Register completed successfully!");
        }
        catch (Exception e)
        {
            return Error(e, EException.RegisterFailed);
        }
    }
}
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Interfaces;
using SistemaConcurso.Domain.Interfaces.Auth;

namespace SistemaConcurso.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthApplication application) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthDto dto)
    {
        try
        {
            var reg = await application.Login(dto);
            return Ok(reg);
        }
        catch (Exception)
        {
            return BadRequest("Login failed!");
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
        catch (Exception)
        {
            return BadRequest("Register failed!");
        }
    }
}
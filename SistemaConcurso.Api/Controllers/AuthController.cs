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
        catch (Exception e)
        {
            return BadRequest("Login failed!");
        }
    }
}
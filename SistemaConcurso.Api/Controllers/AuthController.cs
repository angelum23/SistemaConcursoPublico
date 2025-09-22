using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaConcurso.Api.Base;
using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Interfaces.Auth;
using SistemaConcurso.Domain.Interfaces.Token;

namespace SistemaConcurso.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BasierController
{
    private readonly IAuthApplication _application;
    private readonly IJwtSettings _jwt;

    public AuthController(IAuthApplication application, IOptions<JwtSettings> jwt)
    {
        _jwt = jwt.Value;
        _application = application;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            var reg = await _application.Login(dto);
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
            await _application.Register(dto);
            return Ok("Register completed successfully!");
        }
        catch (Exception e)
        {
            return Error(e, EException.RegisterFailed);
        }
    }

    [HttpGet("validate")]
    public IActionResult ValidateJwt()
    {
        var authHeader = Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
            return BadRequest("Header Authorization inválido");

        var tokenStr = authHeader.Substring("Bearer ".Length).Trim();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwt.Key);

        try
        {
            tokenHandler.ValidateToken(tokenStr, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwt.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwt.Audience,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero // sem tolerância
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var exp = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            var nbf = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Nbf)?.Value;
            var iss = jwtToken.Issuer;
            var aud = jwtToken.Audiences.FirstOrDefault();

            return Ok(new
            {
                exp,
                nbf,
                iss,
                aud
            });
        }
        catch (SecurityTokenException ex)
        {
            return Unauthorized(new { message = "Token inválido", error = ex.Message });
        }
    }
}
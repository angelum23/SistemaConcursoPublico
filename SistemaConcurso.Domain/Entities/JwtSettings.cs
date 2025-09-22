using SistemaConcurso.Domain.Interfaces.Token;

namespace SistemaConcurso.Domain.Entities;

public class JwtSettings : IJwtSettings
{
    public string Key { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public int ExpiresMinutes { get; set; } = 30;
}

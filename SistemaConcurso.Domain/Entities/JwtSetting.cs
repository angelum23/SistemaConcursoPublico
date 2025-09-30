using SistemaConcurso.Domain.Interfaces.Token;

namespace SistemaConcurso.Domain.Entities;

public class JwtSetting : IJwtSetting
{
    public string Key { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string Audience { get; set; } = "";
    public int ExpiresMinutes { get; set; } = 30;
}

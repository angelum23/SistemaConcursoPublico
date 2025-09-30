namespace SistemaConcurso.Domain.Interfaces.Token;

public interface IJwtSetting
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresMinutes { get; set; }
}
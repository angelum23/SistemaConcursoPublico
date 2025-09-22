using SistemaConcurso.Domain.Base;

namespace SistemaConcurso.Domain.Entities;

public class RefreshTokenData : BaseEntity
{
    public string Username { get; set; }
    public string TokenHash { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public string ReplacedByTokenHash { get; set; }
    public bool IsActive => Revoked == null && DateTime.UtcNow < Expires;
}
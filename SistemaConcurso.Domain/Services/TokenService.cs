using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Token;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class TokenService : ITokenService
{
    private readonly IJwtSettings _jwt;
    private readonly IBaseRepository<RefreshTokenData> _tokenRepository;
    private readonly IBaseRepository<Users> _usersRepository;

    public TokenService(IOptions<JwtSettings> jwtOptions, 
                        IBaseRepository<RefreshTokenData> tokenRepository, 
                        IBaseRepository<Users> usersRepository)
    {
        _jwt = jwtOptions.Value;
        _tokenRepository = tokenRepository;
        _usersRepository = usersRepository;
    }

    public async Task<TokenView> GenerateTokensAsync(Users user, params string[] roles)
    {
        var key = Encoding.UTF8.GetBytes(_jwt.Key);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var expires = DateTime.UtcNow.AddMinutes(_jwt.ExpiresMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        var (refreshToken, refreshHash) = GenerateRefreshToken();

        var now = DateTime.UtcNow;
        var refreshTokenEntity = new RefreshTokenData
        {
            Username = user.Username,
            TokenHash = refreshHash,
            Created = now,
            Expires = now.AddMonths(1)
        };

        await _tokenRepository.AddAsync(refreshTokenEntity);
        
        return new TokenView(tokenString, refreshToken, expires);
    }

    private static string HashToken(string token)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(token);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    public (string refreshToken, string refreshHash) GenerateRefreshToken()
    {
        var raw = RandomNumberGenerator.GetBytes(64);
        var refreshToken = Convert.ToBase64String(raw);

        var refreshHash = HashToken(refreshToken);
        return (refreshToken, refreshHash);
    }
    
    public async Task<TokenView> RefreshAsync(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
        {
            throw new Exception("Empty refresh token!");
        }

        var incomingHash = HashToken(refreshToken);

        var existing = _tokenRepository.Get().Single(t => t.TokenHash == incomingHash);

        if (!existing.IsActive)
        {
            throw new UnauthorizedAccessException("Invalid or expired refresh token!");
        }
        
        var user = _usersRepository.Get().Single(u => u.Username == existing.Username);
        var (newRaw, newHash) = GenerateRefreshToken();

        existing.Revoked = DateTime.UtcNow;
        existing.ReplacedByTokenHash = newHash;

        var now = DateTime.UtcNow;
        var newEntity = new RefreshTokenData
        {
            Username = user.Username,
            TokenHash = newHash,
            Created = now,
            Expires = now.AddMonths(1)
        };

        await _tokenRepository.AddAsync(newEntity);

        var jwt = GenerateJwtForUser(user, "user");
        return new TokenView(jwt.TokenString, newRaw, jwt.Expires);
    }

    public async Task RevokeAsync(string refreshToken)
    {
        if (string.IsNullOrWhiteSpace(refreshToken))
            return;

        var hash = HashToken(refreshToken);
        var entity = _tokenRepository.Get().Single(t => t.TokenHash == hash);

        if (entity.IsActive)
        {
            entity.Revoked = DateTime.UtcNow;
            await _tokenRepository.UpdateAsync(entity);
        }
    }
    
    private (string TokenString, DateTime Expires) GenerateJwtForUser(Users user, params string[] roles)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_jwt.Key);
        var creds = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var expires = DateTime.UtcNow.AddMinutes(_jwt.ExpiresMinutes);
        var jwtToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expires,
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return (tokenString, expires);
    }
}
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Token;

public interface ITokenService
{
    Task<TokenView> GenerateTokensAsync(Users user, params string[] roles);
    (string refreshToken, string refreshHash) GenerateRefreshToken();
}
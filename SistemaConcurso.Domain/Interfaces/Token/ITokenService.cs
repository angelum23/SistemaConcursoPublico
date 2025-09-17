using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Token;

public interface ITokenService
{
    TokenView GenerateTokens(Users user, params string[] roles);
    string GenerateRefreshToken();
}
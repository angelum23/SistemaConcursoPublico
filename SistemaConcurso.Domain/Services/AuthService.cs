using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Interfaces.Auth;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class AuthService : IAuthService
{
    public Task<AuthView> Login(AuthDto dto)
    {
        throw new NotImplementedException();
    }
}
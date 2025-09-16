using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthView> Login(AuthDto dto);
}
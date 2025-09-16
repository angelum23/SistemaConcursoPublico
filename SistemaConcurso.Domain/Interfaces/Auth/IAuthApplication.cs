using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Auth;

public interface IAuthApplication
{
    public Task<AuthView> Login(AuthDto dto);
}
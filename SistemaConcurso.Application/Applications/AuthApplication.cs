using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Interfaces.Auth;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Application.Applications;

public class AuthApplication(IAuthService service) : IAuthApplication
{
    public Task<AuthView> Login(AuthDto dto)
    {
        return service.Login(dto);
    }
}
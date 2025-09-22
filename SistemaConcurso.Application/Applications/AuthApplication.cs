using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Interfaces.Auth;
using SistemaConcurso.Domain.Interfaces.Token;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Application.Applications;

public class AuthApplication(IAuthService service, ITokenService tokenService) : IAuthApplication
{
    public async Task<TokenView> Login(LoginDto dto)
    {
        var user = await service.Login(dto);
        return await tokenService.GenerateTokensAsync(user, "User");
    }

    public Task Register(AuthDto dto)
    {
        return service.Register(dto);
    }
}
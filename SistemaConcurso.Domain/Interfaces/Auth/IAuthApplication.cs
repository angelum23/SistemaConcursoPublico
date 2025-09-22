using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Auth;

public interface IAuthApplication
{
    public Task<TokenView> Login(LoginDto dto);
    public Task Register(AuthDto dto);
}
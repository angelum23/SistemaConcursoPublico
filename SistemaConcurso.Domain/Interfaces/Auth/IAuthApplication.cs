using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Auth;

public interface IAuthApplication
{
    public Task<TokenView> Login(AuthDto dto);
    public Task Register(AuthDto dto);
}
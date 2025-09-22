using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Auth;

public interface IAuthService
{
    Task<Users> Login(LoginDto dto);
    Task Register(AuthDto authDto);
}
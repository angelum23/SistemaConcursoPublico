using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Dtos;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Auth;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class AuthService(IBaseRepository<Users> repository) : IAuthService
{
    public Task<Users> Login(AuthDto dto)
    {
        const string invalidCredentialsMessage = "Invalid email or password!";
        
        var user = repository.Get().FirstOrDefault(x => x.Email == dto.Email || x.Username == dto.Username);
        if (user == null) throw new Exception(invalidCredentialsMessage);
        
        if (!user.CheckPassword(dto.Password)) throw new Exception(invalidCredentialsMessage);

        return Task.FromResult(user);
    }

    public Task Register(AuthDto authDto)
    {
        var alreadyExistsEmail = repository.Get().Any(x => x.Email == authDto.Email);
        if (alreadyExistsEmail) throw new Exception("Email already in use!");
        
        var alreadyExistsUsername = repository.Get().Any(x => x.Username == authDto.Username);
        if (alreadyExistsUsername) throw new Exception("Username already in use!");

        var user = authDto.ToClassUsers();
        repository.AddAsync(user);
        
        return Task.CompletedTask; // Will be true async with database 
    }
}
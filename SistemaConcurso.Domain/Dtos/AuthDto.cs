using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.Domain.Dtos;

public record AuthDto(string Email, string FullName, string Username, string Password)
{
    public Users ToClassUsers()
    {
        var user = new Users
        {
            Email = Email,
            FullName = FullName,
            Username = Username
        };
        
        user.SetPassword(Password);

        return user;
    }
};
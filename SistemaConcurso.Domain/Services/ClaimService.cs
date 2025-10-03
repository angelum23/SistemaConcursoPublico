using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SistemaConcurso.Domain.Enums;
using SistemaConcurso.Domain.Exceptions;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class ClaimService(IHttpContextAccessor accessor) : IClaimService
{
    public UserClaimView GetLoggedUser()
    {
        var user = accessor.HttpContext?.User;
        if (user == null) throw new RuleException(EException.LoggedUserNotFound);
        
        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) throw new RuleException(EException.LoggedUserNotFound);
        
        var username = user.FindFirstValue(ClaimTypes.Name);
        if (username == null) throw new RuleException(EException.LoggedUserNotFound);
        
        return new UserClaimView(int.Parse(userId), username);
    }
}
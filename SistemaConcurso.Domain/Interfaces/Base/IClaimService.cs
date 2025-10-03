using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Base;

public interface IClaimService
{
    UserClaimView GetLoggedUser();
}
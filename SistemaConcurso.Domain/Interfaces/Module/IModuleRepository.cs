using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Module;

public interface IModuleRepository : IBaseRepository<Modules>
{
    IQueryable<ModuleView> List(IPagination pagination, int idRoadmap);
}
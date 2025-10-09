using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Module;

public interface IModuleService : IBaseService<Modules>
{
    Task<List<ModuleView>> List(IPagination pagination, int idRoadmap);
}
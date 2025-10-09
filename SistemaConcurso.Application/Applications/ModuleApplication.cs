using SistemaConcurso.Application.Base;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Module;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Application.Applications;

public class ModuleApplication(IModuleService service, IUnitOfWork uow) 
    : BaseApplication<Modules>(service, uow), IModuleApplication
{
    public Task<List<ModuleView>> List(IPagination pagination, int roadmapId)
    {
        return service.List(pagination, roadmapId);
    }
}
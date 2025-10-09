using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Module;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class ModuleService(IModuleRepository repository) : BaseService<Modules>(repository), IModuleService
{
    public Task<List<ModuleView>> List(IPagination pagination, int idRoadmap)
    {
        return repository.List(pagination, idRoadmap).ToListAsync();
    }
}
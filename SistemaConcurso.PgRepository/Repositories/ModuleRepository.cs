using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Module;
using SistemaConcurso.Domain.Views;
using SistemaConcurso.PgRepository.Base;

namespace SistemaConcurso.PgRepository.Repositories;

public class ModuleRepository : BaseRepository<Modules>, IModuleRepository
{
    public ModuleRepository(PgDbContext dbContext) : base(dbContext)
    {
    }
    
    public IQueryable<ModuleView> List(IPagination pagination, int idRoadmap)
    {
        var query = 
            from m in Get()
            join l in Get<Lessons>() on m.Id equals l.IdModule into lj
            where m.IdRoadmap == idRoadmap
            select new ModuleView(m.Id, m.Title, lj.Select(x => new ModulesLessonView(x.Id, x.Title, x.Done)).ToList());
        
        return query.OrderBy(x => x.Title).Skip(pagination.Skip).Take(pagination.Take);               
    }
}

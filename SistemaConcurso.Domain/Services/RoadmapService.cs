using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Roadmap;

namespace SistemaConcurso.Domain.Services;

public class RoadmapService(IBaseRepository<Roadmaps> repository) : BaseService<Roadmaps>(repository), IRoadmapService
{
    
}
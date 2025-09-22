using SistemaConcurso.Application.Base;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Roadmap;

namespace SistemaConcurso.Application.Applications;

public class RoadmapApplication(IRoadmapService service) : BaseApplication<Roadmaps>(service), IRoadmapApplication
{
    
}
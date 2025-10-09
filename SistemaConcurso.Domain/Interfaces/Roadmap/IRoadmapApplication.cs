using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Roadmap;

public interface IRoadmapApplication : IBaseApplication<Roadmaps>
{
    Task<List<HomeView>> Home(IPagination pagination);
}
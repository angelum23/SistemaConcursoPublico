using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Roadmap;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Services;

public class RoadmapService(IRoadmapRepository repository) : BaseService<Roadmaps>(repository), IRoadmapService
{
    public Task<List<HomeView>> GetHomeData(List<HomeExamView> exams)
    {
        return repository.GetHomeData(exams);
    }
}
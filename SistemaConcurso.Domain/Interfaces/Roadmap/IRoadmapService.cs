using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Roadmap;

public interface IRoadmapService : IBaseService<Roadmaps>
{
    Task<List<HomeView>> GetHomeData(List<HomeExamView> exams);
}
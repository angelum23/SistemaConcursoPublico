using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Roadmap;

public interface IRoadmapRepository : IBaseRepository<Roadmaps>
{
    Task<List<HomeView>> GetHomeData(List<HomeExamView> exams);
}
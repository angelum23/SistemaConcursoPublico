using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Exam;

public interface IExamRepository : IBaseRepository<Exams>
{
    Task<List<HomeExamView>> GetHomeData(int userId);
}
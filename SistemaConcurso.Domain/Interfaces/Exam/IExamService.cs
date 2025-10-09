using SistemaConcurso.Domain.Base.Interfaces;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Exam;

public interface IExamService : IBaseService<Exams>
{
    Task<List<HomeExamView>> GetHomeData(IPagination pagination, int userId);
}
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Exam;

public interface IExamRepository : IBaseRepository<Exams>
{
    IQueryable<HomeExamView> GetHomeData(int userId, IPagination pagination);
}
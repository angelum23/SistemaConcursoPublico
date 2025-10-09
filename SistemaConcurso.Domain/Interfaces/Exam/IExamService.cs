using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Views;

namespace SistemaConcurso.Domain.Interfaces.Exam;

public interface IExamService
{
    Task<List<HomeExamView>> GetHomeData(IPagination pagination, int userId);
}
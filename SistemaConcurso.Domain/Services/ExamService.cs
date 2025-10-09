using SistemaConcurso.Domain.Base;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Exam;
using SistemaConcurso.Domain.Views;
using Microsoft.EntityFrameworkCore;

namespace SistemaConcurso.Domain.Services;

public class ExamService(IExamRepository repository) : BaseService<Exams>(repository), IExamService
{
    public Task<List<HomeExamView>> GetHomeData(IPagination pagination, int userId)
    {
        return repository.GetHomeData(userId, pagination).ToListAsync();
    }
}
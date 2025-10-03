using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Exam;
using SistemaConcurso.Domain.Views;
using SistemaConcurso.PgRepository.Base;

namespace SistemaConcurso.PgRepository.Repositories;

public class ExamRepository(PgDbContext db) : BaseRepository<Exams>(db), IExamRepository
{
    public Task<List<HomeExamView>> GetHomeData(int userId)
    {
        return Get()
            .Where(x => x.IdUser == userId)
            .Select(x => new HomeExamView(x.Id, x.NoticeTitle))
            .ToListAsync();
    }
}
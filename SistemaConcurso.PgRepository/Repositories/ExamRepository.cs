using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Base;
using SistemaConcurso.Domain.Interfaces.Exam;
using SistemaConcurso.Domain.Views;
using SistemaConcurso.PgRepository.Base;

namespace SistemaConcurso.PgRepository.Repositories;

public class ExamRepository(PgDbContext db) : BaseRepository<Exams>(db), IExamRepository
{
    public IQueryable<HomeExamView> GetHomeData(int userId, IPagination pagination)
    {
        return Get()
            .Where(x => x.IdUser == userId)
            .Select(x => new HomeExamView(x.Id, x.NoticeTitle))
            .Skip(pagination.Skip)
            .Take(pagination.Take);
    }
}
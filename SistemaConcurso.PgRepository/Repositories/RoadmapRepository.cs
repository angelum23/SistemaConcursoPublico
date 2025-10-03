using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Entities;
using SistemaConcurso.Domain.Interfaces.Roadmap;
using SistemaConcurso.Domain.Views;
using SistemaConcurso.PgRepository.Base;

namespace SistemaConcurso.PgRepository.Repositories;

public class RoadmapRepository : BaseRepository<Roadmaps>, IRoadmapRepository
{
    public RoadmapRepository(PgDbContext db) : base(db)
    {
    }

    public async Task<List<HomeView>> GetHomeData(List<HomeExamView> exams)
    {
        var examsIds = exams.Select(x => x.IdExam).ToList();
        
        var query =
            from r in Get()
            where examsIds.Contains(r.IdExam)
            let totalLessons = (from m in Get<Modules>()
                                   join l in Get<Lessons>() on m.Id equals l.IdModule
                                  where m.IdRoadmap == r.Id
                                 select l).Count()
            let doneLessons = (from m in Get<Modules>()
                                  join l in Get<Lessons>() on m.Id equals l.IdModule
                                 where m.IdRoadmap == r.Id 
                                    && l.Done
                                select l).Count()
            select new { 
                IdRoadmap = r.Id,
                IdExam = r.IdExam,
                RoadmapTitle = r.Title,
                Progress = totalLessons > 0 ? Math.Round(doneLessons * 100m / totalLessons, 2) : 0m,
                CreatedAt = r.RegisterDate,
                SelectedJobTitle = (from j in Get<JobRoles>()
                                   where j.Id == r.IdSelectedJobRole
                                  select j.Name).FirstOrDefault() ?? "No job role selected."
            };
        
        var result = await query.ToListAsync();
        return result.Select(x =>
            new HomeView
            (
                x.IdRoadmap,
                x.RoadmapTitle,
                x.Progress,
                x.CreatedAt,
                exams.First(y => y.IdExam == x.IdExam),
                x.SelectedJobTitle
            )
        ).ToList();
    }
}
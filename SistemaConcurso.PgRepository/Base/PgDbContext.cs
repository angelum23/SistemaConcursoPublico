using Microsoft.EntityFrameworkCore;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Base;

public class PgDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Assessments> Assessments { get; set; }
    public DbSet<ExamNotices> ExamNotices { get; set; }
    public DbSet<Exams> Exams { get; set; }
    public DbSet<JobRoles> JobRoles { get; set; }
    public DbSet<Lessons> Lessons { get; set; }
    public DbSet<Modules> Modules { get; set; }
    public DbSet<Notices> Notices { get; set; }
    public DbSet<Questions> Questions { get; set; }
    public DbSet<RefreshTokens> RefreshTokens { get; set; }
    public DbSet<Roadmaps> Roadmaps { get; set; }
    public DbSet<Users> Users { get; set; }
}
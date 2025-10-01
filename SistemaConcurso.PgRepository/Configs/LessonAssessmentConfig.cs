using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class LessonAssessmentConfig : IEntityTypeConfiguration<LessonAssessment>
{
    public void Configure(EntityTypeBuilder<LessonAssessment> builder)
    {
        builder.ToTable("lessonassessment");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Lesson)
            .WithMany(l => l.LessonAssessment)
            .HasForeignKey(x => x.IdLesson)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
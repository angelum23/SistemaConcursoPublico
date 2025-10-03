using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaConcurso.Domain.Entities;

namespace SistemaConcurso.PgRepository.Configs;

public class LessonAssessmentConfig : IEntityTypeConfiguration<LessonAssessments>
{
    public void Configure(EntityTypeBuilder<LessonAssessments> builder)
    {
        builder.ToTable("lessonassessment");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Lesson)
            .WithMany(l => l.LessonAssessment)
            .OnDelete(DeleteBehavior.Restrict);
    }
}